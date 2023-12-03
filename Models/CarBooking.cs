using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class CarBooking
    {
        

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car? SelectedCar { get; set; }

        [Required(ErrorMessage = "Please enter your name. It's required.")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Invalid email address")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number. It's required.")]
        [DataType(DataType.Password)]
        public int? PhoneNo { get; set; }

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

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }


        //TODO implement Total price
        //Payment


    }
}
