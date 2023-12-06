using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class Flight
    {
        // Properties
        [Key]
        public int FlightId { get; set; }
        [Required(ErrorMessage = "Airline name is required.")]
        [StringLength(50, ErrorMessage = "Airline name must be at most 50 characters.")]
        [Display(Name = "Airline Name")]
        public string? AirlineName { get; set; }

        [Required(ErrorMessage = "Airline code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Airline code must be 6 characters.")]
        [Display(Name = "Airline Code")]
        public string? AirlineCode { get; set; }

        public string? AirlineDescription { get; set; }


        public virtual ICollection<FlightBooking> FlightBookings { get; set; }

    
    }
}