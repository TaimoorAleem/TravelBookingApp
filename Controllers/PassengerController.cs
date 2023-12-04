using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBookingApp.Models;
using TravelBookingApp.Models.Data_Access_Layer;

public class PassengerController : Controller
{
    private readonly RihlaDbContext _context;

    public PassengerController(RihlaDbContext context)
    {
        _context = context;
    }

    public IActionResult Create(int flightId)
    {
        // Pass flight details to the view
        var flight = _context.Flights.Include(f => f.FlightBookings).FirstOrDefault(f => f.Id == flightId);

        // Initialize the Passengers list
        var passengerViewModel = new Passenger
        {
            Flight = flight,
            Passengers = new List<Passenger>()
        };

        // Add an initial empty passenger (optional)
        passengerViewModel.Passengers.Add(new Passenger());

        return View(passengerViewModel);
    }

    [HttpPost]
    public IActionResult Create(Passenger passengerViewModel)
    {
        // Save passenger details to the database
        if (ModelState.IsValid)
        {
            foreach (var passenger in passengerViewModel.Passengers)
            {
                // Set the FlightBookingId for each passenger
                passenger.FlightBookingId = passengerViewModel.Flight.Id;

                // Add each passenger to the database
                _context.Passengers.Add(passenger);
            }

            _context.SaveChanges();

            // Redirect to FlightController or another appropriate action
            return RedirectToAction("Index", "Flight");
        }

        // If ModelState is not valid, redisplay the form with validation errors
        return View(passengerViewModel);
    }
}
