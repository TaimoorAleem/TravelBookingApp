using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class FlightBooking
    {
        [Key]
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public List<Passenger> Passengers { get; set; } // Added list for passengers
        public FlightBooking()
        {
            Passengers = new List<Passenger>();
        }
    }
}
