using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI2.Data;
using GUI2.Models;
using Microsoft.AspNetCore.Authorization;

namespace GUI2.Controllers
{
    [Authorize("isWaiter")]
    public class CheckInsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckInsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckIns
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckIns.ToListAsync());
        }

        // GET: CheckIns/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIns
                .FirstOrDefaultAsync(m => m.Date == id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return View(checkIn);
        }

        // GET: CheckIns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Room,NumberOfAdults,NumberOfKids")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                checkIn.Date = DateTime.Now;
                _context.Add(checkIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkIn);
        }

        // GET: CheckIns/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIns.FindAsync(id);
            if (checkIn == null)
            {
                return NotFound();
            }
            return View(checkIn);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("Date,Room,NumberOfAdults,NumberOfKids")] CheckIn checkIn)
        {
            if (id != checkIn.Date)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckInExists(checkIn.Date))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(checkIn);
        }

        // GET: CheckIns/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIns
                .FirstOrDefaultAsync(m => m.Date == id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return View(checkIn);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var checkIn = await _context.CheckIns.FindAsync(id);
            _context.CheckIns.Remove(checkIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckInExists(DateTime id)
        {
            return _context.CheckIns.Any(e => e.Date == id);
        }
    }
}
