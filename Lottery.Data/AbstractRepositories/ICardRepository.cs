using System.Collections.Generic;
using System.Threading.Tasks;
using Lottery.Data.AbstractRepositories.Base;
using Lottery.Data.Entities;

namespace Lottery.Data.AbstractRepositories
{
    public interface ICardRepository : IRepository<CardEntity>
    {
    }
}
