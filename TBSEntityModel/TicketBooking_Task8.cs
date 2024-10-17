using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{
    public class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }
    }

    public class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public Venue Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        public Event(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats; // Initially, available seats equal total seats
            TicketPrice = ticketPrice;
            EventType = eventType;
        }
    }

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie")
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; }

        public Concert(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string artist, string concertType)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert")
        {
            Artist = artist;
            ConcertType = concertType;
        }
    }


    public class Sports : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sports(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sports")
        {
            SportName = sportName;
            TeamsName = teamsName;
        }
    }

    public class Customer
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string customerName, string email, string phoneNumber)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

    public class Booking
    {
        public int BookingId { get; set; }
        public List<Customer> Customers { get; set; }
        public Event Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        private static int _bookingIdCounter = 1;

        public Booking(Event eventObj, List<Customer> customers, int numTickets)
        {
            BookingId = _bookingIdCounter++;
            Event = eventObj;
            Customers = customers;
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
