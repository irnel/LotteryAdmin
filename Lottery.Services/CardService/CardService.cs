using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lottery.Core.ServiceModels;
using Lottery.Data.AbstractRepositories;
using Lottery.Data.Entities;

namespace Lottery.Services.CardService
{
    public class CardService : ICardService
    {
        private readonly ICardRepository cardRepository;
        private readonly IMapper mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            this.cardRepository = cardRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Card>> GetAllCardsByEventIdAsync(long eventId)
        {
            var entities = await cardRepository.FindAsync(c => c.LotteryEventId == eventId);
            return mapper.Map(entities, new List<Card>());
        }

        public async Task<IEnumerable<Card>> GetAllAvailableAsync()
        {
            var entities = await (
                cardRepository.FindAsync(
                    card => card.IsAvailable && card.LotteryEventId == null));

            return mapper.Map(entities, new List<Card>());
        }

        public async Task<IEnumerable<Card>> GetAllAvailableCardsByEventIdAsync(long? eventId)
        {
            var cardEntities = await (
                cardRepository.FindAsync(
                    card => card.IsAvailable && card.LotteryEventId == eventId));

            return mapper.Map(cardEntities, new List<Card>());
        }

        public async Task<Card> GetCardByIdAsync(long id)
        {
            var entity = await cardRepository.GetByIdAsync(id);
            return mapper.Map<Card>(entity);
        }

        public async Task<bool> UpdateCardAsync(Card card)
        {
            var entity = mapper.Map<CardEntity>(card);
            return await cardRepository.UpdateAsync(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await cardRepository.SaveChangesAsync();
        }
    }
}
