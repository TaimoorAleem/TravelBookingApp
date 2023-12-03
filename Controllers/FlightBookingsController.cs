using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBookingApp.Models;
using TravelBookingApp.Models.Data_Access_Layer;

namespace TravelBookingApp.Controllers
{
    public class FlightBookingsController : Controller
    {
        private readonly RihlaDbContext _context;

        public FlightBookingsController(RihlaDbContext context)
        {
            _context = context;
        }

        // GET: FlightBookings
        public async Task<IActionResult> Index()
        {
            var rihlaDbContext = _context.FlightBookings.Include(f => f.Flight);
            return View(await rihlaDbContext.ToListAsync());
        }

        // GET: FlightBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlightBookings == null)
            {
                return NotFound();
            }

            var flightBooking = await _context.FlightBookings
                .Include(f => f.Flight)
                .FirstOrDefaultAsync(m => m.FlightBookingId == id);
            if (flightBooking == null)
            {
                return NotFound();
            }

            return View(flightBooking);
        }

        // GET: FlightBookings/Create
        public IActionResult Create()
        {
            ViewData["FlightBookingId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode");
            return View();
        }

        // POST: FlightBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightBookingId,Fcategory,FBookingClass")] FlightBooking flightBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightBookingId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode", flightBooking.FlightBookingId);
            return View(flightBooking);
        }

        // GET: FlightBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlightBookings == null)
            {
                return NotFound();
            }

            var flightBooking = await _context.FlightBookings.FindAsync(id);
            if (flightBooking == null)
            {
                return NotFound();
            }
            ViewData["FlightBookingId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode", flightBooking.FlightBookingId);
            return View(flightBooking);
        }

        // POST: FlightBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightBookingId,Fcategory,FBookingClass")] FlightBooking flightBooking)
        {
            if (id != flightBooking.FlightBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightBookingExists(flightBooking.FlightBookingId))
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
            ViewData["FlightBookingId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode", flightBooking.FlightBookingId);
            return View(flightBooking);
        }

        // GET: FlightBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlightBookings == null)
            {
                return NotFound();
            }

            var flightBooking = await _context.FlightBookings
                .Include(f => f.Flight)
                .FirstOrDefaultAsync(m => m.FlightBookingId == id);
            if (flightBooking == null)
            {
                return NotFound();
            }

            return View(flightBooking);
        }

        // POST: FlightBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlightBookings == null)
            {
                return Problem("Entity set 'RihlaDbContext.FlightBookings'  is null.");
            }
            var flightBooking = await _context.FlightBookings.FindAsync(id);
            if (flightBooking != null)
            {
                _context.FlightBookings.Remove(flightBooking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightBookingExists(int id)
        {
          return (_context.FlightBookings?.Any(e => e.FlightBookingId == id)).GetValueOrDefault();
        }
    }
}
