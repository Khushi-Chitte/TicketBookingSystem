using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{
    public class Event_Task4
    {
        // Properties
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }
    }


    public class Venue_Task4
    {
        // Properties
        public string VenueName { get; set; }
        public string Address { get; set; }
    }



    public class Customer_Task4
    {
        // Properties
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }


    public class Booking_Task4
    {
        // Properties
        public int BookingId { get; set; }
        public List<Customer_Task4> Customers { get; set; }
        public Event_Task4 Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        // Static property to auto-increment booking ID
        private static int _bookingIdCounter = 1;

        // Constructor
        public Booking_Task4()
        {
            BookingId = _bookingIdCounter++;
            Customers = new List<Customer_Task4>();
            BookingDate = DateTime.Now;
        }
    }
}
