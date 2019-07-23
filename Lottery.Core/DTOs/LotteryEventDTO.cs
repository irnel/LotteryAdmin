using Lottery.Core.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Core.DTOs
{
    public class LotteryEventDTO
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public int CardPrice { get; set; }
        public int Award { get; set; }
        public string EventProgress { get; set; }
        public Card WinnerCard { get; set; }
    }
}
