using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Flight> FlightRepository { get; set; }
        public List<Hotel> HotelRepository { get; set; }
        public List<Car>  CarRepository { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public virtual User? Users { get; set; }

    }
}
