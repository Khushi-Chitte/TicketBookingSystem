using System;
using System.Collections.Generic;
using TBSEntityModel;


namespace TBSDAOLayer
{
    public class TicketBookingService_Task3 : ITicketBookingServices_Task3
    {
        private Ticket_Task3 _ticket;

        // Constructor
        public TicketBookingService_Task3(Ticket_Task3 ticket)
        {
            this._ticket = ticket;
        }

        public bool BookTickets(int noOfBookingTickets)
        {
            if (_ticket.AvailableTickets >= noOfBookingTickets)
            {
                UpdateAvailableTickets(noOfBookingTickets); // Update ticket count in service class
                return true; 
            }
            return false; 
        }

        // Method to get remaining tickets
        public int GetRemainingTickets()
        {
            return _ticket.AvailableTickets;
        }

        // method for updating tickets moved to service class
        private void UpdateAvailableTickets(int noOfBookingTickets)
        {
            _ticket.AvailableTickets -= noOfBookingTickets;
            _ticket.BookedTickets += noOfBookingTickets;
        }
    }
}
