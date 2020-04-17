using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI2.Models
{
    public class Breakfast
    {
        [Required]
        [Display(Name = "Number of orders")]
        public int NumberOfOrders { get; set; }

        [Key]
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
    }
}
