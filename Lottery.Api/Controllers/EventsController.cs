using AutoMapper;
using Lottery.Core.DTOs;
using Lottery.Core.ServiceModels;
using Lottery.Services.CardService;
using Lottery.Services.LotteryEventService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lottery.Infrastructure.Controllers
{
    /// <summary>
    /// Event controller
    /// </summary>
    /// 
    [RoutePrefix("api/events")]
    public class EventsController : ApiController
    {
        private readonly ILotteryEventService eventService;
        private readonly ICardService cardService;
        private IMapper mapper;

        /// <summary></summary>
        /// <param name="eventService"></param>
        /// <param name="cardService"></param>
        /// <param name="mapper"></param>
        public EventsController(
            ILotteryEventService eventService, ICardService cardService, IMapper mapper)
        {
            this.eventService = eventService;
            this.cardService = cardService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all lottery events
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IEnumerable<LotteryEventDTO>> GetAllEventsAsync()
        {
            var events = await eventService.GetAllEventsAsync();
            return mapper.Map(events, new List<LotteryEventDTO>());
        }

        /// <summary>
        /// Get Lottery Event by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetByIdAsync(long id)
        {
            var lotteryEvent = await eventService.GetByIdAsync(id);
            if (lotteryEvent == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<LotteryEventDTO>(lotteryEvent));
        }

        /// <summary>
        /// Get all available cards by lottery event id
        /// </summary>
        /// <param name="id">Lottery event id param</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("{id:long}/cards/available")]
        public async Task<IHttpActionResult> GetAllAvailableCardsByEventIdAsync(long id)
        {
            var lotteryEvent = await eventService.GetByIdAsync(id);
            if (lotteryEvent == null)
            {
                return NotFound();
            }

            var cards = await cardService.GetAllAvailableCardsByEventIdAsync(id);
            return Ok(cards);
        }

        /// <summary>
        /// Get all lottery events by specific event progress
        /// </summary>
        /// <param name="eventProgressType">
        /// There are 3 types { Available, In progress, Closed }
        /// </param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("{eventProgressType}")]
        public async Task<IEnumerable<LotteryEventDTO>> GetAllEventsByTypeAsync(string eventProgressType)
        {
            var events = await eventService.GetAllEventsByTypeAsync(eventProgressType);
            return mapper.Map(events, new List<LotteryEventDTO>());
        }

        /// <summary>
        /// Count all available events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("available/count")]
        public async Task<int> AvailableEventsCountAsync()
        {
            return await eventService.EventsByProgessTypeCountAsync("Available");
        }
    }
}
