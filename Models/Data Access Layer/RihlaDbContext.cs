using Microsoft.EntityFrameworkCore;

namespace TravelBookingApp.Models.Data_Access_Layer
{
    public class RihlaDbContext : DbContext
    {
        // Defining DbSet for each entity
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<CarBooking> CarBookings { get; set; }

        // Constructor to configure the DbContext
        public RihlaDbContext(DbContextOptions<RihlaDbContext> options) : base(options)
        {
        }
    }
}
