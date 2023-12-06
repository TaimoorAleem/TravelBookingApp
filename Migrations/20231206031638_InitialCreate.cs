﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    DailyRate = table.Column<double>(type: "REAL", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartureCity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AirlineName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AirlineCode = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "CarBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Pickup = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Dropoff = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PickupTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarBookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightBookings",
                columns: table => new
                {
                    FlightBookingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fcategory = table.Column<int>(type: "INTEGER", nullable: false),
                    FBookingClass = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookings", x => x.FlightBookingId);
                    table.ForeignKey(
                        name: "FK_FlightBookings_Flights_FlightBookingId",
                        column: x => x.FlightBookingId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelBookings",
                columns: table => new
                {
                    HotelBookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookings", x => x.HotelBookingId);
                    table.ForeignKey(
                        name: "FK_HotelBookings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassengerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PassportNo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PassengerAge = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightBookingId = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerGender = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatPreference = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerStatus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_Passengers_FlightBookings_FlightBookingId",
                        column: x => x.FlightBookingId,
                        principalTable: "FlightBookings",
                        principalColumn: "FlightBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_CarId",
                table: "CarBookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_HotelId",
                table: "HotelBookings",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_FlightBookingId",
                table: "Passengers",
                column: "FlightBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBookings");

            migrationBuilder.DropTable(
                name: "HotelBookings");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "FlightBookings");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}