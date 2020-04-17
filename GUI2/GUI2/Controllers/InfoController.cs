using GUI2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var excheckins = await _context.Breakfasts.FirstOrDefaultAsync(m => m.Date == DateTime.Today);

            int adultCheckIns = 0;
            int kidCheckIns = 0;

            foreach (var item in tempinf)
            {
                adultCheckIns += item.NumberOfAdults;
                kidCheckIns += item.NumberOfKids;
            }

            List<int> ting = new List<int> { excheckins.NumberOfOrders, adultCheckIns, kidCheckIns, (excheckins.NumberOfOrders - (adultCheckIns + kidCheckIns)) };

            return View(ting);
        }
    }
}