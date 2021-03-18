using System;
using System.Threading;
using System.Threading.Tasks;

namespace Emailer {

    public interface IEmailBlastUpdateQueue 
    {

        Task EnqueueUpdateAsync(EmailBlastUpdate update);

        Task<EmailBlastUpdate?> DequeueUpdateAsync(CancellationToken cancellationToken = default);

        Task ChangeProcessed(EmailBlastUpdate update);

        Task ResetQueue();
    }

}