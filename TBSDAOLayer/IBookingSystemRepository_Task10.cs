using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface IBookingSystemRepository_Task10
    {
        void CreateEvent(Event_Task10 eventObj);
        List<Event_Task10> GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
        void BookTickets(Booking_Task10 booking);
        void CancelBooking(int bookingId);
        Booking_Task10 GetBookingDetails(int bookingId);
    }
}
