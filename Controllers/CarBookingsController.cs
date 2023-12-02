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
    public class CarBookingsController : Controller
    {
        private readonly RihlaDbContext _context;

        public CarBookingsController(RihlaDbContext context)
        {
            _context = context;
        }

        // GET: CarBookings
        public async Task<IActionResult> Index()
        {
              return _context.CarBookings != null ? 
                          View(await _context.CarBookings.ToListAsync()) :
                          Problem("Entity set 'RihlaDbContext.CarBookings'  is null.");
        }

        // GET: CarBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarBookings == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carBooking == null)
            {
                return NotFound();
            }

            return View(carBooking);
        }

        // GET: CarBookings/Create
        public IActionResult Create()
        {
            ViewBag.Cars = new SelectList(_context.Cars, "CarId", "Make");
            return View();
        }

        // POST: CarBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pickup,Dropoff,PickupTime,DropoffTime,CarId")] CarBooking carBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Cars = new SelectList(_context.Cars, "CarId", "Make", carBooking.CarId);
            return View(carBooking);
        }

        // GET: CarBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarBookings == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings.FindAsync(id);
            if (carBooking == null)
            {
                return NotFound();
            }
            return View(carBooking);
        }

        // POST: CarBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pickup,Dropoff,PickupTime,DropoffTime")] CarBooking carBooking)
        {
            if (id != carBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarBookingExists(carBooking.Id))
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
            return View(carBooking);
        }

        // GET: CarBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarBookings == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carBooking == null)
            {
                return NotFound();
            }

            return View(carBooking);
        }

        // POST: CarBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarBookings == null)
            {
                return Problem("Entity set 'RihlaDbContext.CarBookings'  is null.");
            }
            var carBooking = await _context.CarBookings.FindAsync(id);
            if (carBooking != null)
            {
                _context.CarBookings.Remove(carBooking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarBookingExists(int id)
        {
          return (_context.CarBookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
