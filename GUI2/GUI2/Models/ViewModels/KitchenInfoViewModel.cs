using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI2.Models.ViewModels
{
    public class KitchenInfoViewModel
    {
        public int ExpectedCheckIn { get; set; }
        public int AdultCheckIns { get; set; }
        public int KidsCheckIns { get; set; }
        public int NotCheckedIn { get; set; }
    }
}
