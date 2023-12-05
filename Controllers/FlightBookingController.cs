// FlightBookingController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelBookingApp.Models;
using TravelBookingApp.Models.Data_Access_Layer;

public class FlightBookingController : Controller
{
    private readonly RihlaDbContext _context;

    public FlightBookingController(RihlaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var bookings = _context.FlightBookings.Include(b => b.Flight).ToList();
        return View(bookings);
    }

    public IActionResult Create()
    {
        // Implement logic to populate dropdowns or other necessary data
        return View();
    }

    [HttpPost]
    public IActionResult Create(FlightBooking booking)
    {
        if (ModelState.IsValid)
        {
            _context.FlightBookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("Index", "Flight");
        }

        return View(booking);
    }
}
