using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedHotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Address", "Description", "Name", "NumberOfRooms", "Rating" },
                values: new object[,]
                {
                    { 1, "541 Ocean Drive", "A beachfront hotel with stunning sea views.", "Sea Breeze Resort", 120, 4.5 },
                    { 2, "247 Mountain Road", "A cozy retreat in the heart of the mountains.", "Mountain Escape", 80, 4.7000000000000002 },
                    { 3, "789 City Square", "Modern amenities in the heart of the city.", "Urban Hotel Central", 150, 4.2000000000000002 },
                    { 4, "078 Grand Avenue", "Luxury experience in a historic setting.", "The Grand Historic", 100, 4.7999999999999998 },
                    { 5, "776 Lakeview Terrace", "Tranquil haven by the lake, perfect for a weekend getaway.", "Lakeside Inn", 70, 4.2999999999999998 },
                    { 6, "832 Downtown Ave", "Experience the city's vibe from our contemporary hotel.", "Downtown Modern", 200, 4.5999999999999996 },
                    { 7, "623 Country Road", "A cozy bed and breakfast with a homely charm.", "Country Charm B&B", 15, 4.9000000000000004 },
                    { 8, "800 Adventure Lane", "Perfect base for your hiking and outdoor adventures.", "The Adventurer's Lodge", 50, 4.4000000000000004 },
                    { 9, "607 City Road", "Affordable and convenient, right in the city center.", "Budget City Stay", 100, 3.7999999999999998 },
                    { 10, "1356 Green Way", "Sustainable and eco-friendly practices in a lush setting.", "Eco-Friendly Retreat", 40, 4.7000000000000002 },
                    { 11, "1897 Skyline Blvd", "Soaring high with stunning city skyline views.", "Skyline Views Tower", 180, 4.7999999999999998 },
                    { 12, "1100 Heritage Road", "A journey through history in our beautifully preserved hotel.", "Historic Heritage Hotel", 60, 4.5 },
                    { 13, "0912 Family Park", "The ultimate family destination with activities for all ages.", "Family Fun Resort", 150, 4.2000000000000002 },
                    { 14, "424 Romantic Road", "Intimate and romantic settings for couples.", "Romantic Escape", 30, 4.9000000000000004 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 14);
        }
    }
}
