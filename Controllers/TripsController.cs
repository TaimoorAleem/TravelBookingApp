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
    public class TripsController : Controller
    {
        private readonly RihlaDbContext _context;

        public TripsController(RihlaDbContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var rihlaDbContext = _context.Trips.Include(t => t.User);
            return View(await rihlaDbContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "City");

            // Populate the form input with all available flights, hotels, and cars
            var model = new Booking
            {
                AllFlights = _context.Flights.ToList(),
                AllHotels = _context.Hotels.ToList(),
                AllCars = _context.Cars.ToList()
            };

            return View(model);
        }

        // POST: Trips/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking trip)
        {
            if (ModelState.IsValid)
            {
                // Set the user ID for the trip
                trip.UserId = int.Parse(ViewData["UserId"].ToString());

                // Load the selected flights, hotels, and cars based on their IDs
                trip.Flights = _context.Flights.Where(f => trip.SelectedFlights.Contains(f.FlightId)).ToList();
                trip.Hotels = _context.Hotels.Where(h => trip.SelectedHotels.Contains(h.HotelId)).ToList();
                trip.Cars = _context.Cars.Where(c => trip.SelectedCars.Contains(c.CarId)).ToList();

                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If the model state is not valid, repopulate the lists and return to the view
            trip.AllFlights = _context.Flights.ToList();
            trip.AllHotels = _context.Hotels.ToList();
            trip.AllCars = _context.Cars.ToList();

            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "City", trip.UserId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.User)
                .Include(t => t.Flights)
                .Include(t => t.Hotels)
                .Include(t => t.Cars)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (trip == null)
            {
                return NotFound();
            }

            // Populate the available flights, hotels, and cars
            trip.AllFlights = _context.Flights.ToList();
            trip.AllHotels = _context.Hotels.ToList();
            trip.AllCars = _context.Cars.ToList();

            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "City", trip.UserId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking trip)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Load the selected flights, hotels, and cars based on their IDs
                    trip.Flights = _context.Flights.Where(f => trip.SelectedFlights.Contains(f.FlightId)).ToList();
                    trip.Hotels = _context.Hotels.Where(h => trip.SelectedHotels.Contains(h.HotelId)).ToList();
                    trip.Cars = _context.Cars.Where(c => trip.SelectedCars.Contains(c.CarId)).ToList();

                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.Id))
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

            // If the model state is not valid, repopulate the lists and return to the view
            trip.AllFlights = _context.Flights.ToList();
            trip.AllHotels = _context.Hotels.ToList();
            trip.AllCars = _context.Cars.ToList();

            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "City", trip.UserId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trips == null)
            {
                return Problem("Entity set 'RihlaDbContext.Trips' is null.");
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return (_context.Trips?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
