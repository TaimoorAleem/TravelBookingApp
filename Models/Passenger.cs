using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        [Required(ErrorMessage = "Passenger Name is required")]
        [StringLength(100, ErrorMessage = "Passenger Name should not exceed 100 characters")]
        public string? PassengerName { get; set; }

        [Required(ErrorMessage = "Passport Number is required")]
        [StringLength(20, ErrorMessage = "Passport Number should not exceed 20 characters")]
        public string? PassportNo { get; set; }

        [Required(ErrorMessage = "Passenger Age is required")]
        [Range(1, 150, ErrorMessage = "Passenger Age should be between 1 and 150")]
        public int PassengerAge { get; set; }

        public int? FlightBookingId { get; set; }

        [ForeignKey("FlightBookingId")]
        public virtual FlightBooking FlightBooking { get; set; }

        public Gender PassengerGender { get; set; }
        public Seat SeatPreference { get; set; }

        public string? PassengerStatus { get; set; }  // visitor, TR, PR, Citizen, or Dependant

        public enum Seat
        {
            Window,
            Aisle,
            Middle,
            NoPreference
        }

        public enum Gender
        {
            Male,
            Female,
            Other
        }

        public Passenger()
        {
            SeatPreference = Seat.NoPreference;
            PassengerStatus = "Visitor";
        }
    }
}
