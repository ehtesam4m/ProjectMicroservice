using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Command.Application.Common.Interfaces;

namespace Project.Command.Infrastructure
{
    public class Repository<T, TIdentifier> : IRepository<T, TIdentifier>
        where T : class
    {
        protected readonly DbSet<T> repoDbSet;
        protected readonly DataBaseContext dbContext;
        public Repository(DataBaseContext databaseContext)
        {
            dbContext = databaseContext;
            repoDbSet = databaseContext.Set<T>();
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await repoDbSet.AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(T entity)
        {
            repoDbSet.Update(entity);

            await Task.CompletedTask;
        }

        public async Task<T> GetAsync(TIdentifier id)
        {
            return await repoDbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await repoDbSet.ToListAsync();
        }

    }
}
