using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public class EventServiceProviderImpl_Task8: IEventServiceProvider_Task8
    {
        private List<Event> events = new List<Event>();

        public Event CreateEvent(string eventName, DateTime date, TimeSpan time, Venue venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            Event newEvent = eventType switch
            {
                "Movie" => new Movie(eventName, date, time, venue, totalSeats, ticketPrice, "Genre", "Actor", "Actress"),
                "Concert" => new Concert(eventName, date, time, venue, totalSeats, ticketPrice, "Artist", "Concert Type"),
                "Sports" => new Sports(eventName, date, time, venue, totalSeats, ticketPrice, "Sport", "Teams"),
                _ => throw new ArgumentException("Invalid event type")
            };

            events.Add(newEvent);
            return newEvent;
        }

        public List<Event> GetEventDetails() => events;

        public int GetAvailableNoOfTickets()
        {
            // Return available tickets for all events
            int availableTickets = 0;
            foreach (var ev in events)
            {
                availableTickets += ev.AvailableSeats;
            }
            return availableTickets;
        }
    }
}
