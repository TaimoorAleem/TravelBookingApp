// FlightController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using TravelBookingApp.Models;
using TravelBookingApp.Models.Data_Access_Layer;

public class FlightController : Controller
{
    private readonly RihlaDbContext _context;

    public FlightController(RihlaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var flights = _context.Flights.ToList();
        return View(flights);
    }

    public IActionResult Book(int id)
    {
        var flight = _context.Flights.Find(id);
        var booking = new FlightBooking { FlightId = id, Flight = flight };
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

        var flight = _context.Flights.Find(booking.FlightId);
        booking.Flight = flight;
        return View(booking);
    }
}
