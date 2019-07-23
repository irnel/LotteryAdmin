using System.ComponentModel.DataAnnotations;

namespace Lottery.Data.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public long? Id { get; set; }
    }
}
