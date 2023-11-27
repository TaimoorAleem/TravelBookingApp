using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class Car
    {
        //Adding the properties of Car
        [Key]
        public int CarId { get; set; }


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

        [Required(ErrorMessage = "Please enter pickup location. It's required.")]
        [StringLength(100,ErrorMessage ="Pickup location can't be longr than 100 characters")]
        [DataType(DataType.Text)]
        public string? Pickup { get; set; }

        [Required(ErrorMessage = "Please specify the pickup time. It's required.")]
        [DataType(DataType.Text)]
        public string? Dropoff { get; set; }

        [Required(ErrorMessage = "Please specify the dropoff time. It's required.")]
        
        [DataType(DataType.Time)]
        public DateTime? PickupTime { get; set;}

        public int Capacity { get; set; }

        public DateTime Availability { get; set; }





    }

}
