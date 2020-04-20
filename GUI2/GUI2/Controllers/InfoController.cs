using GUI2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI2.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize("isWaiter")]
        public async Task<IActionResult> ReceptionInfo()
        {
            return View(await _context.CheckIns.Where(x => x.Date.Date == DateTime.Today).ToListAsync());
        }

        [Authorize("isKitchen")]
        public async Task<IActionResult> KitchenInfo()
        {
            var tempinf = await _context.CheckIns.Where(x => x.Date.Date == DateTime.Today).ToListAsync();
            var tempexcheckins = await _context.Breakfasts.Where(m => m.Date.Date == DateTime.Today).ToListAsync();

            int excheckins = 0;
            int adultCheckIns = 0;
            int kidCheckIns = 0;

            foreach (var item in tempexcheckins)
            {
                excheckins += item.NumberOfOrders;
            }

            foreach (var item in tempinf)
            {
                adultCheckIns += item.NumberOfAdults;
                kidCheckIns += item.NumberOfKids;
            }

            List<int> ting = new List<int> { excheckins, adultCheckIns, kidCheckIns, (excheckins - (adultCheckIns + kidCheckIns)) };

            return View(ting);
        }
    }
}