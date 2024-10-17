using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;
using TBSException;

namespace TBSDAOLayer
{
    public class BookingSystemServiceProvider_Task9 : IBookingSystemServiceProvider_Task9
    {
        private List<Event_Task9> events = new List<Event_Task9>();
        private List<Booking_Task9> bookings = new List<Booking_Task9>();

        public void CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task9 venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            Event_Task9 newEvent = eventType switch
            {
                "Movie" => new Movie_Task9(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Genre", "Actor", "Actress"),
                "Concert" => new Concert_Task9(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Artist", "Concert Type"),
                "Sports" => new Sports_Task9(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sport", "Teams"),
                _ => throw new ArgumentException("Invalid event type")
            };

            events.Add(newEvent);
            Console.WriteLine("Event created successfully!");
        }

        public void BookTickets(string eventName, int numTickets, List<Customer_Task9> customers)
        {
            Event_Task9 eventToBook = events.Find(ev => ev.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));

            if (eventToBook == null)
            {
                throw new EventNotFoundException($"Event '{eventName}' not found.");
            }

            if (eventToBook.AvailableSeats >= numTickets)
            {
                Booking_Task9 booking = new Booking_Task9(eventToBook, customers, numTickets);
                bookings.Add(booking);
                eventToBook.AvailableSeats -= numTickets;
                Console.WriteLine("Booking successful!");
            }
            else
            {
                Console.WriteLine("Booking failed: Not enough available seats.");
            }
        }

        public void CancelBooking(int bookingId)
        {
            Booking_Task9 bookingToCancel = bookings.Find(b => b.BookingId == bookingId);
            if (bookingToCancel == null)
            {
                throw new InvalidBookingIDException($"Booking ID '{bookingId}' is invalid.");
            }

            bookingToCancel.Event.AvailableSeats += bookingToCancel.NumTickets;
            bookings.Remove(bookingToCancel);
            Console.WriteLine("Booking canceled successfully!");
        }

        public int GetAvailableNoOfTickets(string eventName)
        {
            Event_Task9 eventToCheck = events.Find(ev => ev.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            if (eventToCheck != null)
            {
                return eventToCheck.AvailableSeats;
            }
            else
            {
                throw new EventNotFoundException($"Event '{eventName}' not found.");
            }
        }

        public Event_Task9 GetEventDetails(string eventName)
        {
            return events.Find(ev => ev.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
