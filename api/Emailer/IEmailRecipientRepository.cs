using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Emailer
{
    public interface IEmailRecipientRepository : IRepository<EmailRecipient>
    {
        Task<List<EmailRecipient>> GetRecipientsForCustomer(string customerId,
            CancellationToken cancellationToken = default);
    }
}