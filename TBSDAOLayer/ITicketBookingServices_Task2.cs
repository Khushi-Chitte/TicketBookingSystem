using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSDAOLayer
{
    public interface ITicketBookingServices_Task2
    {
        bool BookTickets(int noOfBookingTickets); // Method to book tickets
        int GetRemainingTickets(); // Method to get remaining tickets
    }
}
