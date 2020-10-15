using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Emailer
{
    public class MongoRepository<T> : IRepository<T> where T : Model
    {

        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoDatabase database)
        {
            _database = database;
        }
        
        
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _database.GetCollection<T>("customers")
                .Find(Builders<T>.Filter.Empty)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            await _database.GetCollection<T>("customers")
                .InsertOneAsync(item, new InsertOneOptions(), cancellationToken);
        }

        public async Task UpdateAsync(T item, CancellationToken cancellationToken = default)
        {
            await _database.GetCollection<T>("customers")
                .ReplaceOneAsync(
                Builders<T>.Filter.Eq(x => x.Id, item.Id),
                item, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(T item, CancellationToken cancellationToken = default)
        {
            await _database.GetCollection<T>("customers").DeleteOneAsync(
                Builders<T>.Filter.Eq(x => x.Id, item.Id));
        }
    }
}