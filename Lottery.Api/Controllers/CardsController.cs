using Lottery.Core.ServiceModels;
using Lottery.Services.CardService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lottery.Api.Controllers
{
    /// <summary>
    /// Cards Controller
    /// </summary>
    /// 
    [RoutePrefix("api/cards")]
    public class CardsController : ApiController
    {
        private readonly ICardService cardService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cardService"></param>
        /// 
        public CardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        /// <summary>
        /// Get card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetCardByIdAsync(long id)
        {
            var card = await cardService.GetCardByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        /// <summary>
        /// Update Card available status
        /// </summary>
        /// <param name="card">LotteryEventId is optional</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStatusCardAsync([FromBody] Card card)
        {
            var currentCard = await cardService.GetCardByIdAsync(card.Id);
            if (currentCard == null)
            {
                return NotFound();
            }

            if (card.LotteryEventId != currentCard.LotteryEventId)
            {
                return BadRequest("Invalid attribute LotteryEventId");
            }

            await cardService.UpdateCardAsync(card);
            var result = await cardService.SaveChangesAsync();

            return Ok(result);
        }
    }
}
