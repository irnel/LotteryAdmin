using Lottery.Data.Entities.Base;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Lottery.Infrastructure.AppContext
{
    public interface IDbContext
    {
        DbContext BaseDbContext { get; }
        DbSet<T> Set<T>() where T : class;
        Task<bool> SaveChangesAsync();
    }
}