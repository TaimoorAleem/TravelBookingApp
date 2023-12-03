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

                    b.Property<DateTime?>("DropoffTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
                        .WithMany("CarBookings")
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

            modelBuilder.Entity("TravelBookingApp.Models.Passenger", b =>
                {
                    b.HasOne("TravelBookingApp.Models.FlightBooking", "FlightBooking")
                        .WithMany("Passengers")
                        .HasForeignKey("FlightBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightBooking");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Car", b =>
                {
                    b.Navigation("CarBookings");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Flight", b =>
                {
                    b.Navigation("FlightBookings");
                });

            modelBuilder.Entity("TravelBookingApp.Models.FlightBooking", b =>
                {
                    b.Navigation("Passengers");
                });
#pragma warning restore 612, 618
        }
    }
}
