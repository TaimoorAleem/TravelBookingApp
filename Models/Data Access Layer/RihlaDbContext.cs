using Microsoft.EntityFrameworkCore;

namespace TravelBookingApp.Models.Data_Access_Layer
{
    public class RihlaDbContext : DbContext
    {
        // Define DbSet for each entity
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        // Constructor to configure the DbContext
        public RihlaDbContext(DbContextOptions<RihlaDbContext> options) : base(options)
        {
        }
    }

}
