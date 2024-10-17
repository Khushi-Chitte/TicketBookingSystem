using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{
    public abstract class Event_Task6
    {
        public string  EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }

        // Abstract method to display event details
        public abstract void DisplayDetails();
    }


    public class Movie_Task6 : Event_Task6
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        // Implementation of abstract method
        public override void DisplayDetails()
        {
            Console.WriteLine($"Movie: {EventName}, Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Venue: {VenueName}");
            Console.WriteLine($"Seats Available: {AvailableSeats}/{TotalSeats}, Ticket Price: {TicketPrice:C}");
        }
    }


    public class Concert_Task6 : Event_Task6
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; } // Theatrical, Classical, Rock, Recital

        // Implementation of abstract method
        public override void DisplayDetails()
        {
            Console.WriteLine($"Concert: {EventName}, Artist: {Artist}, Type: {ConcertType}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Venue: {VenueName}");
            Console.WriteLine($"Seats Available: {AvailableSeats}/{TotalSeats}, Ticket Price: {TicketPrice:C}");
        }
    }


    public class Sports_Task6 : Event_Task6
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; } // Example: India vs Pakistan

        // Implementation of abstract method
        public override void DisplayDetails()
        {
            Console.WriteLine($"Sport: {EventName}, Teams: {TeamsName}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Venue: {VenueName}");
            Console.WriteLine($"Seats Available: {AvailableSeats}/{TotalSeats}, Ticket Price: {TicketPrice:C}");
        }
    }
}
