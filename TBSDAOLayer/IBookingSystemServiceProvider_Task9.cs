using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface IBookingSystemServiceProvider_Task9
    {
        void CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task9 venue, int totalSeats, decimal ticketPrice, string eventType);
        void BookTickets(string eventName, int numTickets, List<Customer_Task9> customers);
        void CancelBooking(int bookingId);
        int GetAvailableNoOfTickets(string eventName);
        Event_Task9 GetEventDetails(string eventName);
    }
}
