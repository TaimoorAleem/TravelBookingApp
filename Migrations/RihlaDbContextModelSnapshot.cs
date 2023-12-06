﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBookingApp.Models.Data_Access_Layer;

#nullable disable

namespace TravelBookingApp.Migrations
{
    [DbContext(typeof(RihlaDbContext))]
    partial class RihlaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("TravelBookingApp.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("DailyRate")
                        .HasColumnType("REAL");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TravelBookingApp.Models.CarBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dropoff")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pickup")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PickupTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarBookings");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirlineCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ArrivalTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartureCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DepartureTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("FlightId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("TravelBookingApp.Models.FlightBooking", b =>
                {
                    b.Property<int>("FlightBookingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FBookingClass")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fcategory")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlightId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FlightBookingId");

                    b.ToTable("FlightBookings");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            Address = "541 Ocean Drive",
                            Description = "A beachfront hotel with stunning sea views.",
                            Name = "Sea Breeze Resort",
                            NumberOfRooms = 120,
                            Rating = 4.5
                        },
                        new
                        {
                            HotelId = 2,
                            Address = "247 Mountain Road",
                            Description = "A cozy retreat in the heart of the mountains.",
                            Name = "Mountain Escape",
                            NumberOfRooms = 80,
                            Rating = 4.7000000000000002
                        },
                        new
                        {
                            HotelId = 3,
                            Address = "789 City Square",
                            Description = "Modern amenities in the heart of the city.",
                            Name = "Urban Hotel Central",
                            NumberOfRooms = 150,
                            Rating = 4.2000000000000002
                        },
                        new
                        {
                            HotelId = 4,
                            Address = "078 Grand Avenue",
                            Description = "Luxury experience in a historic setting.",
                            Name = "The Grand Historic",
                            NumberOfRooms = 100,
                            Rating = 4.7999999999999998
                        },
                        new
                        {
                            HotelId = 5,
                            Address = "776 Lakeview Terrace",
                            Description = "Tranquil haven by the lake, perfect for a weekend getaway.",
                            Name = "Lakeside Inn",
                            NumberOfRooms = 70,
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            HotelId = 6,
                            Address = "832 Downtown Ave",
                            Description = "Experience the city's vibe from our contemporary hotel.",
                            Name = "Downtown Modern",
                            NumberOfRooms = 200,
                            Rating = 4.5999999999999996
                        },
                        new
                        {
                            HotelId = 7,
                            Address = "623 Country Road",
                            Description = "A cozy bed and breakfast with a homely charm.",
                            Name = "Country Charm B&B",
                            NumberOfRooms = 15,
                            Rating = 4.9000000000000004
                        },
                        new
                        {
                            HotelId = 8,
                            Address = "800 Adventure Lane",
                            Description = "Perfect base for your hiking and outdoor adventures.",
                            Name = "The Adventurer's Lodge",
                            NumberOfRooms = 50,
                            Rating = 4.4000000000000004
                        },
                        new
                        {
                            HotelId = 9,
                            Address = "607 City Road",
                            Description = "Affordable and convenient, right in the city center.",
                            Name = "Budget City Stay",
                            NumberOfRooms = 100,
                            Rating = 3.7999999999999998
                        },
                        new
                        {
                            HotelId = 10,
                            Address = "1356 Green Way",
                            Description = "Sustainable and eco-friendly practices in a lush setting.",
                            Name = "Eco-Friendly Retreat",
                            NumberOfRooms = 40,
                            Rating = 4.7000000000000002
                        },
                        new
                        {
                            HotelId = 11,
                            Address = "1897 Skyline Blvd",
                            Description = "Soaring high with stunning city skyline views.",
                            Name = "Skyline Views Tower",
                            NumberOfRooms = 180,
                            Rating = 4.7999999999999998
                        },
                        new
                        {
                            HotelId = 12,
                            Address = "1100 Heritage Road",
                            Description = "A journey through history in our beautifully preserved hotel.",
                            Name = "Historic Heritage Hotel",
                            NumberOfRooms = 60,
                            Rating = 4.5
                        },
                        new
                        {
                            HotelId = 13,
                            Address = "0912 Family Park",
                            Description = "The ultimate family destination with activities for all ages.",
                            Name = "Family Fun Resort",
                            NumberOfRooms = 150,
                            Rating = 4.2000000000000002
                        },
                        new
                        {
                            HotelId = 14,
                            Address = "424 Romantic Road",
                            Description = "Intimate and romantic settings for couples.",
                            Name = "Romantic Escape",
                            NumberOfRooms = 30,
                            Rating = 4.9000000000000004
                        });
                });

            modelBuilder.Entity("TravelBookingApp.Models.HotelBooking", b =>
                {
                    b.Property<int>("HotelBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("HotelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("HotelBookingId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelBookings");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlightBookingId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PassengerAge")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PassengerGender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PassengerStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("SeatPreference")
                        .HasColumnType("INTEGER");

                    b.HasKey("PassengerId");

                    b.HasIndex("FlightBookingId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("TravelBookingApp.Models.CarBooking", b =>
                {
                    b.HasOne("TravelBookingApp.Models.Car", "SelectedCar")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelectedCar");
                });

            modelBuilder.Entity("TravelBookingApp.Models.FlightBooking", b =>
                {
                    b.HasOne("TravelBookingApp.Models.Flight", "Flight")
                        .WithMany("FlightBookings")
                        .HasForeignKey("FlightBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("TravelBookingApp.Models.HotelBooking", b =>
                {
                    b.HasOne("TravelBookingApp.Models.Hotel", "Hotel")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Passenger", b =>
                {
                    b.HasOne("TravelBookingApp.Models.FlightBooking", "FlightBooking")
                        .WithMany("Passengers")
                        .HasForeignKey("FlightBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightBooking");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Flight", b =>
                {
                    b.Navigation("FlightBookings");
                });

            modelBuilder.Entity("TravelBookingApp.Models.FlightBooking", b =>
                {
                    b.Navigation("Passengers");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Hotel", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
