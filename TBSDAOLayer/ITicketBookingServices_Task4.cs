using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;


namespace TBSDAOLayer
{
    public interface ITicketBookingServices_Task4
    {
        bool BookTickets(int numTickets);                   // Book tickets for an event
        void CancelBooking(int numTickets);                  // Cancel booked tickets
        decimal CalculateTotalRevenue();                    // Calculate total revenue
        int GetBookedNoOfTickets();                          // Get number of booked tickets
        void DisplayEventDetails(Event_Task4 eventInfo);    // Display event details
        void DisplayVenueDetails(Venue_Task4 venue);       // Display venue details
        void DisplayCustomerDetails(Customer_Task4 customer); // Display customer details
        decimal CalculateBookingCost(int numTickets);       // Calculate cost for booking tickets
        int GetAvailableNoOfTickets();                       // Get available tickets for an event
        Event_Task4 GetEventDetails();                       // Get detailed event information
    }
}
