using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Handin2.Models
{
    public class Guest
    {
        public int GuestId { get; set; }

        public string Name { get; set; }

        [Display(Name = "Do you want to eat?")]
        public bool WontToEaten { get; set; }

        [Display(Name = "Child?")]
        public bool IsChild { get; set; }

        [Display(Name = "Checked in?")]
        public bool IsCheckIn { get; set; }

        [Display(Name = "Date dd/mm")]
        public string GuestDate { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

    }
}
