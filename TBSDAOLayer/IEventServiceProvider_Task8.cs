using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    interface IEventServiceProvider_Task8
    {
        Event CreateEvent(string eventName, DateTime date, TimeSpan time, Venue venue, int totalSeats, decimal ticketPrice, string eventType);
        List<Event> GetEventDetails();
        int GetAvailableNoOfTickets();
    }
}
