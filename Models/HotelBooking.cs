using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class HotelBooking
    {
        public HotelBooking() 
        {
            FullName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        [Key]
        public int HotelBookingId { get; set; }
        
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual required Hotel Hotel { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "There must be at least one guest")]
        public int NumberOfGuests { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public BookingState State { get; set; } // Enum for booking state

        public bool IsValidBookingDateRange() => CheckInDate < CheckOutDate && CheckInDate.Date >= DateTime.Today.Date;

        public void CalculatePrice(decimal ratePerDay) => Price = (CheckOutDate - CheckInDate).Days * ratePerDay;

        [NotMapped]
        public int DurationInDays => (CheckOutDate - CheckInDate).Days;
    }

    public enum BookingState
    {
        Pending,
        Confirmed,
        Cancelled
    }
}


