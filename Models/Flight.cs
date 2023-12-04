using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Flight name is required.")]
        public string? FlightName { get; set; }

        [Required(ErrorMessage = "Flight code is required.")]
        public string? FlightCode { get; set; }

        [Required(ErrorMessage = "Departure location is required.")]
        public string? DepartureLocation { get; set; }

        [Required(ErrorMessage = "Arrival location is required.")]
        public string? ArrivalLocation { get; set; }

        [Required(ErrorMessage = "Departure date and time are required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime DepartureDateTime { get; set; }

        [Required(ErrorMessage = "Arrival date and time are required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        [DateGreaterThan("DepartureDateTime", ErrorMessage = "Arrival date must be greater than departure date.")]
        public DateTime ArrivalDateTime { get; set; }

        [Required(ErrorMessage = "Flight type is required.")]
        [EnumDataType(typeof(FlightType), ErrorMessage = "Invalid flight type.")]
        public string? FlightType { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        // Collection navigation property to link Flight with FlightBooking
        public ICollection<FlightBooking> FlightBookings { get; set; }


    }

    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (propertyInfo == null)
            {
                return new ValidationResult($"Property with name {_comparisonProperty} not found.");
            }

            var comparisonValue = (DateTime)propertyInfo.GetValue(validationContext.ObjectInstance);

            if ((DateTime)value <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage ?? $"Arrival date must be greater than {propertyInfo.Name}.");
            }

            return ValidationResult.Success;
        }
    }
}
