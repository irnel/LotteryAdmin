using AutoMapper;
using Lottery.Core.ServiceModels;
using Lottery.Core.ViewModels;
using Lottery.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Infrastructure.Helpers
{
    public class EventHelper
    {
        public static string GetProgress(DateTime startDate, string startTime, long? winnerCardId)
        {
            var eventProgress = string.Empty;
            var time = DateTime.Parse(startTime);

            var eventStartDate = new DateTime(
                startDate.Year, startDate.Month, startDate.Day,
                time.Hour, time.Minute, time.Second);

            if (DateTime.Now >= eventStartDate && winnerCardId == null)
            {
                eventProgress = "In progress";
            }
            else if (DateTime.Now >= eventStartDate && winnerCardId != null)
            {
                eventProgress = "Closed";
            }
            else
            {
                eventProgress = "Available";
            }            

            return eventProgress;
        }

        public static string GetBackgroundProgress(string eventType)
        {
            var background = string.Empty;
            if (eventType.Equals("Available"))
            {
                background = "bg-available";
            }
            else if (eventType.Equals("In progress"))
            {
                background = "bg-in-progress";
            }
            else
            {
                background = "bg-closed";
            }

            return background;
        }

        public static ICollection<Card> GenerateLotteryCards(int cant)
        {
            var cards = new List<Card>();

            for (int i = 0; i < cant; i++)
                cards.Add(new Card { IsAvailable = true });
            
            return cards;
        }

        public static ICollection<CardEntity> GenerateLotteryCardEntities(int cant)
        {
            var entities = new List<CardEntity>();
        
            for (int i = 0; i < cant; i++)
                entities.Add(new CardEntity { IsAvailable = true });

            return entities;
        }

        public static Card SelectedWinner(IEnumerable<Card> cards)
        {
            var r = new Random();
            var index = r.Next(cards.Count() - 1);

            return cards.ElementAt(index);
        }
    }
}
