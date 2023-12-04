using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TravelBookingApp.Models.PassengerStatus; // Assuming PassengerStatus is defined in another file

namespace TravelBookingApp.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "Passport number cannot exceed 20 characters.")]
        public string? PassportNumber { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Passenger status is required.")]
        [EnumDataType(typeof(PassengerStatus), ErrorMessage = "Invalid passenger status.")]
        public string? PassengerStatus { get; set; } // visitor, TR, PR, Citizen, or Dependant

        

        // Navigation property to link Passenger with FlightBooking
        public int FlightBookingId { get; set; }
        public FlightBooking FlightBooking { get; set; }

        public Flight Flight { get; set; }

        public List<Passenger> Passengers { get; set; }

        /*   public Passenger()
           {
               SeatPreference = Seat.NoPreference;
               PassengerStatus = PassengerStatus.Visitor.ToString();
           }*/


    }

    public enum PassengerStatus
    {
        Visitor,
        TR,
        PR,
        Citizen,
        Dependant
    }
}
