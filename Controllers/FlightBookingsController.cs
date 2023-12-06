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
            return _context.FlightBookings != null ?
                        View(await _context.FlightBookings.ToListAsync()) :
                        Problem("Entity set 'RihlaDbContext.FlightBookings'  is null.");
        }

        // GET: FlightBookings/Details/5
        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null || _context.FlightBookings == null)
            {
                return NotFound();
            }

            var FlightBooking = await _context.FlightBookings
                .FirstOrDefaultAsync(m => m.FlightBookingId == Id);
            if (FlightBooking == null)
            {
                return NotFound();
            }

            return View(FlightBooking);
        }

        // GET: FlightBookings/Create
        public IActionResult Create()
        {

            List<Flight> Flights = _context.Flights.ToList();
            ViewBag.Flights = Flights.Select(Flight => new SelectListItem
            {
                Value = Flight.FlightId.ToString(),
                Text = $"{Flight.AirlineName} \t {Flight.AirlineDescription} \t {Flight.AirlineCode}"
            }).ToList();

            return View();
        }

        // POST: FlightBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkFlightBookingId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightBooking FlightBooking)
        {

            _context.Add(FlightBooking);
            await _context.SaveChangesAsync();



            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    // Log or debug the error messages
                    var errorMessage = error.ErrorMessage;
                    var exception = error.Exception;

                    // Add your logging mechanism here, for example, logging to the console
                    Console.WriteLine($"ModelState Error: {errorMessage}");
                }
            }
            //return RedirectToAction("Detail",new {FlightBookingId = FlightBooking.FlightBookingId});

            // Repopulate the ViewBag.Flights with SelectList for the dropdown list
            List<Flight> Flights = _context.Flights.ToList();
            ViewBag.Flights = Flights.Select(Flight => new SelectListItem
            {
                Value = Flight.FlightId.ToString(),
                Text = $"AirlineName: {Flight.AirlineName} | Model: {Flight.AirlineCode} | AirlineDescription: {Flight.AirlineDescription}"
            }).ToList();

            //return View(FlightBooking
            return RedirectToAction("Index", new { FlightBookingId = FlightBooking.FlightBookingId });
        }


        // GET: FlightBookings/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var FlightBooking = await _context.FlightBookings.FindAsync(Id);
            if (FlightBooking == null)
            {
                return NotFound();
            }

            // Include the Flights for the dropdown list
            List<Flight> Flights = _context.Flights.ToList();
            ViewBag.Flights = Flights.Select(Flight => new SelectListItem
            {
                Value = Flight.FlightId.ToString(),
                Text = $"AirlineName: {Flight.AirlineName} | Model: {Flight.AirlineCode} | AirlineDescription: {Flight.AirlineDescription}",
                Selected = Flight.FlightId == FlightBooking.FlightBookingId
            }).ToList();

            return View(FlightBooking);
        }

        // POST: FlightBookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("FlightBookingId,FlightId,Name,Email,PassportNumber,PhoneNumber,NumberofCompanions,FlightClass")] FlightBooking FlightBooking)
        {
            if (Id != FlightBooking.FlightBookingId)
            {
                return NotFound();
            }
            _context.Update(FlightBooking);
            await _context.SaveChangesAsync();
            

            List<Flight> Flights = _context.Flights.ToList();
            ViewBag.FlightBookings = Flights.Select(Flight => new SelectListItem
            {
                Value = Flight.FlightId.ToString(),
                Text = $"AirlineName: {Flight.AirlineName} | Model: {Flight.AirlineCode} | AirlineDescription: {Flight.AirlineDescription}",
                Selected = Flight.FlightId == FlightBooking.FlightBookingId
            }).ToList();

            return RedirectToAction("Index");



            // Include the Flights for the dropdown list in case of valFlightBookingIdation errors

        }


        // GET: FlightBookings/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || _context.FlightBookings == null)
            {
                return NotFound();
            }

            var FlightBooking = await _context.FlightBookings
                .FirstOrDefaultAsync(m => m.FlightBookingId == Id);
            if (FlightBooking == null)
            {
                return NotFound();
            }

            return View(FlightBooking);
        }

        // POST: FlightBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            if (_context.FlightBookings == null)
            {
                return Problem("Entity set 'RihlaDbContext.FlightBookings'  is null.");
            }
            var FlightBooking = await _context.FlightBookings.FindAsync(Id);
            if (FlightBooking != null)
            {
                _context.FlightBookings.Remove(FlightBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FlightBookingExists(int FlightBookingId)
        {
            return (_context.FlightBookings?.Any(e => e.FlightBookingId == FlightBookingId)).GetValueOrDefault();
        }
    }
}
