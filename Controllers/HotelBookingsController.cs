using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBookingApp.Models;
using TravelBookingApp.Models.Data_Access_Layer;

namespace TravelBookingApp.Controllers
{
    public class HotelBookingsController : Controller
    {
        private readonly RihlaDbContext _context;

        public HotelBookingsController(RihlaDbContext context)
        {
            _context = context;
        }

        // GET: HotelBookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.HotelBookings.Include(h => h.Hotel).ToListAsync();
            return View(bookings);
        }

        // GET: HotelBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBooking = await _context.HotelBookings
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.HotelBookingId == id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return View(hotelBooking);
        }

        // GET: HotelBookings/Create
        public IActionResult Create()
        {
            ViewBag.Hotels = _context.Hotels.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelBooking hotelBooking)
        {
            if (ModelState.IsValid)
            {
                // Determine the HotelId based on user's selection
                // For example, if the user selects the first hotel, set HotelId to 1
                hotelBooking.HotelId = hotelBooking.HotelId; // Adjust this line according to your actual logic

                _context.Add(hotelBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Confirmation), new { id = hotelBooking.HotelBookingId });
            }

            // If model state is not valid, return the form view
            return View("CreateBooking", hotelBooking);
        }


        // GET: HotelBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBooking = await _context.HotelBookings.FindAsync(id);
            if (hotelBooking == null)
            {
                return NotFound();
            }
            ViewBag.Hotels = _context.Hotels.ToList();
            return View(hotelBooking);
        }

        // GET: HotelBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBooking = await _context.HotelBookings
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.HotelBookingId == id);
            if (hotelBooking == null)
            {
                return NotFound();
            }

            return View(hotelBooking);
        }

        // POST: HotelBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelBooking = await _context.HotelBookings.FindAsync(id);

            if (hotelBooking != null)
            {
                _context.HotelBookings.Remove(hotelBooking);
                await _context.SaveChangesAsync();
                // If you reach this point, the deletion was requested.
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool HotelBookingExists(int id)
        {
            return _context.HotelBookings.Any(e => e.HotelBookingId == id);
        }

        public IActionResult SelectHotel()
        {
            var hotels = SampleHotelData.Hotels;
            return View(hotels);
        }

        public IActionResult CreateBooking(int hotelId)
        {
            var hotel = SampleHotelData.Hotels.FirstOrDefault(h => h.HotelId == hotelId);
            if (hotel == null)
            {
                // Handle the situation when hotel is not found in the sample data.
                // You could return a "NotFound" view or set an error message.
                return NotFound("Hotel information is not available.");
            }

            var booking = new HotelBooking { HotelId = hotelId, Hotel = hotel };
            return View(booking);
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var hotelBooking = await _context.HotelBookings.Include(hb => hb.Hotel).FirstOrDefaultAsync(hb => hb.HotelBookingId == id);
            if (hotelBooking == null)
            {
                // Handle the situation when the booking is not found.
                return NotFound("Booking not found.");
            }

            if (hotelBooking.Hotel == null)
            {
                // This means the hotel info was not loaded or doesn't exist in your database or sample data.
                return NotFound("Hotel information is not available.");
            }

            return View(hotelBooking);
        }
    }
}









