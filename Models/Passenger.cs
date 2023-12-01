namespace TravelBookingApp.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string? PassengerName { get; set; }


        public string? PassportNo {  get; set; }
        public int PassengerAge {  get; set; }

        public Gender PassengerGender { get; set; }
        public Seat SeatPreference { get; set; }

        public string? PassengerStatus {  get; set; }  // visitor, TR, PR, Citizen or Dependant

        public enum Seat
        {
            Window,
            Aisle,
            Middle,
            NoPreference
        }

        public enum Gender
        {
            Male,
            Female,
            Other
        }
    }
}
