using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TBSEntityModel
{
    public class Venue_Task11
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue_Task11(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }
    }

    public class Event_Task11
    {
        public int EventId { get; set; }  // Make sure this property is included.
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public Venue_Task11 Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        // Updated constructor
        public Event_Task11(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task11 venue,
                             int totalSeats, decimal ticketPrice, string eventType)
        {
            EventId = eventId; // Set EventId
            Venue = venue ?? throw new ArgumentNullException(nameof(venue), "Venue cannot be null.");
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats; // Initially available seats equal total seats
            TicketPrice = ticketPrice;
            EventType = eventType;
        }
    }

    public class Customer_Task11
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer_Task11(string customerName, string email, string phoneNumber)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

    public class Booking_Task11
    {
        public int BookingId { get; set; }
        public List<Customer_Task11> Customers { get; set; }
        public Event_Task11 Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        // Static property to auto-increment booking ID
        private static int _bookingIdCounter = 1;

        public Booking_Task11(Event_Task11 eventObj, List<Customer_Task11> customers, int numTickets)
        {

            if (eventObj == null)
            {
                throw new ArgumentNullException(nameof(eventObj), "Event cannot be null.");
            }
            BookingId = _bookingIdCounter++;
            Event = eventObj;
            Customers = customers;
            NumTickets = numTickets;
            BookingDate = DateTime.Now;
            CalculateTotalCost();
        }

        private void CalculateTotalCost()
        {
            if (Event == null)
            {
                throw new InvalidOperationException("Cannot calculate total cost because the event is null.");
            }

            TotalCost = NumTickets * Event.TicketPrice;
        }
    }

    public class Movie_Task11 : Event_Task11
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie_Task11(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task11 venue,
                     int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventId, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie") // Call the base constructor with eventId
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }
    }
}