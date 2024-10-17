using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface IEventServiceProvider_Task11
    {
        Event_Task11 CreateEvent(string eventName, DateTime date, TimeSpan time, Venue_Task11 venue, int totalSeats, decimal ticketPrice, string eventType);
        List<Event_Task11> GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
    }

    // IBookingSystemServiceProvider_Task11.cs
    public interface IBookingSystemServiceProvider_Task11
    {
        void CalculateBookingCost(int numTickets);
        void BookTickets(string eventName, int numTickets, List<Customer_Task11> customers);
        void CancelBooking(int bookingId);
        Booking_Task11 GetBookingDetails(int bookingId);
    }
}
