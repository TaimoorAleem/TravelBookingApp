using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class FlightBooking
    {
        [Key]
        public int FlightBookingId { get; set; }

        [ForeignKey("Flight")]
        public int FlightId { get; set; }

        public string? Email { get; set; }

        [Required]
        public string? PassportNumber { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int NumberOfCompanions { get; set; }

        public virtual Flight Flight { get; set; }

        public Class FlightClass { get; set; }

        public enum Class
        {
            Economy,
            Business,
            FirstClass
        }
    }
}
