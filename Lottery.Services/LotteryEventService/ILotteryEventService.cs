using Lottery.Core.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Services.LotteryEventService
{
    public interface ILotteryEventService
    {
        Task<LotteryEvent> GetByIdAsync(long? id);
        Task<IEnumerable<LotteryEvent>> GetAllEventsAsync();
        Task<IEnumerable<LotteryEvent>> GetAllEventsByTypeAsync(string eventProgressType);
        Task<int> EventsByProgessTypeCountAsync(string eventProgressType);
        void AddLotteryEventAsync(LotteryEvent model);
        Task<bool> UpdateLotteryEventAsync(LotteryEvent model);
        Task<bool> SaveChangesAsync();
    }
}
