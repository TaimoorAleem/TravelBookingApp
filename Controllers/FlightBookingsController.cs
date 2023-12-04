using Microsoft.AspNetCore.Mvc;
using TravelBookingApp.Models;

public class FlightBookingsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(FlightBooking input)
    {
        // Validate input and filter flights
        // Redirect to FlightController with filtered parameters
        return RedirectToAction("Create", "Flight", new { input.Email, input.FlightType, input.DepartureLocation, input.ArrivalLocation, input.DepartureDate, input.ArrivalDate });
    }
}
