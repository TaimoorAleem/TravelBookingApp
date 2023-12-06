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
            AirlineDescription="Boeing 747"
            
        },
        new Flight
        {
            FlightId = 2,
            AirlineName = "OceanWings",
            AirlineCode = "OW456",
             AirlineDescription="Boeing 747"

        },
        new Flight
        {
            FlightId = 3,
            AirlineName = "Air Connect",
            AirlineCode = "AC789",
             AirlineDescription="Boeing 737"

        },
        new Flight
        {
            FlightId = 4,
            AirlineName = "SwiftFly",
            AirlineCode = "SF112",
             AirlineDescription="Boeing 747"

        },
        new Flight
        {
            FlightId = 5,
            AirlineName = "ExpressJet",
            AirlineCode = "EJ567",
             AirlineDescription="Boeing 777"

        },
        new Flight
        {
            FlightId = 6,
            AirlineName = "GlobalAir",
            AirlineCode = "GA888",
             AirlineDescription="Boeing 747"

        },
        new Flight
        {
            FlightId = 7,
            AirlineName = "SunsetAirlines",
            AirlineCode = "SA321",
             AirlineDescription="Boeing 747"

        },
        new Flight
        {
            FlightId = 8,
            AirlineName = "FlyHigh",
            AirlineCode = "FH555",
             AirlineDescription="Airbus A380"

        }
        // Add more sample flights as needed
    };
}
