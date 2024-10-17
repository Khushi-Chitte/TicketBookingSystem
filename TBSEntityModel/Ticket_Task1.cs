namespace TBSEntityModel
{
    public class Ticket_Task1
    {
        // Properties
        public int AvailableTickets { get; set; }
        public int BookedTickets { get; set; }

        // Constructor
        public Ticket_Task1(int availableTickets)
        {
            this.AvailableTickets = availableTickets;
            this.BookedTickets = 0;  
        }
    }
}
