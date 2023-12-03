using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class FlightBooking
    {
        [Key]
        public int FlightBookingId { get; set; }

        [ForeignKey("FlightId")]
        public virtual  Flight? Flight { get; set; }
        public Category Fcategory { get; set; } // Flight Category: International or domestic

        public FClass FBookingClass { get; set; }// Flight Booking Class

        public List<Passenger>? Passengers { get; set; } // Added list for passengers
        /*public FlightBooking()
        {
            Passengers = new List<Passenger>();
        }*/

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