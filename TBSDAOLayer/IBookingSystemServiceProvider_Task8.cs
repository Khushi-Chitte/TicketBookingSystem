using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface IBookingSystemServiceProvider_Task8
    {
        void CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string eventType);
        void BookTickets(string eventName, int numTickets, List<Customer> customers);
        void CancelBooking(int bookingId);
        Booking GetBookingDetails(int bookingId);
        int GetAvailableNoOfTickets(string eventName);
        List<Event> GetEventDetails();

        // Method to calculate booking cost
        decimal CalculateBookingCost(int numTickets);
    }
}
