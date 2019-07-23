using Lottery.Data.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Lottery.Infrastructure.AppContext
{
    public class SQLDbContext : DbContext, IDbContext
    {
        protected virtual DbSet<CardEntity> Cards { get; set; }
        protected virtual DbSet<LotteryEventEntity> LotteryEvents { get; set; }

        public DbContext BaseDbContext => this;

        public SQLDbContext() : base("name=LotteryContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async new Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
