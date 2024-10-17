using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public class TicketBookingSystem_Task6 : BookingSystem_Task6
    {
        public List<Event_Task6> events = new List<Event_Task6>(); // List to store events

        public override void CreateEvent(Event_Task6 eventObj)
        {
            events.Add(eventObj); // Add event to the list
            Console.WriteLine($"{eventObj.EventName} has been created successfully!");
        }

        public override bool BookTickets(Event_Task6 eventObj, int numTickets)
        {
            if (eventObj.AvailableSeats >= numTickets)
            {
                eventObj.AvailableSeats -= numTickets; // Update available seats
                Console.WriteLine($"Successfully booked {numTickets} tickets for {eventObj.EventName}.");
                return true; // Booking successful
            }
            Console.WriteLine("Not enough tickets available!");
            return false; // Booking failed
        }

        public override int GetAvailableSeats(Event_Task6 eventObj)
        {
            return eventObj.AvailableSeats; // Return available seats
        }
    }
}
