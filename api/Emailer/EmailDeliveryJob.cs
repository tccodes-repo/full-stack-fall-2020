using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Quartz;

namespace Emailer {

    public class EmailDeliveryJob : IJob
    {

        private readonly IEmailBlastDeliverer _deliverer;

        private readonly IEmailBlastRepository _repository;
        private readonly ILogger<EmailDeliveryJob> _logger;

        public EmailDeliveryJob(IEmailBlastDeliverer deliverer, IEmailBlastRepository repository, ILogger<EmailDeliveryJob>? logger = null) 
        {
            _deliverer = deliverer;
            _repository = repository;
            _logger = logger ?? NullLogger<EmailDeliveryJob>.Instance;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var blastId = (string)context.JobDetail.JobDataMap["blastId"];
            var blast = await _repository.GetByIdAsync(blastId);
            if (blast == null) {
                _logger.LogWarning($"Blast with id '{blastId}' no longer exists.");
                return;
            }
            _logger.LogDebug($"Delivering Emails for Blast '{blastId})'");
            await _deliverer.DeliverBlast(blast);
        }
    }
}