using System;

namespace TBSEntityModel
{
    public class Ticket_Task2
    {
        // Properties
        public int AvailableTickets { get; set; }
        public int BookedTickets { get; set; }

        // Constructor
        public Ticket_Task2(int availableTickets)
        {
            this.AvailableTickets = availableTickets;
            this.BookedTickets = 0;  
        }
    }
}
