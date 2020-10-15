using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Emailer
{
    public interface IRepository<T> where T : Model
    {

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        
        Task AddAsync(T item, CancellationToken cancellationToken = default);

        Task UpdateAsync(T item, CancellationToken cancellationToken = default);

        Task DeleteAsync(T item, CancellationToken cancellationToken = default);

    }
}