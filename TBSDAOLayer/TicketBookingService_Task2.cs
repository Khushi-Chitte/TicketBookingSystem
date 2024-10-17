using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;



namespace TBSDAOLayer
{
    public class TicketBookingService_Task2 : ITicketBookingServices_Task2
    {
        private Ticket_Task2 _ticket;

        // Constructor
        public TicketBookingService_Task2(Ticket_Task2 ticket)
        {
            this._ticket = ticket;
        }

        // Implementation of BookTickets 
        public bool BookTickets(int noOfBookingTickets)
        {
            if (_ticket.AvailableTickets >= noOfBookingTickets)
            {
                UpdateAvailableTickets(noOfBookingTickets); // Update ticket count in service class
                return true;  // Successful booking
            }
            return false;  // Not enough tickets
        }

        // Method to get remaining tickets
        public int GetRemainingTickets()
        {
            return _ticket.AvailableTickets;
        }

        // Method for updating tickets moved to service class
        private void UpdateAvailableTickets(int noOfBookingTickets)
        {
            _ticket.AvailableTickets -= noOfBookingTickets;
            _ticket.BookedTickets += noOfBookingTickets;
        }
    }
}
