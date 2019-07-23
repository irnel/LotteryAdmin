using System;
using System.Collections.Generic;
using Lottery.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lottery.Data.Entities
{
    [Table("Cards")]
    public class CardEntity : BaseEntity
    {
        public bool IsAvailable { get; set; }
        public long? LotteryEventId { get; set; }

        public virtual LotteryEventEntity LotteryEvent { get; set; }
    }
}
