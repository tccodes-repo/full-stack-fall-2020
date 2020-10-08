using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace Emailer
{
    public abstract class ScopedBackgroundService : BackgroundService
    {
        protected IServiceProvider _serviceProvider;
        protected IServiceProvider? _scopedServiceProvider;

        public ScopedBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
            
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            _scopedServiceProvider = scope.ServiceProvider;
            await DoWorkAsync(stoppingToken);
        }

        protected abstract Task DoWorkAsync(CancellationToken cancellationToken);

    }
}