using AutoMapper;
using Lottery.Infrastructure.Helpers;
using Lottery.Core.ServiceModels;
using Lottery.Core.ViewModels;
using Lottery.Services.LotteryEventService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lottery.Services.CardService;

namespace Lottery.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILotteryEventService eventService;
        private readonly ICardService cardService;
        private readonly IMapper mapper;

        public EventsController(
            ILotteryEventService eventService, ICardService cardService, IMapper mapper)
        {
            this.eventService = eventService;
            this.cardService = cardService;
            this.mapper = mapper;
        }

        
        public async Task<ActionResult> Index()
        {
            var lotteryEvents = await eventService.GetAllEventsAsync();
            var eventsViewModel = mapper.Map(lotteryEvents, new List<LotteryEventViewModel>());

            ViewBag.EventsAvailable = await eventService.EventsByProgessTypeCountAsync("Available");
            ViewBag.EventsInProgress = await eventService.EventsByProgessTypeCountAsync("In progress");
            ViewBag.EventsClosed = await eventService.EventsByProgessTypeCountAsync("Closed");

            return View(eventsViewModel);
        }
        
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 

            var lotteryEvent = await eventService.GetByIdAsync(id);
            if (lotteryEvent == null) return HttpNotFound();

            var eventViewModel = mapper.Map<LotteryEventViewModel>(lotteryEvent);
            ViewBag.BtnEditVisible = eventViewModel.WinnerCard == null ? true : false;
            ViewBag.BackgroundProgress = EventHelper.GetBackgroundProgress(eventViewModel.EventProgress);

            return View(eventViewModel);
        }

        // GET: Events/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LotteryEventViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lotteryEvent = mapper.Map<LotteryEvent>(data);
                    lotteryEvent.Cards = EventHelper.GenerateLotteryCards(lotteryEvent.TotalCards);

                    eventService.AddLotteryEventAsync(lotteryEvent);
                    await eventService.SaveChangesAsync();

                    TempData["success"] = true;
                    TempData["msg"] = "Lottery Events created successfully";

                    return RedirectToAction("Index");
                }

                return View(data);
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var eventLottery = await eventService.GetByIdAsync(id);
            if (eventLottery == null)
                return HttpNotFound();

            if (eventLottery.EventProgress.Equals("Closed"))
                return RedirectToAction("Index");
            
            var eventViewModel = mapper.Map<LotteryEventViewModel>(eventLottery);
            ViewBag.BackgroundProgress = EventHelper.GetBackgroundProgress(eventViewModel.EventProgress);
            
            return View(eventViewModel);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LotteryEventViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lotteryEvent = mapper.Map<LotteryEvent>(data);

                    await eventService.UpdateLotteryEventAsync(lotteryEvent);
                    await eventService.SaveChangesAsync();

                    TempData["success"] = true;
                    TempData["msg"] = "Lottery Event edited successfully";

                    return RedirectToAction("Index");
                }

                return View(data);
            }
            catch
            {
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SelectedWinner(LotteryEventViewModel model)
        {
            var cards = await cardService.GetAllCardsByEventIdAsync(model.Id);
            var lotteryEvent = mapper.Map<LotteryEvent>(model);
            lotteryEvent.WinnerCard = EventHelper.SelectedWinner(cards);

            await eventService.UpdateLotteryEventAsync(lotteryEvent);
            await eventService.SaveChangesAsync();

            TempData["success"] = true;
            TempData["msg"] = "Selected winner card successfully";

            return Json(new HttpStatusCodeResult(HttpStatusCode.NoContent));
        }
    }
}
