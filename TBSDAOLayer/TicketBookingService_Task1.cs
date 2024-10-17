using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public class TicketBookingService_Task1 : ITicketBookingServices_Task1
    {
        private Ticket_Task1 _ticket;

        // Constructor to initialize the service with available tickets
        public TicketBookingService_Task1(Ticket_Task1 ticket)
        {
            this._ticket = ticket;
        }

        public string BookTickets(int noOfBookingTickets)
        {
            if (_ticket.AvailableTickets >= noOfBookingTickets)
            {
                UpdateAvailableTickets(noOfBookingTickets); // Update tickets within the service class
                return "Ticket Booked Successfully";  // Successful booking
            }
            return "Tickets not available";  // Not enough tickets
        }

        // Method to get remaining tickets
        public int GetRemainingTickets()
        {
            return _ticket.AvailableTickets;
        }

        // Method to update available tickets moved from entity to service
        public void UpdateAvailableTickets(int noOfBookingTickets)
        {
            _ticket.AvailableTickets -= noOfBookingTickets;
            _ticket.BookedTickets += noOfBookingTickets;
        }
    }
}
