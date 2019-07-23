using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lottery.Infrastructure.AppContext;

namespace Lottery.Web.Controllers
{
    public class LotteryEventsController : Controller
    {
    //    private SQLDbContext db = new SQLDbContext();

    //    // GET: LotteryEvents
    //    public ActionResult Index()
    //    {
    //        return View(db.LotteryEvents.ToList());
    //    }

    //    // GET: LotteryEvents/Details/5
    //    public ActionResult Details(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        LotteryEvent lotteryEvent = db.LotteryEvents.Find(id);
    //        if (lotteryEvent == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(lotteryEvent);
    //    }

    //    // GET: LotteryEvents/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: LotteryEvents/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Id,StartDate,StartTime")] LotteryEvent lotteryEvent)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.LotteryEvents.Add(lotteryEvent);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(lotteryEvent);
    //    }

    //    // GET: LotteryEvents/Edit/5
    //    public ActionResult Edit(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        LotteryEvent lotteryEvent = db.LotteryEvents.Find(id);
    //        if (lotteryEvent == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(lotteryEvent);
    //    }

    //    // POST: LotteryEvents/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "Id,StartDate,StartTime")] LotteryEvent lotteryEvent)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(lotteryEvent).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(lotteryEvent);
    //    }

    //    // GET: LotteryEvents/Delete/5
    //    public ActionResult Delete(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        LotteryEvent lotteryEvent = db.LotteryEvents.Find(id);
    //        if (lotteryEvent == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(lotteryEvent);
    //    }

    //    // POST: LotteryEvents/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(long id)
    //    {
    //        LotteryEvent lotteryEvent = db.LotteryEvents.Find(id);
    //        db.LotteryEvents.Remove(lotteryEvent);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    }
}
