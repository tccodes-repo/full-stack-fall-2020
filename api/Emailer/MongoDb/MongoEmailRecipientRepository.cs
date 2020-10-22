using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Emailer.MongoDb
{
    public class MongoEmailRecipientRepository : MongoRepository<EmailRecipient>, IEmailRecipientRepository
    {
        public MongoEmailRecipientRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<List<EmailRecipient>> GetRecipientsForCustomer(string customerId, 
            CancellationToken cancellationToken = default)
        {
            return await Database.GetCollection<EmailRecipient>(GetCollectionName())
                .Find(x => x.Customer == customerId)
                .ToListAsync(cancellationToken);
        }
    }
}