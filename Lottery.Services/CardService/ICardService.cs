using Lottery.Core.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Services.CardService
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllAvailableAsync();
        Task<IEnumerable<Card>> GetAllCardsByEventIdAsync(long eventId);
        Task<IEnumerable<Card>> GetAllAvailableCardsByEventIdAsync(long? eventId);
        Task<Card> GetCardByIdAsync(long id);
        Task<bool> UpdateCardAsync(Card card);
        Task<bool> SaveChangesAsync();
    }
}
