using Lottery.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Data.Entities
{
    [Table("LotteryEvents")]
    public class LotteryEventEntity : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public int CardPrice { get; set; }
        public long? WinnerCardId { get; set; }
        public virtual ICollection<CardEntity> Cards { get; set; }
    }
}
