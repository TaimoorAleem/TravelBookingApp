﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class FlightBooking
    {
        [Key]
        public int FlightBookingId { get; set; }

        [ForeignKey("Flight")]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Departure time is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Departure Time")]
        public DateTime? DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Arrival Time")]
        public DateTime? ArrivalTime { get; set; }

        [Required(ErrorMessage = "Departure city is required.")]
        [StringLength(50, ErrorMessage = "Departure city must be at most 50 characters.")]
        [Display(Name = "Departure City")]
        public required string DepartureCity { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        [StringLength(50, ErrorMessage = "Destination must be at most 50 characters.")]
        public required string Destination { get; set; }

        public string? Name {  get; set; }
        public string? Email { get; set; }

        [Required]
        public string? PassportNumber { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int NumberOfCompanions { get; set; }
        public Class FlightClass { get; set; }

        public enum Class
        {
            Economy,
            Business,
            FirstClass
        }


        //  [ForeignKey("Flight")]
        public virtual required Flight Flights { get; set; }

       
    }
}
