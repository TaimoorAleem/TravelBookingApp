using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class HotelBooking
    {
        [Key]
        public int HotelBookingId { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [Required]
        public virtual required Hotel Hotel { get; set; }

        [ForeignKey("User")]
        public int Id { get; set; }

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


