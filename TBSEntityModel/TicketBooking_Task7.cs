using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{   
        public class Venue_Task7
        {
            public string VenueName { get; set; }
            public string Address { get; set; }

            // Default Constructor
            public Venue_Task7() { }

            // Constructor with parameters
            public Venue_Task7(string venueName, string address)
            {
                VenueName = venueName;
                Address = address;
            }
        }


    public class Event_Task7
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public Venue_Task7 Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; } // Use a string to represent the event type

        // Default Constructor
        public Event_Task7() { }

        // Constructor with parameters
        public Event_Task7(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task7 venue,
                            int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats; // Initially available seats are equal to total seats
            TicketPrice = ticketPrice;
            EventType = eventType;
        }
    }


    public class Movie_Task7 : Event_Task7
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        // Default Constructor
        public Movie_Task7() { }

        // Constructor with parameters
        public Movie_Task7(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task7 venue,
                            int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie")
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }
    }


    public class Concert_Task7 : Event_Task7
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; } // Theatrical, Classical, Rock, Recital

        // Default Constructor
        public Concert_Task7() { }

        // Constructor with parameters
        public Concert_Task7(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task7 venue,
                             int totalSeats, decimal ticketPrice, string artist, string concertType)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert")
        {
            Artist = artist;
            ConcertType = concertType;
        }
    }


    public class Sports_Task7 : Event_Task7
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; } // Example: India vs Pakistan

        // Default Constructor
        public Sports_Task7(string eventName) { }

        // Constructor with parameters
        public Sports_Task7(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task7 venue,
                            int totalSeats, decimal ticketPrice, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sports")
        {
            SportName = sportName;
            TeamsName = teamsName;
        }
    }


    public class Customer_Task7
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Default Constructor
        public Customer_Task7() { }

        // Constructor with parameters
        public Customer_Task7(string customerName, string email, string phoneNumber)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }



    public class Booking_Task7
    {
        public int BookingId { get; set; }
        public List<Customer_Task7> Customers { get; set; } = new List<Customer_Task7>();
        public Event_Task7 Event { get; set; } // Event associated with the booking
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        // Static property to auto-increment booking ID
        private static int _bookingIdCounter = 1;

        // Constructor
        public Booking_Task7(Event_Task7 eventObj, List<Customer_Task7> customers, int numTickets)
        {
            BookingId = _bookingIdCounter++;
            Event = eventObj;
            Customers = customers;
            NumTickets = numTickets;
            BookingDate = DateTime.Now;
            TotalCost = 0; // Initialize TotalCost to 0
        }
    }


}



