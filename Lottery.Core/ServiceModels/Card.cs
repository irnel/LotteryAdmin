using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Core.ServiceModels
{
    public class Card
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public long LotteryEventId { get; set; }
    }
}
