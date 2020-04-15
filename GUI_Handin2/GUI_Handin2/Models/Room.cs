using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Handin2.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Display(Name = "Room number")]
        public int Number { get; set; }

        public virtual List<Guest> Guests { get; set; }
    }
}
