using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Command.Application.Common.Interfaces
{
    public interface IRepository<T, TIdentifier> where T : class
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity);

        Task<T> GetAsync(TIdentifier id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
