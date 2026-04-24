namespace KoeretoejsManager.Api.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int UserId { get; set; }  
        public User User { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        //Start and stop locations, maybe route information
    }
}
