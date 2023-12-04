using Microsoft.AspNetCore.Mvc;
using TravelBookingApp.Models.Data_Access_Layer;

public class FlightController : Controller
{
    private readonly RihlaDbContext _context;

    public FlightController(RihlaDbContext context)
    {
        _context = context;
    }

    public IActionResult Create(string email, string flightType, string departureLocation, string arrivalLocation, DateTime departureDate, DateTime arrivalDate)
    {
        // Query flights based on filtered parameters
        var matchingFlights = _context.Flights.Where(f => f.DepartureLocation == departureLocation &&
        f.ArrivalLocation == arrivalLocation &&
        f.DepartureDateTime.Date == departureDate.Date).ToList();

        return View(matchingFlights);
    }
}

