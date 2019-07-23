using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lottery.Core.ViewModels
{
    public class LotteryEventViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Start time")]
        public string StartTime { get; set; }

        [Required]
        [Display(Name = "Cards")]
        [Range(50, 10000, ErrorMessage = "Must be at least 50")]
        public int TotalCards { get; set; }
            
        [Display(Name = "Available")]
        public int AvailableCards { get; set; }

        [Required]
        [Display(Name = "Card Price")]
        [DataType(DataType.Currency)]
        public int CardPrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Award { get; set; }

        [Display(Name = "Winner")]
        public CardViewModel WinnerCard { get; set; }
         
        [Display(Name = "Progress")]
        public string EventProgress { get; set; }

        // public IList<CardViewModel> Cards { get; set; }
    }
}
