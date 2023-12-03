using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class Car
    {
        //Adding the properties of Car
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a make.")]
        public string? Make { get; set; }

        [Required(ErrorMessage = "Please select a model.")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Please select a year.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter correct information. It's required.")]
        public double DailyRate { get; set; }

        [Required(ErrorMessage = "Please select the city.")]
        public string? City { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<CarBooking> CarBookings { get; set; }

    }
}
