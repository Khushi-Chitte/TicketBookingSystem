using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;
using TBSDAOLayer;

namespace TBSDAOLayer
{
    public class TicketBookingService_Task4 : ITicketBookingServices_Task4
    {
        private Event_Task4 _event;

        public TicketBookingService_Task4(Event_Task4 bookedEvent)
        {
            _event = bookedEvent;
        }

        public bool BookTickets(int numTickets)
        {
            if (_event.AvailableSeats >= numTickets)
            {
                _event.AvailableSeats -= numTickets; // Reduce available seats
                return true; // Successful booking
            }
            return false; // Not enough tickets available
        }

        public void CancelBooking(int numTickets)
        {
            _event.AvailableSeats += numTickets; // Increase available seats
        }

        public decimal CalculateTotalRevenue()
        {
            int bookedSeats = _event.TotalSeats - _event.AvailableSeats;
            return bookedSeats * _event.TicketPrice; // Calculate total revenue
        }

        public int GetBookedNoOfTickets()
        {
            return _event.TotalSeats - _event.AvailableSeats; // Get booked tickets
        }

        public void DisplayEventDetails(Event_Task4 eventInfo)
        {
            // Display event details
            Console.WriteLine($"Event: {eventInfo.EventName}, Date: {eventInfo.EventDate.ToShortDateString()}, Time: {eventInfo.EventTime}, Venue: {eventInfo.VenueName}");
            Console.WriteLine($"Seats Available: {eventInfo.AvailableSeats}/{eventInfo.TotalSeats}, Ticket Price: {eventInfo.TicketPrice:C}, Type: {eventInfo.EventType}");
        }

        public void DisplayVenueDetails(Venue_Task4 venue)
        {
            // Display venue details
            Console.WriteLine($"Venue: {venue.VenueName}, Address: {venue.Address}");
        }

        public void DisplayCustomerDetails(Customer_Task4 customer)
        {
            // Display customer details
            Console.WriteLine($"Customer: {customer.CustomerName}, Email: {customer.Email}, Phone: {customer.PhoneNumber}");
        }

        public decimal CalculateBookingCost(int numTickets)
        {
            return numTickets * _event.TicketPrice; // Calculate total cost based on ticket price
        }

        public int GetAvailableNoOfTickets()
        {
            return _event.AvailableSeats; // Return available seats
        }

        public Event_Task4 GetEventDetails()
        {
            return _event; // Return the event object
        }
    }

}
