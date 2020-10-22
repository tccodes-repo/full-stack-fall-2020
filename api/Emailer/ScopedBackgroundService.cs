using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Emailer
{
    public class ScopedBackgroundService<T> : BackgroundService
        where T : IBackgroundTask
    {
        private readonly IServiceProvider _serviceProvider;

        public ScopedBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
            
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var scopedTask = (IBackgroundTask)scope.ServiceProvider.GetRequiredService<T>();
            await scopedTask.ExecuteAsync(stoppingToken);
        }
    }
}