using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Emailer {

    public class MongoDbEmailBlastUpdateQueue : IEmailBlastUpdateQueue
    {

        private readonly IMongoDatabase _database;

        public MongoDbEmailBlastUpdateQueue(IMongoDatabase database) 
        {
            _database = database;
        }

        public async Task ChangeProcessed(EmailBlastUpdate update)
        {
            var col = _database.GetCollection<EmailBlastUpdate>("queue");
            await col.DeleteOneAsync(x => x.Id == update.Id);
        }

        public async Task<EmailBlastUpdate?> DequeueUpdateAsync(CancellationToken cancellationToken = default)
        {
            var col = _database.GetCollection<EmailBlastUpdate>("queue");
            return await col.Find(Builders<EmailBlastUpdate>.Filter.Empty).FirstOrDefaultAsync();
        }

        public async Task EnqueueUpdateAsync(EmailBlastUpdate update)
        {
            var col = _database.GetCollection<EmailBlastUpdate>("queue");
            await col.InsertOneAsync(update);
        }

        public async Task ResetQueue()
        {
            var col = _database.GetCollection<EmailBlastUpdate>("queue");
            await col.DeleteManyAsync(Builders<EmailBlastUpdate>.Filter.Empty);
        }
    }

}