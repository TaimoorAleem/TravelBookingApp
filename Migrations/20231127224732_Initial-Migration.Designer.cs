﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBookingApp.Models.Data_Access_Layer;

#nullable disable

namespace TravelBookingApp.Migrations
{
    [DbContext(typeof(RihlaDbContext))]
    [Migration("20231127224732_Initial-Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("TravelBookingApp.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("DailyRate")
                        .HasColumnType("REAL");

                    b.Property<string>("Dropoff")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pickup")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PickupTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TripId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarId");

                    b.HasIndex("TripId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

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

                    b.Property<int?>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FlightId");

                    b.HasIndex("TripId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HotelId");

                    b.HasIndex("TripId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TravelBookingApp.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Car", b =>
                {
                    b.HasOne("TravelBookingApp.Models.Trip", null)
                        .WithMany("CarRepository")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Flight", b =>
                {
                    b.HasOne("TravelBookingApp.Models.Trip", null)
                        .WithMany("FlightRepository")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Hotel", b =>
                {
                    b.HasOne("TravelBookingApp.Models.Trip", null)
                        .WithMany("HotelRepository")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Trip", b =>
                {
                    b.HasOne("TravelBookingApp.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TravelBookingApp.Models.Trip", b =>
                {
                    b.Navigation("CarRepository");

                    b.Navigation("FlightRepository");

                    b.Navigation("HotelRepository");
                });
#pragma warning restore 612, 618
        }
    }
}
