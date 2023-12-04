using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class Flight
    {
        // Properties
        [Key]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Departure time is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Departure Time")]
        public DateTime? DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Arrival Time")]
        public DateTime? ArrivalTime { get; set; }

        [Required(ErrorMessage = "Departure city is required.")]
        [StringLength(50, ErrorMessage = "Departure city must be at most 50 characters.")]
        [Display(Name = "Departure City")]
        public string DepartureCity { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        [StringLength(50, ErrorMessage = "Destination must be at most 50 characters.")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Airline name is required.")]
        [StringLength(50, ErrorMessage = "Airline name must be at most 50 characters.")]
        [Display(Name = "Airline Name")]
        public string AirlineName { get; set; }

        [Required(ErrorMessage = "Airline code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Airline code must be 6 characters.")]
        [Display(Name = "Airline Code")]
        public string AirlineCode { get; set; }

        public virtual ICollection<FlightBooking> FlightBookings { get; set; }

        // Parameterless constructor for scaffolding
        public Flight()
        {
        }

        public Flight(int flightId, DateTime departureTime, DateTime arrivalTime, string departureCity, string destination, string airlineName, string airlineCode)
        {
            FlightId = flightId;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            DepartureCity = departureCity;
            Destination = destination;
            AirlineName = airlineName;
            AirlineCode = airlineCode;
        }
    }
}