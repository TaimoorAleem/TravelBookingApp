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

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.FlightBookings.Include(f => f.Flight).ToListAsync();
            return View(bookings);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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

        public IActionResult Create()
        {
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightBookingId,FlightId,Email,PassportNumber,PhoneNumber,NumberOfCompanions,FlightClass")] FlightBooking flightBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode", flightBooking.FlightId);
            return View(flightBooking);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightBooking = await _context.FlightBookings.FindAsync(id);
            if (flightBooking == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode", flightBooking.FlightId);
            return View(flightBooking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightBookingId,FlightId,Email,PassportNumber,PhoneNumber,NumberOfCompanions,FlightClass")] FlightBooking flightBooking)
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
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "AirlineCode", flightBooking.FlightId);
            return View(flightBooking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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

        public IActionResult SelectFlight()
        {
            var flights = SampleFlightData.Flights;
            return View(flights);
        }

        public IActionResult Book(int flightId)
        {
            var flight = SampleFlightData.Flights.FirstOrDefault(f => f.FlightId == flightId);
            if (flight == null)
            {
                return NotFound();
            }

            var booking = new FlightBooking { Flight = flight, FlightId = flightId };
            return View(booking);
        }

        [HttpPost]
        public IActionResult Book(FlightBooking booking)
        {
            if (ModelState.IsValid)
            {
                _context.FlightBookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var flight = SampleFlightData.Flights.FirstOrDefault(f => f.FlightId == booking.FlightId);
            booking.Flight = flight;
            return View(booking);
        }
    }
}
