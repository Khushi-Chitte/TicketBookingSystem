using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface IBookingSystemRepository_Task11
    {
        void CreateEvent(Event_Task11 eventObj);
        List<Event_Task11> GetEventDetails();
        public Event_Task11 GetEventByName(string eventName);

        int GetAvailableNoOfTickets(string eventName);
        void BookTickets(Booking_Task11 booking);
        void CancelBooking(int bookingId);
        //Booking_Task11 GetBookingDetails(int bookingId);
    }
}
