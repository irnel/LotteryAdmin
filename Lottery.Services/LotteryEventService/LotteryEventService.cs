using AutoMapper;
using Lottery.Core.ServiceModels;
using Lottery.Data.AbstractRepositories;
using Lottery.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Services.LotteryEventService
{
    public class LotteryEventService : ILotteryEventService
    {
        private readonly ILotteryEventRepository eventRepository;
        private readonly ICardRepository cardRepository;
        private readonly IMapper mapper;

        public LotteryEventService(
            ILotteryEventRepository eventRepository, 
            ICardRepository cardRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.cardRepository = cardRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LotteryEvent>> GetAllEventsAsync()
        {
            var eventEntities = await eventRepository.GetAllAsync();
            return mapper.Map(eventEntities, new List<LotteryEvent>());  
        }

        public async Task<LotteryEvent> GetByIdAsync(long? id)
        {
            var eventEntity = await eventRepository.GetByIdAsync(id);
            return mapper.Map<LotteryEvent>(eventEntity);
        }

        public async Task<IEnumerable<LotteryEvent>> GetAllEventsByTypeAsync(string eventProgressType)
        {
            var eventEntities = await eventRepository.GetAllAsync();
            var eventsLottery = mapper.Map(eventEntities, new List<LotteryEvent>());

            return eventsLottery
                .Where(e => e.EventProgress.ToLower() == eventProgressType.ToLower());
        }

       
        public async Task<int> EventsByProgessTypeCountAsync(string eventProgressType)
        {
            var eventsEntities = await GetAllEventsByTypeAsync(eventProgressType);
            return eventsEntities.Count();
        }

        public void AddLotteryEventAsync(LotteryEvent model)
        {
            eventRepository.Add(mapper.Map<LotteryEventEntity>(model));
        }

        public async Task<bool> UpdateLotteryEventAsync(LotteryEvent model)
        {
            return await eventRepository.UpdateAsync(mapper.Map<LotteryEventEntity>(model));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await eventRepository.SaveChangesAsync();
        }
    }
}
