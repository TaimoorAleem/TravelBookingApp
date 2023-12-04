using Microsoft.EntityFrameworkCore;

namespace TravelBookingApp.Models.Data_Access_Layer
{
    public class RihlaDbContext : DbContext
    {
        // Defining DbSet for each entity
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<CarBooking> CarBookings { get; set; }

        public DbSet<HotelBooking> HotelBookings { get; set; }

        // Constructor to configure the DbContext
        public RihlaDbContext(DbContextOptions<RihlaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships

            // Relationship between FlightBooking and Flight
            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.Flight)
                .WithMany(f => f.FlightBookings)
                .HasForeignKey(fb => fb.FlightBookingId);

            // Relationship between Passenger and FlightBooking
            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.FlightBooking)
                .WithMany(fb => fb.Passengers)
                .HasForeignKey(p => p.FlightBookingId);

            // Add other configurations as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
