using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace Emailer
{
    public class EmailDeliveryService : ScopedBackgroundService
    {
       
        
        public EmailDeliveryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override async Task DoWorkAsync(CancellationToken cancellationToken)
        {
            while(true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                
                await Console.Out.WriteAsync("Send Email");
                await Task.Delay(3000, cancellationToken);
            }
        }
    }
}