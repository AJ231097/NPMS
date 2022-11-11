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
    public class ReservationsController : Controller
    {
        private readonly NPMSContext _context;

        public ReservationsController(NPMSContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Admins")]
        // GET: Reservations
        public async Task<IActionResult> Index()
        {
              return View(await _context.Reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Rid == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // GET: Reservations/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Rid,ReservationName,TypeOfEvent,ContactNumber,ReservationEmail,ReservationDate,ParkName")] Reservations reservations)
        {
            if (ModelState.IsValid)
            {
                reservations.Rid = Guid.NewGuid();
                _context.Add(reservations);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return View("ReservationSuccess");
            }
            return View("ReservationSuccess");
        }

        // GET: Reservations/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.Reservations == null)
        //    {
        //        return NotFound();
        //    }

        //    var reservations = await _context.Reservations.FindAsync(id);
        //    if (reservations == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(reservations);
        //}

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Rid,ReservationName,TypeOfEvent,ContactNumber,ReservationEmail,ReservationDate,ParkName")] Reservations reservations)
        //{
        //    if (id != reservations.Rid)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(reservations);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReservationsExists(reservations.Rid))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(reservations);
        //}

        // GET: Reservations/Delete/5
        [Authorize(Roles ="Admins")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Rid == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'NPMSContext.Reservations'  is null.");
            }
            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations != null)
            {
                _context.Reservations.Remove(reservations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationsExists(Guid id)
        {
          return _context.Reservations.Any(e => e.Rid == id);
        }
    }
}
