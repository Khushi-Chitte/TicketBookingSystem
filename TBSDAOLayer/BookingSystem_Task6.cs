using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public abstract class BookingSystem_Task6
    {
        public abstract void CreateEvent(Event_Task6 eventObj);
        public abstract bool BookTickets(Event_Task6 eventObj, int numTickets); 
        public abstract int GetAvailableSeats(Event_Task6 eventObj); 
    }
}
