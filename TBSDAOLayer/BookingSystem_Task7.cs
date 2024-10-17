using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public class BookingSystem_Task7 : IBookingSystem_Task7
    {
        private List<Event_Task7> events = new List<Event_Task7>(); // List to store events
        private List<Booking_Task7> bookings = new List<Booking_Task7>(); // List to store bookings

        // Method to create an event
        public void CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task7 venue,
                                 int totalSeats, decimal ticketPrice, string eventType)
        {
            Event_Task7 newEvent = eventType switch
            {
                "Movie" => new Movie_Task7(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Genre", "Actor", "Actress"),
                "Concert" => new Concert_Task7(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Artist", "Concert Type"),
                "Sports" => new Sports_Task7(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sport", "Teams"),
                _ => throw new ArgumentException("Invalid event type")
            };

            events.Add(newEvent);
            Console.WriteLine($"{newEvent.EventName} has been created successfully!");
        }

        // Method to book tickets
        public void BookTickets(string eventName, int numTickets, List<Customer_Task7> customers)
        {
            var eventObj = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            if (eventObj != null && eventObj.AvailableSeats >= numTickets)
            {
                Booking_Task7 booking = new Booking_Task7(eventObj, customers, numTickets);
                booking.TotalCost = numTickets * eventObj.TicketPrice; // Calculate total cost here
                bookings.Add(booking);
                eventObj.AvailableSeats -= numTickets; // Update available seats
                Console.WriteLine($"Successfully booked {numTickets} tickets for {eventObj.EventName}.");
            }
            else
            {
                Console.WriteLine("Not enough tickets available or event not found.");
            }
        }

        // Method to cancel a booking
        public void CancelBooking(int bookingId)
        {
            var booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking != null)
            {
                booking.Event.AvailableSeats += booking.NumTickets; // Update available seats
                bookings.Remove(booking);
                Console.WriteLine($"Booking with ID {bookingId} has been canceled.");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }

        // Method to get available tickets
        public int GetAvailableNoOfTickets(string eventName)
        {
            var eventObj = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            return eventObj?.AvailableSeats ?? 0;
        }

        // Method to get event details
        public Event_Task7 GetEventDetails(string eventName)
        {
            return events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
