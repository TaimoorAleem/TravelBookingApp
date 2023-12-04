using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class FlightBooking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

       /* [Required(ErrorMessage = "Flight type is required.")]
        [EnumDataType(typeof(FlightType), ErrorMessage = "Invalid flight type.")]
        public FlightType FlightType { get; set; } // Business or Economic*/

        [Required(ErrorMessage = "Departure location is required.")]
        public string? DepartureLocation { get; set; }

        [Required(ErrorMessage = "Arrival location is required.")]
        public string? ArrivalLocation { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Arrival date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime ArrivalDate { get; set; }

        // Navigation property to link FlightBooking with Flight
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        // Collection navigation property for passengers
        public ICollection<Passenger> Passengers { get; set; }
        public enum FlightType
        {
            Business,
            Economic,
            FirstClass
        }
    }

   
   
}
