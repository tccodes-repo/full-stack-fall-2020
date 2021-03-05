using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Quartz;

namespace Emailer {

    public class EmailDeliveryJob : IJob
    {

        private readonly IEmailBlastDeliverer _deliverer;
        private readonly ILogger<EmailDeliveryJob> _logger;

        public EmailDeliveryJob(IEmailBlastDeliverer deliverer, ILogger<EmailDeliveryJob>? logger = null) 
        {
            _deliverer = deliverer;
            _logger = logger ?? NullLogger<EmailDeliveryJob>.Instance;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var blast = (EmailBlast)context.JobDetail.JobDataMap["blast"];
            _logger.LogDebug($"Delivering Emails for Blast '{blast.Id})'");
            await _deliverer.DeliverBlast(blast);
        }
    }
}