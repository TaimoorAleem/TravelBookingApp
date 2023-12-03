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

        // POST: HotelBookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,UserId,CheckInDate,CheckOutDate,NumberOfGuests,SpecialRequest")] HotelBooking hotelBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Hotels = _context.Hotels.ToList();
            return View(hotelBooking);
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

        // POST: HotelBookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelBookingId,HotelId,UserId,CheckInDate,CheckOutDate,NumberOfGuests,Price,SpecialRequest")] HotelBooking hotelBooking)
        {
            if (id != hotelBooking.HotelBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelBookingExists(hotelBooking.HotelBookingId))
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
            _context.HotelBookings.Remove(hotelBooking);
            await _context.SaveChangesAsync();
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
            var hotel = SampleHotelData.Hotels.FirstOrDefault(h => h.HotelId == hotelId); // Replace with database fetch if needed
            var booking = new HotelBooking { Hotel = hotel, HotelId = hotelId };
            return View(booking);
        }


    }
}









