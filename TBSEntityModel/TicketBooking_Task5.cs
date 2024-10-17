using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{
    public class Event_Task5
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }
    }

    public class Movie_Task5 : Event_Task5
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }
    }

    public class Concert_Task5 : Event_Task5
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; } // Theatrical, Classical, Rock, Recital
    }

    public class Sports_Task5 : Event_Task5
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; } // Example: India vs Pakistan
    }
}
