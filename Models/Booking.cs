using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Trip name is required.")]
        public string Name { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        // Navigation properties for related entities
        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

        // Properties to capture selected items in the form
        [NotMapped]
        [Display(Name = "Select Flights")]
        public List<int> SelectedFlights { get; set; } = new List<int>();

        [NotMapped]
        [Display(Name = "Select Hotels")]
        public List<int> SelectedHotels { get; set; } = new List<int>();

        [NotMapped]
        [Display(Name = "Select Cars")]
        public List<int> SelectedCars { get; set; } = new List<int>();

        // Properties to display available options in the form
        [NotMapped]
        public List<Flight> AllFlights { get; set; }

        [NotMapped]
        public List<Hotel> AllHotels { get; set; }

        [NotMapped]
        public List<Car> AllCars { get; set; }
    }
}

