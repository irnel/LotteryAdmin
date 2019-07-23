using System.Collections.Generic;
using System.Threading.Tasks;
using Lottery.Data.AbstractRepositories;
using Lottery.Data.Entities;
using Lottery.Infrastructure.AppContext;
using Lottery.Infrastructure.Repositories.Base;
using System.Linq;
using System.Data.Entity;


namespace Lottery.Infrastructure.Repositories
{
    public class CardRepository : Repository<CardEntity>, ICardRepository
    {
        public CardRepository(IDbContext context) : base(context)
        {
           
        }
    }
}
