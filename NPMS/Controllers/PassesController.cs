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
    
    public class PassesController : Controller
    {
        private readonly NPMSContext _context;
        private readonly ILogger<PassesController> _logger;

        public PassesController(NPMSContext context, ILogger<PassesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Passes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Passes.ToListAsync());
        }

        // GET: Passes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passes == null)
            {
                return NotFound();
            }

            var passes = await _context.Passes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passes == null)
            {
                return NotFound();
            }

            return View(passes);
        }

        // GET: Passes/Create
        [Authorize(Roles = "Admins")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Create([Bind("Id,PassName,PassPrice")] Passes passes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passes);
        }

        // GET: Passes/Edit/5
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passes == null)
            {
                return NotFound();
            }

            var passes = await _context.Passes.FindAsync(id);
            if (passes == null)
            {
                return NotFound();
            }
            var username = HttpContext.User.Identity.Name;
            _logger.LogWarning((EventId)200, "{passid} edited by {user} on {date}", id, username, DateTime.UtcNow);
            return View(passes);
        }

        // POST: Passes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PassName,PassPrice")] Passes passes)
        {
            if (id != passes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassesExists(passes.Id))
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
            return View(passes);
        }

        // GET: Passes/Delete/5
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passes == null)
            {
                return NotFound();
            }

            var passes = await _context.Passes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passes == null)
            {
                return NotFound();
            }
            var username = HttpContext.User.Identity.Name;
            _logger.LogWarning((EventId)201, "{passid} deleted by {user} on {date}", id, username, DateTime.UtcNow);

            return View(passes);
        }

        // POST: Passes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passes == null)
            {
                return Problem("Entity set 'NPMSContext.Passes'  is null.");
            }
            var passes = await _context.Passes.FindAsync(id);
            if (passes != null)
            {
                _context.Passes.Remove(passes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassesExists(int id)
        {
          return _context.Passes.Any(e => e.Id == id);
        }

        [Authorize]
        public async Task<IActionResult> BuyPass()
        {
            return View();
        }
    }
}
