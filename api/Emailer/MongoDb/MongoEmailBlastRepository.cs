using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Emailer.MongoDb
{
    public class MongoEmailBlastRepository : MongoRepository<EmailBlast>, IEmailBlastRepository
    {
        public MongoEmailBlastRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<List<EmailBlast>> GetPendingEmailBlastsAsync(CancellationToken cancellationToken = default)
        {
            return await Database.GetCollection<EmailBlast>(GetCollectionName())
                .Find(x => x.Status == "Pending")
                .ToListAsync(cancellationToken);
        }
    }
}