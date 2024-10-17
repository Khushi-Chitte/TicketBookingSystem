using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface IBookingSystem_Task7
    {
        void CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue_Task7 venue,
                         int totalSeats, decimal ticketPrice, string eventType);

        void BookTickets(string eventName, int numTickets, List<Customer_Task7> customers);

        void CancelBooking(int bookingId);

        int GetAvailableNoOfTickets(string eventName);

        Event_Task7 GetEventDetails(string eventName);
    }
}
