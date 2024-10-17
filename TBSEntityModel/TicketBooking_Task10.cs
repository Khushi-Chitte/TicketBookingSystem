using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{
    public class Venue_Task10
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue_Task10(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }
    }


    public class Event_Task10
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public Venue_Task10 Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        public Event_Task10(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task10 venue,
                            int totalSeats, decimal ticketPrice, string eventType)
        {
            EventId = eventId;
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

    public class Customer_Task10
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer_Task10(string customerName, string email, string phoneNumber)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }


    public class Booking_Task10
    {
        public int BookingId { get; set; }
        public HashSet<Customer_Task10> Customers { get; set; } = new HashSet<Customer_Task10>(); // Using HashSet for unique customers
        public Event_Task10 Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        private static int _bookingIdCounter = 1;

        public Booking_Task10(Event_Task10 eventObj, HashSet<Customer_Task10> customers, int numTickets)
        {
            BookingId = _bookingIdCounter++;
            Event = eventObj ?? throw new ArgumentNullException(nameof(eventObj), "Event cannot be null.");
            Customers = customers; // Assign the HashSet directly
            NumTickets = numTickets;
            BookingDate = DateTime.Now;
            CalculateTotalCost();
        }

        private void CalculateTotalCost()
        {
            TotalCost = NumTickets * Event.TicketPrice;
        }
    }
}
