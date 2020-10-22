using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Emailer
{
    public interface IEmailBlastRepository : IRepository<EmailBlast>
    {
        Task<List<EmailBlast>> GetPendingEmailBlastsAsync(CancellationToken cancellationToken = default);
    }
}