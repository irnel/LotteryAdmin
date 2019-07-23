namespace Lottery.Infrastructure.Migrations
{
    using Lottery.Data.Entities;
    using Lottery.Infrastructure.Helpers;
    using Lottery.Infrastructure.AppContext;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SQLDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SQLDbContext context)
        {
            var r = new Random();
            var lotteryEvents = new List<LotteryEventEntity>()
            {
                new LotteryEventEntity
                {
                    Id = 1,
                    StartDate = DateTime.Now.AddDays(1).Date,
                    StartTime = DateTime.Now.AddHours(1).ToString("h:mm tt"),
                    Cards = EventHelper.GenerateLotteryCardEntities(r.Next(1000, 9000)),
                    CardPrice = r.Next(20, 100)
                },
                new LotteryEventEntity
                {
                    Id = 2,
                    StartDate = DateTime.Now.AddDays(1).Date,
                    StartTime = DateTime.Now.AddHours(2).ToString("h:mm tt"),
                    Cards = EventHelper.GenerateLotteryCardEntities(r.Next(1000, 9000)),
                    CardPrice = r.Next(20, 100)
                },
                new LotteryEventEntity
                {
                    Id = 3,
                    StartDate = DateTime.Now.AddDays(4).Date,
                    StartTime = DateTime.Now.AddHours(1).ToString("h:mm tt"),
                    Cards = EventHelper.GenerateLotteryCardEntities(r.Next(1000, 9000)),
                    CardPrice = r.Next(20, 100)
                },
                new LotteryEventEntity
                {
                    Id = 4,
                    StartDate = DateTime.Now.Date,
                    StartTime = DateTime.Now.AddHours(3).ToString("h:mm tt"),
                    Cards = EventHelper.GenerateLotteryCardEntities(r.Next(1000, 9000)),
                    CardPrice = r.Next(20, 100)
                },
                new LotteryEventEntity
                {
                    Id = 5,
                    StartDate = DateTime.Now.Date,
                    StartTime = DateTime.Now.ToString("h:mm tt"),
                    Cards = EventHelper.GenerateLotteryCardEntities(r.Next(1000, 9000)),
                    CardPrice = r.Next(20, 100)
                }
            };

            context.Set<LotteryEventEntity>().AddRange(lotteryEvents);
        }
    }
}
