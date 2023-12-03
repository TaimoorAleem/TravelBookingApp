namespace TravelBookingApp.Models
{
    public class BookingViewModel
    {
        public List<FlightBooking> FlightBookings { get; set; }
        public List<HotelBooking> HotelBookings { get; set; }
        public List<CarBooking> CarBookings { get; set; }
    }
}
