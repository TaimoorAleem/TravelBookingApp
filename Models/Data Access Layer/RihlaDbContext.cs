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
       
        public DbSet<CarBooking> CarBookings { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }

        // Constructor to configure the DbContext
        public RihlaDbContext(DbContextOptions<RihlaDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel { HotelId = 1, Name = "Sea Breeze Resort", Address = "541 Ocean Drive", Rating = 4.5, Description = "A beachfront hotel with stunning sea views.", NumberOfRooms = 120, Policies = new List<string> { "No smoking", "Pets allowed" }, ImageUrls = new List<string> { "image1.jpg", "image2.jpg" } },
            new Hotel { HotelId = 2, Name = "Mountain Escape", Address = "247 Mountain Road", Rating = 4.7, Description = "A cozy retreat in the heart of the mountains.", NumberOfRooms = 80, Policies = new List<string> { "No pets", "Check-in after 3 PM" }, ImageUrls = new List<string> { "image3.jpg", "image4.jpg" } },
            new Hotel { HotelId = 3, Name = "Urban Hotel Central", Address = "789 City Square", Rating = 4.2, Description = "Modern amenities in the heart of the city.", NumberOfRooms = 150, Policies = new List<string> { "Parking available", "Free WiFi" }, ImageUrls = new List<string> { "image5.jpg", "image6.jpg" } },
            new Hotel { HotelId = 4, Name = "The Grand Historic", Address = "078 Grand Avenue", Rating = 4.8, Description = "Luxury experience in a historic setting.", NumberOfRooms = 100, Policies = new List<string> { "Valet parking", "Breakfast included" }, ImageUrls = new List<string> { "image7.jpg", "image8.jpg" } },
            new Hotel { HotelId = 5, Name = "Lakeside Inn", Address = "776 Lakeview Terrace", Rating = 4.3, Description = "Tranquil haven by the lake, perfect for a weekend getaway.", NumberOfRooms = 70, Policies = new List<string> { "Lake access", "No late-night parties" }, ImageUrls = new List<string> { "image9.jpg", "image10.jpg" } },
            new Hotel { HotelId = 6, Name = "Downtown Modern", Address = "832 Downtown Ave", Rating = 4.6, Description = "Experience the city's vibe from our contemporary hotel.", NumberOfRooms = 200, Policies = new List<string> { "Rooftop bar", "Pet-friendly" }, ImageUrls = new List<string> { "image11.jpg", "image12.jpg" } },
            new Hotel { HotelId = 7, Name = "Country Charm B&B", Address = "623 Country Road", Rating = 4.9, Description = "A cozy bed and breakfast with a homely charm.", NumberOfRooms = 15, Policies = new List<string> { "Homemade breakfast included", "No smoking" }, ImageUrls = new List<string> { "image13.jpg", "image14.jpg" } },
            new Hotel { HotelId = 8, Name = "The Adventurer's Lodge", Address = "800 Adventure Lane", Rating = 4.4, Description = "Perfect base for your hiking and outdoor adventures.", NumberOfRooms = 50, Policies = new List<string> { "Guided tours available", "Equipment storage" }, ImageUrls = new List<string> { "image15.jpg", "image16.jpg" } },
            new Hotel { HotelId = 9, Name = "Budget City Stay", Address = "607 City Road", Rating = 3.8, Description = "Affordable and convenient, right in the city center.", NumberOfRooms = 100, Policies = new List<string> { "Budget-friendly", "Self-service laundry" }, ImageUrls = new List<string> { "image17.jpg", "image18.jpg" } },
            new Hotel { HotelId = 10, Name = "Eco-Friendly Retreat", Address = "1356 Green Way", Rating = 4.7, Description = "Sustainable and eco-friendly practices in a lush setting.", NumberOfRooms = 40, Policies = new List<string> { "Organic meals", "Eco-friendly amenities" }, ImageUrls = new List<string> { "image19.jpg", "image20.jpg" } },
            new Hotel { HotelId = 11, Name = "Skyline Views Tower", Address = "1897 Skyline Blvd", Rating = 4.8, Description = "Soaring high with stunning city skyline views.", NumberOfRooms = 180, Policies = new List<string> { "Panoramic views", "Infinity pool" }, ImageUrls = new List<string> { "image21.jpg", "image22.jpg" } },
            new Hotel { HotelId = 12, Name = "Historic Heritage Hotel", Address = "1100 Heritage Road", Rating = 4.5, Description = "A journey through history in our beautifully preserved hotel.", NumberOfRooms = 60, Policies = new List<string> { "Guided historical tours", "Gourmet dining" }, ImageUrls = new List<string> { "image23.jpg", "image24.jpg" } },
            new Hotel { HotelId = 13, Name = "Family Fun Resort", Address = "0912 Family Park", Rating = 4.2, Description = "The ultimate family destination with activities for all ages.", NumberOfRooms = 150, Policies = new List<string> { "Kids' club", "Family suites available" }, ImageUrls = new List<string> { "image25.jpg", "image26.jpg" } },
            new Hotel { HotelId = 14, Name = "Romantic Escape", Address = "424 Romantic Road", Rating = 4.9, Description = "Intimate and romantic settings for couples.", NumberOfRooms = 30, Policies = new List<string> { "Couples' spa packages", "Romantic dinners" }, ImageUrls = new List<string> { "image27.jpg", "image28.jpg" } }
            );
            

            modelBuilder.Entity<HotelBooking>()
        .HasKey(hb => hb.HotelBookingId);

            modelBuilder.Entity<HotelBooking>()
                .Property(hb => hb.HotelBookingId)
                .ValueGeneratedOnAdd();

            // Configure relationships

            // Relationship between FlightBooking and Flight
            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.Flights)
                .WithMany(f => f.FlightBookings)
                .HasForeignKey(fb => fb.FlightId);

            // Relationship between Passenger and FlightBooking
           

            // Add other configurations as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
