using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class Hotel
    {
        public Hotel()
        {
            Name = string.Empty;
            Address = string.Empty;
            Description = string.Empty;
            Policies = new List<string>();
            ImageUrls = new List<string>();
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Amenities = new List<string>();
            Bookings = new HashSet<HotelBooking>();
        }

        [Key]
        public int HotelId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }

        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number of rooms must be at least 1")]
        public int NumberOfRooms { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal PriceRangeStart { get; set; }

        [DataType(DataType.Currency)]
        public decimal PriceRangeEnd { get; set; }

        public virtual ICollection<HotelBooking> Bookings { get; set; }

        [NotMapped]
        public List<string> Policies { get; set; }

        [NotMapped]
        public List<string> ImageUrls { get; set; }

        [NotMapped]
        public List<string> Amenities { get; set; }
    }
}



