using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class CarService
    {
        [Key]
        public int Id { get; set; }

        public Car? SelectedCar { get; set; }

        [Required(ErrorMessage = "Please enter pickup location. It's required.")]
        [StringLength(100, ErrorMessage = "Pickup location can't be longr than 100 characters")]
        [DataType(DataType.Text)]
        public string? Pickup { get; set; }

        [Required(ErrorMessage = "Please enter pickup location. It's required.")]
        [StringLength(100, ErrorMessage = "Pickup location can't be longr than 100 characters")]
        [DataType(DataType.Text)]
        public string? Dropoff { get; set; }

        [Required(ErrorMessage = "Please specify the dropoff time. It's required.")]

        [DataType(DataType.DateTime)]
        public DateTime? PickupTime { get; set; }

        [Required(ErrorMessage = "Please specify the pickup time. It's required.")]
        [DataType(DataType.DateTime)]
        public DateTime? DropoffTime { get; set; }

        
    }
}
