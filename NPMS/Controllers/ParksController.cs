using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPMS.Models;

namespace NPMS.Controllers
{
    
    public class ParksController : Controller
    {
        private readonly NPMSContext _context;

        public ParksController(NPMSContext context)
        {
            _context = context;
        }

        // GET: Parks
        public async Task<IActionResult> Index()
        {
              return View(await _context.Parks.ToListAsync());
        }

        // GET: Parks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parks == null)
            {
                return NotFound();
            }

            var parks = await _context.Parks
                .FirstOrDefaultAsync(m => m.ParkId == id);
            if (parks == null)
            {
                return NotFound();
            }

            return View(parks);
        }

        // GET: Parks/Create
        //[Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkId,ParkName,ParkDescription,ParkImageUrl")] Parks parks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parks);
        }
        [Authorize(Roles = "Admins")]
        // GET: Parks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parks == null)
            {
                return NotFound();
            }

            var parks = await _context.Parks.FindAsync(id);
            if (parks == null)
            {
                return NotFound();
            }
            return View(parks);
        }

        [Authorize(Roles = "Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkId,ParkName,ParkDescription,ParkImageUrl")] Parks parks)
        {
            if (id != parks.ParkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParksExists(parks.ParkId))
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
            return View(parks);
        }

        // GET: Parks/Delete/5
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parks == null)
            {
                return NotFound();
            }

            var parks = await _context.Parks
                .FirstOrDefaultAsync(m => m.ParkId == id);
            if (parks == null)
            {
                return NotFound();
            }

            return View(parks);
        }

        // POST: Parks/Delete/5
        [Authorize(Roles = "Admins")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parks == null)
            {
                return Problem("Entity set 'NPMSContext.Parks'  is null.");
            }
            var parks = await _context.Parks.FindAsync(id);
            if (parks != null)
            {
                _context.Parks.Remove(parks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParksExists(int id)
        {
          return _context.Parks.Any(e => e.ParkId == id);
        }
    }
}
