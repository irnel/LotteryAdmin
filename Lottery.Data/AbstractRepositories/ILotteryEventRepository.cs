using Lottery.Data.AbstractRepositories.Base;
using Lottery.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Data.AbstractRepositories
{
    public interface ILotteryEventRepository : IRepository<LotteryEventEntity>
    {
        
    }
}
