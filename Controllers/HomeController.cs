using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TravelBookingApp.Models;
using TravelBookingApp.Models.Data_Access_Layer;

namespace TravelBookingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly RihlaDbContext _context;

        public HomeController(RihlaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve booking data from the database
            // var flightBookings = _context.FlightBookings.ToList();
            //var hotelBookings = _context.HotelBookings.ToList();
            var carBookings = _context.CarBookings.ToList();

            // Create instances of your view model and populate its properties
            var viewModel = new BookingViewModel
            {
                // FlightBookings = flightBookings,
                // HotelBookings = hotelBookings,
                CarBookings = carBookings
            };

            // Pass the view model to the view
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}