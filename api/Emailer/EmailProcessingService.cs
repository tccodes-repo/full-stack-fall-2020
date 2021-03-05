using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace Emailer {

    public class EmailProcessingService : IBackgroundTask
    {

        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IEmailBlastRepository _emailBlastRepository;
        private readonly ILogger<EmailProcessingService> _logger;

        private IScheduler? _scheduler;

        public EmailProcessingService(ISchedulerFactory schedulerFactory, IEmailBlastRepository repository,
            ILogger<EmailProcessingService>? logger = null) 
        {
            _schedulerFactory = schedulerFactory;
            _emailBlastRepository = repository;
            _logger = logger ?? NullLogger<EmailProcessingService>.Instance;
        }

        
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            // create a scheduler 
            _scheduler = await _schedulerFactory.GetScheduler();
            
            // get all of our email blasts.
            var emailBlasts = await _emailBlastRepository.GetAllAsync();

            // loop over them and create scheduled jobs based on cron
            foreach(var blast in emailBlasts) 
            {
                try {
                    var jobDetails = new JobDetailImpl($"EmailDeliver_{blast.Id}", typeof(EmailDeliveryJob));
                    jobDetails.JobDataMap["blast"] = blast;

                    var trigger = new CronTriggerImpl($"EmailDeliveryTrigger_{blast.Id}", "email", blast.Schedule);

                    await _scheduler.ScheduleJob(jobDetails, trigger, cancellationToken);
                } 
                catch (Exception ex) 
                {
                    _logger.LogWarning(ex, "Couldn't schedule blast");
                }
            }

            await _scheduler.Start();

            // wait until system stops.
            cancellationToken.WaitHandle.WaitOne();
        }
    }

}