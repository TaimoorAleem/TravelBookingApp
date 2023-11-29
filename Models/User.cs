using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class User : IdentityUser<int>
    {
        // Enumeration to define two User types
        public enum UserType
        {
            Traveller,
            Admin
        }

        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Departure city must be at most 50 characters.")]
        [DisplayName("Username")]
        public string UserName { get; set;}

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(50, ErrorMessage = "Departure city must be at most 50 characters.")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "Departure city must be at most 50 characters.")]
        public string Password { get; set;}

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "Departure city must be at most 50 characters.")]
        [DisplayName("User Type")]
        public UserType Type { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "Departure city must be at most 50 characters.")]
        public string City { get; set;}

        public List<CarBooking> CarBookings { get; set; } = new List<CarBooking>();
        public List<HotelBooking> HotelBookings { get; set; } = new List<HotelBooking>();
        public List<FlightBooking> FlightBookings { get; set; } = new List<FlightBooking>();

    }
}