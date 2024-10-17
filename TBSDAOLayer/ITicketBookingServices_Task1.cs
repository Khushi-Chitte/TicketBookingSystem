using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface ITicketBookingServices_Task1
    {
        string BookTickets(int noOfBookingTickets);
        //string BookTickets(Ticket_Task1 ticket);

        int GetRemainingTickets();

        void UpdateAvailableTickets(int noOfBookingTickets);
    }
}
//