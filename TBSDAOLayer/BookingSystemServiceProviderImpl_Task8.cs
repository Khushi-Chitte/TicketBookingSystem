using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public class BookingSystemServiceProviderImpl_Task8: IBookingSystemServiceProvider_Task8
    {
        private List<Event> events = new List<Event>(); // To store events
        private List<Booking> bookings = new List<Booking>(); // To store bookings

        // Method to create an event
        public void CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            Event newEvent = new Event(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType);
            events.Add(newEvent); // Add the newly created event to the events list
            Console.WriteLine("Event created successfully!");
        }

        // Method to book tickets
        public void BookTickets(string eventName, int numTickets, List<Customer> customers)
        {
            // Use the events list to find the event
            Event eventToBook = GetEventDetails().Find(ev => ev.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));

            if (eventToBook != null && eventToBook.AvailableSeats >= numTickets)
            {
                Booking booking = new Booking(eventToBook, customers, numTickets);
                bookings.Add(booking);
                eventToBook.AvailableSeats -= numTickets; // Update available seats
                Console.WriteLine("Booking successful!");
            }
            else
            {
                Console.WriteLine("Booking failed: Not enough available seats.");
            }
        }

        // Method to cancel booking
        public void CancelBooking(int bookingId)
        {
            Booking bookingToCancel = bookings.Find(b => b.BookingId == bookingId);
            if (bookingToCancel != null)
            {
                bookingToCancel.Event.AvailableSeats += bookingToCancel.NumTickets; // Revert available seats
                bookings.Remove(bookingToCancel);
                Console.WriteLine("Booking canceled successfully!");
            }
            else
            {
                Console.WriteLine("No booking found with the given ID.");
            }
        }

        // Method to get booking details by booking ID
        public Booking GetBookingDetails(int bookingId)
        {
            return bookings.Find(b => b.BookingId == bookingId);
        }

        // Implement GetAvailableNoOfTickets method
        public int GetAvailableNoOfTickets(string eventName)
        {
            // Use the events list to find the event
            Event eventToCheck = events.Find(ev => ev.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            if (eventToCheck != null)
            {
                return eventToCheck.AvailableSeats;
            }
            else
            {
                Console.WriteLine("Event not found.");
                return -1;
            }
        }

        // Implement GetEventDetails method
        public List<Event> GetEventDetails()
        {
            return events; // Return the list of events
        }

        public decimal CalculateBookingCost(int numTickets)
        {
            // Assume a default ticket price of 100 for calculation, adjust based on actual event data if needed
            decimal ticketPrice = 100;  // Placeholder value, use actual event data if applicable
            return numTickets * ticketPrice;
        }
    }
}
