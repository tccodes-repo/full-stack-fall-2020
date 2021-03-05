using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Emailer.SMTP;
using Emailer.Templates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;


namespace Emailer
{

    public interface IEmailBlastDeliverer {
        Task DeliverBlast(EmailBlast blast, CancellationToken cancellationToken = default(CancellationToken));
    }

    public class EmailBlastDeliverer : IEmailBlastDeliverer
    {

        private readonly IEmailBlastRepository _emailBlastRepository;
        private readonly ITemplateEngine _templateEngine;
        private readonly IEmailRecipientRepository _recipientRepository;
        private readonly IRepository<Template> _templateRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly ISmtpClient _smtpClient;
        private readonly ILogger<EmailBlastDeliverer> _logger;
        
        public EmailBlastDeliverer(IEmailBlastRepository emailBlastRepository, ITemplateEngine templateEngine,
            IEmailRecipientRepository recipientRepository, IRepository<Template> templateRepository,
            IRepository<Customer> customerRepository, ISmtpClient smtpClient, 
            ILogger<EmailBlastDeliverer>? logger = null)
        {
            _emailBlastRepository = emailBlastRepository;
            _templateEngine = templateEngine;
            _recipientRepository = recipientRepository;
            _templateRepository = templateRepository;
            _customerRepository = customerRepository;
            _smtpClient = smtpClient;
            _logger = logger ?? NullLogger<EmailBlastDeliverer>.Instance;
        }

        public async Task DeliverBlast(EmailBlast blast, CancellationToken cancellationToken)
        {
    
            _logger.LogInformation($"Processing email blast with id {blast.Id}");
            
            if (blast.Template == null)
            {
                throw new Exception($"Could not send blast with id {blast.Id}: template id was null");
            }

            if (blast.Customer == null)
            {
                throw new Exception($"Could not send blast with id {blast.Id}: customer id was null");
            }

            var template = await _templateRepository.GetByIdAsync(blast.Template, cancellationToken);
            if (template == null)
            {
                await MarkBlastAsErrored(blast, cancellationToken); 
                throw new Exception($"Could not send blast with id {blast.Id}: template with " +
                    $"id {blast.Template} not found");
            }

            var customer = await _customerRepository.GetByIdAsync(blast.Customer, cancellationToken);
            if (customer == null)
            {
                await MarkBlastAsErrored(blast, cancellationToken);
                throw new Exception($"Could not send email blast with id {blast.Id}: " +
                                    $"customer not found");
            }

            try
            {                
                _logger.LogInformation($"Delivering email blast with template '{template.Name}' " +
                                        $"for customer '{customer.FirstName} {customer.LastName}'");

                var recipients =
                    await _recipientRepository.GetRecipientsForCustomer(blast.Customer, cancellationToken);

                await ProcessBlast(template, customer, recipients, cancellationToken);
                await MarkBlastAsDelivered(blast, recipients.Count, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not send email blast for blast {blast.Id}");
                await MarkBlastAsErrored(blast, cancellationToken);
            }
        }

        private async Task MarkBlastAsErrored(EmailBlast blast, CancellationToken cancellationToken)
        {
            blast.Status = "Error";
            blast.StatusChangedOn = DateTime.Now;
            await _emailBlastRepository.UpdateAsync(blast, cancellationToken);
        }

        private async Task MarkBlastAsDelivered(EmailBlast blast, int sent, CancellationToken cancellationToken)
        {
            blast.Status = "Delivered";
            blast.EmailsDelivered = sent;
            blast.StatusChangedOn = DateTime.Now;
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