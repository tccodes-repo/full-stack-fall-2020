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
        private readonly IEmailBlastUpdateQueue _emailBlastUpdateQueue;
        private readonly ILogger<EmailProcessingService> _logger;

        private IScheduler? _scheduler;

        public EmailProcessingService(ISchedulerFactory schedulerFactory, IEmailBlastRepository repository,
            IEmailBlastUpdateQueue emailBlastUpdateQueue, ILogger<EmailProcessingService>? logger = null) 
        {
            _schedulerFactory = schedulerFactory;
            _emailBlastRepository = repository;
            _emailBlastUpdateQueue = emailBlastUpdateQueue;
            _logger = logger ?? NullLogger<EmailProcessingService>.Instance;
        }

        
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            // reset our queue
            await _emailBlastUpdateQueue.ResetQueue();

            // create a scheduler 
            _scheduler = await _schedulerFactory.GetScheduler();
            
            // get all of our email blasts.
            var emailBlasts = await _emailBlastRepository.GetAllAsync();

            // loop over them and create scheduled jobs based on cron
            foreach(var blast in emailBlasts) 
            {
                await ScheduleBlast(blast, cancellationToken);
            }

            await _scheduler.Start();

            // wait until system stops.
            await MonitorForChanges(cancellationToken);
        }

        private async Task MonitorForChanges(CancellationToken cancellationToken) 
        {
            if(_scheduler == null) {
                throw new Exception("Scheduler should not be null");
            }

            while(cancellationToken.WaitHandle.WaitOne(TimeSpan.FromSeconds(1)) == false) {
                var change = await _emailBlastUpdateQueue.DequeueUpdateAsync(cancellationToken);
                if (change != null) {
                    var blast = await _emailBlastRepository.GetByIdAsync(change.EmailBlastId);

                    if(blast == null) {
                        _logger.LogWarning($"Blast with id '{change.EmailBlastId}' no longer exists");
                        continue;
                    }

                    await _scheduler.UnscheduleJob(new TriggerKey($"EmailDeliveryTrigger_{blast.Id}", "email"));
                    await ScheduleBlast(blast, cancellationToken);
                    await _emailBlastUpdateQueue.ChangeProcessed(change);
                }
            }
        }

        private async Task ScheduleBlast(EmailBlast blast, CancellationToken cancellationToken) 
        {
            if (_scheduler == null) {
                throw new Exception("Scheduler should not be null");
            }

            try {
                var jobDetails = new JobDetailImpl($"EmailDeliver_{blast.Id}", typeof(EmailDeliveryJob));
                jobDetails.JobDataMap["blastId"] = blast.Id ?? "";

                var trigger = new CronTriggerImpl($"EmailDeliveryTrigger_{blast.Id}", "email", blast.Schedule);

                await _scheduler.ScheduleJob(jobDetails, trigger, cancellationToken);
            } 
            catch (Exception ex) 
            {
                _logger.LogWarning(ex, "Couldn't schedule blast");
            }
        }
    }

}