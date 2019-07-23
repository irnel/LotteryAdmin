using System;
using System.Collections.Generic;

namespace Lottery.Core.ServiceModels
{
    public class LotteryEvent
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public int TotalCards { get; set; }
        public int AvailableCards { get; set; }
        public int CardPrice { get; set; }
        public int Award { get; set; }
        public Card WinnerCard { get; set; }
        public string EventProgress { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
