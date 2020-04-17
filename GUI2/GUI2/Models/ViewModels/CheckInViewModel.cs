using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI2.Models.ViewModels
{
    public class CheckInViewModel
    {
        [Required]
        public int Room { get; set; }
        [Required]
        public int NumberOfAdults { get; set; }
        [Required]
        public int NumberOfKids { get; set; }
    }
}
