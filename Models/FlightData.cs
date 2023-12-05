using System;
using System.Collections.Generic;
using TravelBookingApp.Models;

public static class SampleFlightData
{
    public static List<Flight> Flights { get; } = new List<Flight>
    {
        new Flight
        {
            FlightId = 1,
            AirlineName = "SkyAir",
            AirlineCode = "SKY123",
            DepartureTime = DateTime.Now.AddHours(2),
            ArrivalTime = DateTime.Now.AddHours(4),
            DepartureCity = "New York",
            Destination = "Los Angeles",
            Price = 350.0 // Example price in dollars
        },
        new Flight
        {
            FlightId = 2,
            AirlineName = "OceanWings",
            AirlineCode = "OW456",
            DepartureTime = DateTime.Now.AddHours(5),
            ArrivalTime = DateTime.Now.AddHours(8),
            DepartureCity = "Miami",
            Destination = "San Francisco",
            Price = 420.5 // Example price in dollars
        },
        new Flight
        {
            FlightId = 3,
            AirlineName = "Air Connect",
            AirlineCode = "AC789",
            DepartureTime = DateTime.Now.AddHours(3),
            ArrivalTime = DateTime.Now.AddHours(6),
            DepartureCity = "Chicago",
            Destination = "Seattle",
            Price = 300.75 // Example price in dollars
        },
        new Flight
        {
            FlightId = 4,
            AirlineName = "SwiftFly",
            AirlineCode = "SF112",
            DepartureTime = DateTime.Now.AddHours(6),
            ArrivalTime = DateTime.Now.AddHours(9),
            DepartureCity = "Boston",
            Destination = "Denver",
            Price = 280.0 // Example price in dollars
        },
        new Flight
        {
            FlightId = 5,
            AirlineName = "ExpressJet",
            AirlineCode = "EJ567",
            DepartureTime = DateTime.Now.AddHours(4),
            ArrivalTime = DateTime.Now.AddHours(7),
            DepartureCity = "Houston",
            Destination = "Phoenix",
            Price = 380.25 // Example price in dollars
        },
        new Flight
        {
            FlightId = 6,
            AirlineName = "GlobalAir",
            AirlineCode = "GA888",
            DepartureTime = DateTime.Now.AddHours(7),
            ArrivalTime = DateTime.Now.AddHours(10),
            DepartureCity = "Atlanta",
            Destination = "Las Vegas",
            Price = 450.0 // Example price in dollars
        },
        new Flight
        {
            FlightId = 7,
            AirlineName = "SunsetAirlines",
            AirlineCode = "SA321",
            DepartureTime = DateTime.Now.AddHours(5),
            ArrivalTime = DateTime.Now.AddHours(8),
            DepartureCity = "Orlando",
            Destination = "San Diego",
            Price = 320.5 // Example price in dollars
        },
        new Flight
        {
            FlightId = 8,
            AirlineName = "FlyHigh",
            AirlineCode = "FH555",
            DepartureTime = DateTime.Now.AddHours(6),
            ArrivalTime = DateTime.Now.AddHours(9),
            DepartureCity = "Dallas",
            Destination = "Minneapolis",
            Price = 400.0 // Example price in dollars
        }
        // Add more sample flights as needed
    };
}
