using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Emailer.Templates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Emailer
{
    public class EmailDeliveryTask : IBackgroundTask
    {

        private readonly IEmailBlastRepository _emailBlastRepository;
        private readonly ITemplateEngine _templateEngine;
        private readonly IEmailRecipientRepository _recipientRepository;
        private readonly IRepository<Template> _templateRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly SmtpClient _smtpClient;
        private readonly ILogger<EmailDeliveryTask> _logger;
        
        public EmailDeliveryTask(IEmailBlastRepository emailBlastRepository, ITemplateEngine templateEngine,
            IEmailRecipientRepository recipientRepository, IRepository<Template> templateRepository,
            IRepository<Customer> customerRepository, SmtpClient smtpClient, 
            ILogger<EmailDeliveryTask>? logger = null)
        {
            _emailBlastRepository = emailBlastRepository;
            _templateEngine = templateEngine;
            _recipientRepository = recipientRepository;
            _templateRepository = templateRepository;
            _customerRepository = customerRepository;
            _smtpClient = smtpClient;
            _logger = logger ?? NullLogger<EmailDeliveryTask>.Instance;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while(cancellationToken.WaitHandle.WaitOne(5000) == false)
            {
                var pendingBlasts = await _emailBlastRepository.GetPendingEmailBlastsAsync(cancellationToken);
                foreach (var blast in pendingBlasts)
                {
                    if (blast.Template == null)
                    {
                        _logger.LogWarning($"Could not send blast with id {blast.Id}: template id was null");
                        continue;
                    }

                    if (blast.Customer == null)
                    {
                        _logger.LogWarning($"Could not send blast with id {blast.Id}: customer id was null");
                        continue;
                    }

                    try
                    {
                        var template = await _templateRepository.GetByIdAsync(blast.Template, cancellationToken);
                        if (template == null)
                        {
                            _logger.LogWarning(
                                $"Could not send blast with id {blast.Id}: template with id {blast.Template} not found");
                            await MarkBlastAsErrored(blast, cancellationToken); 
                            continue;
                        }

                        var customer = await _customerRepository.GetByIdAsync(blast.Customer, cancellationToken);
                        if (customer == null)
                        {
                            _logger.LogWarning($"Could not send email blast with id {blast.Id}: customer not found");
                            await MarkBlastAsErrored(blast, cancellationToken);
                            continue;
                        }

                        var recipients =
                            await _recipientRepository.GetRecipientsForCustomer(blast.Customer, cancellationToken);

                        await ProcessBlast(template, customer, recipients, cancellationToken);

                        blast.Status = "Delivered";
                        await _emailBlastRepository.UpdateAsync(blast, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Could not send email blast for blast {blast.Id}");
                    }
                }
            }
        }

        private async Task MarkBlastAsErrored(EmailBlast blast, CancellationToken cancellationToken)
        {
            blast.Status = "Error";
            await _emailBlastRepository.UpdateAsync(blast, cancellationToken);
        }

        private async Task MarkBlastAsSuccess(EmailBlast blast, CancellationToken cancellationToken)
        {
            blast.Status = "Success";
            await _emailBlastRepository.UpdateAsync(blast, cancellationToken);
        }

        private async Task ProcessBlast(Template template, Customer customer, List<EmailRecipient> recipients, CancellationToken cancellationToken)
        {
            foreach (var recipient in recipients)
            {
                if (recipient.Email == null)
                {
                    _logger.LogWarning($"Could not deliver email to recipient {recipient.Name}: no email address");
                    continue;
                }

                var mailMessage = new MailMessage("no-reply@publisherclearinghouse.com", recipient.Email)
                {
                    Body = await _templateEngine.MergeTemplate(template, customer, recipient, cancellationToken),
                    IsBodyHtml = true
                };

                await _smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}