using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI2.Models.ViewModels
{
    public class ReceptionInfoViewModel
    {
        [Key]
        [Required]
        public DateTime Date { get; set; }
    }
}
