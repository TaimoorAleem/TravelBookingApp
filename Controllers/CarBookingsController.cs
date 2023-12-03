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
            List<Car> cars = _context.Cars.ToList();
            ViewBag.Cars = cars.Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = $"{car.Make} \t {car.Model} \t {car.Year} , \n  City: {car.City} , \n Capacity: {car.Capacity}"
            }).ToList();

            return View();
        }

        // POST: CarBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarBooking carBooking)
        {
            
            _context.Add(carBooking);
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
            return RedirectToAction("Index","Home");

            // Repopulate the ViewBag.Cars with SelectList for the dropdown list
            List<Car> cars = _context.Cars.ToList();
            ViewBag.Cars = cars.Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = $"Make: {car.Make} | Model: {car.Model} | Year: {car.Year} | City: {car.City} | Capacity: {car.Capacity}"
            }).ToList();

            return View(carBooking);
        }


        // GET: CarBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBooking = await _context.CarBookings.FindAsync(id);
            if (carBooking == null)
            {
                return NotFound();
            }

            // Include the cars for the dropdown list
            List<Car> cars = _context.Cars.ToList();
            ViewBag.Cars = cars.Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = $"Make: {car.Make} - Model: {car.Model} - Year: {car.Year} - City: {car.City} - Capacity: {car.Capacity}",
                Selected = car.Id == carBooking.CarId
            }).ToList();

            return View(carBooking);
        }

        // POST: CarBookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,Pickup,Dropoff,PickupTime,DropoffTime")] CarBooking carBooking)
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
                    return RedirectToAction(nameof(Index));
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
            }

            // Include the cars for the dropdown list in case of validation errors
            List<Car> cars = _context.Cars.ToList();
            ViewBag.Cars = cars.Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = $"Make: {car.Make} - Model: {car.Model} - Year: {car.Year} - City: {car.City} - Capacity: {car.Capacity}",
                Selected = car.Id == carBooking.CarId
            }).ToList();

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
