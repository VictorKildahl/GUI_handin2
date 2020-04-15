using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_Handin2.Data;
using GUI_Handin2.Models;

namespace GUI_Handin2.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var childreninRoom1 = _context.Guests.Where(g => g.IsChild == true).Where(g => g.RoomId == 1).ToList();
            int childrenCountinRoom1 = childreninRoom1.Count;
            ViewData["ChildrenCountinRoom1"] = childrenCountinRoom1;

            var childreninRoom2 = _context.Guests.Where(g => g.IsChild == true).Where(g => g.RoomId == 2).ToList();
            int childrenCountinRoom2 = childreninRoom2.Count;
            ViewData["ChildrenCountinRoom2"] = childrenCountinRoom2;

            var childreninRoom3 = _context.Guests.Where(g => g.IsChild == true).Where(g => g.RoomId == 3).ToList();
            int childrenCountinRoom3 = childreninRoom3.Count;
            ViewData["ChildrenCountinRoom3"] = childrenCountinRoom3;

            var childreninRoom4 = _context.Guests.Where(g => g.IsChild == true).Where(g => g.RoomId == 4).ToList();
            int childrenCountinRoom4 = childreninRoom4.Count;
            ViewData["ChildrenCountinRoom4"] = childrenCountinRoom4;

            var childreninRoom5 = _context.Guests.Where(g => g.IsChild == true).Where(g => g.RoomId == 5).ToList();
            int childrenCountinRoom5 = childreninRoom5.Count;
            ViewData["ChildrenCountinRoom5"] = childrenCountinRoom5;

            var children = _context.Guests.Where(g => g.IsChild == true).ToList();
            int childrenCount = children.Count;
            ViewData["ChildrenCount"] = childrenCount;

            var parents = _context.Guests.Where(g => g.IsChild == false).ToList();
            int parentsCount = parents.Count;
            ViewData["ParentsCount"] = parentsCount;

            return View(await _context.Rooms.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,Number")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,Number")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }
    }
}
