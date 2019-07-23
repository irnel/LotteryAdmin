using Lottery.Data.AbstractRepositories;
using Lottery.Data.Entities;
using Lottery.Infrastructure.AppContext;
using Lottery.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Lottery.Infrastructure.Helpers;
using System.Globalization;

namespace Lottery.Infrastructure.Repositories
{
    public class LotteryEventRepository : Repository<LotteryEventEntity>, ILotteryEventRepository
    {
        public LotteryEventRepository(IDbContext context) : base(context)
        {
                        
        }
    }
}
