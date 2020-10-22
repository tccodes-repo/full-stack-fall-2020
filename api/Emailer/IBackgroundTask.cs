using System.Threading;
using System.Threading.Tasks;

namespace Emailer
{
    public interface IBackgroundTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}