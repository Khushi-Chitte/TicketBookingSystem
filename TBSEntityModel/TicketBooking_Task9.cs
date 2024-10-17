using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{
    public class Event_Task9
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public Venue_Task9 Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }  // "Movie", "Concert", or "Sports"

        public Event_Task9(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task9 venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }
    }


    public class Customer_Task9
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer_Task9(string customerName, string email, string phoneNumber)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }


    public class Venue_Task9
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue_Task9(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }
    }


    public class Booking_Task9
    {
        public int BookingId { get; set; }
        public List<Customer_Task9> Customers { get; set; }
        public Event_Task9 Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        private static int _bookingIdCounter = 1;

        public Booking_Task9(Event_Task9 eventObj, List<Customer_Task9> customers, int numTickets)
        {
            BookingId = _bookingIdCounter++;
            Event = eventObj;
            Customers = customers;
            NumTickets = numTickets;
            BookingDate = DateTime.Now;
            CalculateTotalCost(); // Method call to calculate total cost
        }

        private void CalculateTotalCost()
        {
            TotalCost = NumTickets * Event.TicketPrice; // Total cost based on number of tickets booked
        }
    }


    public class Movie_Task9 : Event_Task9
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie_Task9(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task9 venue,
                           int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie") // Assuming event_type is a string
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }
    }

    public class Concert_Task9 : Event_Task9
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; }

        public Concert_Task9(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task9 venue,
                             int totalSeats, decimal ticketPrice, string artist, string concertType)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert")
        {
            Artist = artist;
            ConcertType = concertType;
        }
    }

    public class Sports_Task9 : Event_Task9
    {
        public string SportName { get; set; }
        public string Teams { get; set; }

        public Sports_Task9(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task9 venue,
                            int totalSeats, decimal ticketPrice, string sportName, string teams)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sports")
        {
            SportName = sportName;
            Teams = teams;
        }
    }
}
