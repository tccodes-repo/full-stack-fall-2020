using Quartz;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using Quartz.Impl;

namespace Emailer {

    public class EmailerSchedulerFactory : StdSchedulerFactory
    {

        private readonly IServiceProvider _serviceProvider;

        public EmailerSchedulerFactory(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public override Task<IScheduler> GetScheduler(CancellationToken cancellationToken = default)
        {
            return this.GetScheduler("DefaultScheduler", cancellationToken)!;
        }

        public override async Task<IScheduler?> GetScheduler(string schedName, CancellationToken cancellationToken = default)
        {
            var scheduler = await base.GetScheduler(cancellationToken);
            if (scheduler == null) return null;
            scheduler.JobFactory = new EmailerJobFactory(_serviceProvider);
            return scheduler;
        }

        
    }

    public class EmailerJobFactory : IJobFactory
    {

        private readonly IServiceProvider _serviceProvider;

        public EmailerJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;    
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var scope = _serviceProvider.CreateScope();
            return (IJob)scope.ServiceProvider.GetRequiredService(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
            
        }
    }
}