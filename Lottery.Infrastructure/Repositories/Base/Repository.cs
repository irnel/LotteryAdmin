using Lottery.Data.AbstractRepositories.Base;
using Lottery.Data.Entities.Base;
using Lottery.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lottery.Infrastructure.Repositories.Base
{

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected IDbContext DbContext { get; }
        protected DbSet<T> DbSet { get; }

        public Repository(IDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public void Add(T item)
        {
            DbSet.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            DbSet.AddRange(items);
        }

        public async Task<bool> UpdateAsync(T item)
        {
            var entity = await GetByIdAsync(item.Id);

            DbContext.BaseDbContext.Entry(entity).CurrentValues.SetValues(item);
            return DbContext.BaseDbContext.Entry(entity).State != EntityState.Unchanged;
        }

        public async Task<bool> RemoveAsync(long? id)
        {
            var item = await GetByIdAsync(id);
            var itemRemoved = DbSet.Remove(item);

            if (itemRemoved == null)
            {
                return false;
            }

            return true;
        }

        public async Task<T> GetByIdAsync(long? id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public IQueryable<T> AsQueryable()
        {
            return DbSet.AsQueryable();
        }
    }
}
