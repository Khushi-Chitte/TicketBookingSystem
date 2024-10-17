using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSEntityModel
{
    public class Ticket_Task3
    {
        // Properties
        public int AvailableTickets { get; set; }
        public int BookedTickets { get; set; }

        // Constructor
        public Ticket_Task3(int availableTickets)
        {
            this.AvailableTickets = availableTickets;
            this.BookedTickets = 0;  // No tickets booked initially
        }


    }
}
