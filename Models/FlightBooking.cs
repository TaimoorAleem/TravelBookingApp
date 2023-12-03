using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class FlightBooking
    {
        [Key]
        public int FlightBookingId { get; set; }
        public Flight Flight { get; set; }
        public Category Fcategory {  get; set; } // Flight Category: International or domestic

        public FClass FBookingClass { get; set; }// Flight Booking Class

        public List<Passenger> Passengers { get; set; } // Added list for passengers
        public FlightBooking()
        {
            Passengers = new List<Passenger>();
        }

        public enum FClass
        {
            Economy,
            Business,
            FirstClass
        }

        public enum Category
        {
            Domestic,
            International
        }

    }
}
