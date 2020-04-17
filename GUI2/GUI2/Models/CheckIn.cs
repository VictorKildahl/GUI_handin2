using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI2.Models
{
    public class CheckIn
    {
        [Key]
        public DateTime Date { get; set; }

        [Required]
        public int Room { get; set; }

        [Required]
        [Display(Name = "Number of adults")]
        public int NumberOfAdults { get; set; }

        [Required]
        [Display(Name = "Number of kids")]
        public int NumberOfKids { get; set; }

    }
}
