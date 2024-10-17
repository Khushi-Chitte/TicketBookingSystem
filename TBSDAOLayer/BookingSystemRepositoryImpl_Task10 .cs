using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public class BookingSystemRepositoryImpl_Task10 : IBookingSystemRepository_Task10
    {
        private List<Event_Task10> events = new List<Event_Task10>();
        private List<Booking_Task10> bookings = new List<Booking_Task10>();

        public void CreateEvent(Event_Task10 eventObj)
        {
            events.Add(eventObj); // Add to local events list
        }

        public List<Event_Task10> GetEventDetails()
        {
            return events; // Return the list of events
        }

        public int GetAvailableNoOfTickets(string eventName)
        {
            var eventObj = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            return eventObj?.AvailableSeats ?? 0; // Return available seats or 0 if not found
        }

        public void BookTickets(Booking_Task10 booking)
        {
            bookings.Add(booking); // Add booking to the list
            var eventToUpdate = events.Find(e => e.EventId == booking.Event.EventId);
            if (eventToUpdate != null)
            {
                eventToUpdate.AvailableSeats -= booking.NumTickets; // Update available seats
            }
        }

        public void CancelBooking(int bookingId)
        {
            var booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking != null)
            {
                bookings.Remove(booking); // Remove booking from the list
                var eventToUpdate = events.Find(e => e.EventId == booking.Event.EventId);
                if (eventToUpdate != null)
                {
                    eventToUpdate.AvailableSeats += booking.NumTickets; // Restore available seats
                }
            }
            else
            {
                throw new Exception("Booking not found.");
            }
        }

        public Booking_Task10 GetBookingDetails(int bookingId)
        {
            return bookings.Find(b => b.BookingId == bookingId); // Return the booking details
        }
    }
}
