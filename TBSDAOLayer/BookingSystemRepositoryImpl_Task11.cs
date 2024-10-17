using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;
using TBSUtility;
using System.Data.SqlClient;
using TBSException;


namespace TBSDAOLayer
{
    public class BookingSystemRepositoryImpl_Task11: IBookingSystemRepository_Task11
    {
        public void CreateEvent(Event_Task11 eventObj)
        {

            using (var conn = DBUtil_Task11.GetDBConn())
            {
                conn.Open();  // Make sure to open the connection before executing the command

                // Step 1: Insert the venue details into the Venue table
                string venueQuery = "INSERT INTO Venue (VenueName, Address) OUTPUT INSERTED.VenueId VALUES (@VenueName, @Address)";
                SqlCommand venueCmd = new SqlCommand(venueQuery, conn);
                venueCmd.Parameters.AddWithValue("@VenueName", eventObj.Venue.VenueName);
                venueCmd.Parameters.AddWithValue("@Address", eventObj.Venue.Address);

                // Get the inserted VenueId
                int venueId = (int)venueCmd.ExecuteScalar();

                // Step 2: Insert the event details into the Event table using the VenueId
                string eventQuery = "INSERT INTO Event (EventName, EventDate, EventTime, VenueId, TotalSeats, AvailableSeats, TicketPrice, EventType) " +
                                    "VALUES (@EventName, @EventDate, @EventTime, @VenueId, @TotalSeats, @AvailableSeats, @TicketPrice, @EventType)";

                SqlCommand eventCmd = new SqlCommand(eventQuery, conn);
                eventCmd.Parameters.AddWithValue("@EventName", eventObj.EventName);
                eventCmd.Parameters.AddWithValue("@EventDate", eventObj.EventDate);
                eventCmd.Parameters.AddWithValue("@EventTime", eventObj.EventTime);
                eventCmd.Parameters.AddWithValue("@VenueId", venueId);  // Use VenueId here
                eventCmd.Parameters.AddWithValue("@TotalSeats", eventObj.TotalSeats);
                eventCmd.Parameters.AddWithValue("@AvailableSeats", eventObj.AvailableSeats);
                eventCmd.Parameters.AddWithValue("@TicketPrice", eventObj.TicketPrice);
                eventCmd.Parameters.AddWithValue("@EventType", eventObj.EventType);

                eventCmd.ExecuteNonQuery();
            }
        }

        public List<Event_Task11> GetEventDetails()
        {
            List<Event_Task11> events = new List<Event_Task11>();

            using (var conn = DBUtil_Task11.GetDBConn())
            {
                conn.Open();
                string query = "SELECT e.EventId, e.EventName, e.EventDate, e.EventTime, v.VenueName, v.Address, e.TotalSeats, e.AvailableSeats, e.TicketPrice, e.EventType " +
                               "FROM Event e JOIN Venue v ON e.VenueId = v.VenueId";

                SqlCommand cmd = new SqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var venue = new Venue_Task11(reader["VenueName"].ToString(), reader["Address"].ToString());
                        var eventObj = new Event_Task11(
                            (int)reader["EventId"], // Ensure EventId is retrieved
                            reader["EventName"].ToString(),
                            (DateTime)reader["EventDate"],
                            (TimeSpan)reader["EventTime"],
                            venue,
                            (int)reader["TotalSeats"],
                            (decimal)reader["TicketPrice"],
                            reader["EventType"].ToString()
                        );

                        events.Add(eventObj);
                    }
                }
            }

            return events;
        }

        public Event_Task11 GetEventByName(string eventName)
        {
            using (var conn = DBUtil_Task11.GetDBConn())
            {
                conn.Open();
                string query = @"
            SELECT e.EventId, e.EventName, e.EventDate, e.EventTime, 
                   v.VenueName, v.Address, 
                   e.TotalSeats, e.AvailableSeats, e.TicketPrice, e.EventType
            FROM Event e
            JOIN Venue v ON e.VenueId = v.VenueId
            WHERE e.EventName = @EventName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventName", eventName);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var venue = new Venue_Task11(reader["VenueName"].ToString(), reader["Address"].ToString());
                        var eventObj = new Event_Task11(
                            (int)reader["EventId"],
                            reader["EventName"].ToString(),
                            (DateTime)reader["EventDate"],
                            (TimeSpan)reader["EventTime"],
                            venue,
                            (int)reader["TotalSeats"],
                            (decimal)reader["TicketPrice"],
                            reader["EventType"].ToString()
                        );
                        return eventObj;
                    }
                }
            }
            return null; 
        }

        public int GetAvailableNoOfTickets(string eventName)
        {
            int availableTickets = 0;

            using (var conn = DBUtil_Task11.GetDBConn())
            {
                conn.Open();
                string query = "SELECT AvailableSeats FROM Event WHERE EventName = @EventName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventName", eventName);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    availableTickets = (int)result;
                }
            }

            return availableTickets;
        }

        public void BookTickets(Booking_Task11 booking)
        {
            using (var conn = DBUtil_Task11.GetDBConn())
            {
                conn.Open();

                int availableSeats = GetAvailableNoOfTickets(booking.Event.EventName);
                if (availableSeats < booking.NumTickets)
                {
                    throw new InvalidOperationException("Not enough available seats for this event.");
                }

                string bookingQuery = "INSERT INTO Booking (EventId, TotalCost, NumTickets) OUTPUT INSERTED.BookingId VALUES (@EventId, @TotalCost, @NumTickets)";
                SqlCommand bookingCmd = new SqlCommand(bookingQuery, conn);
                bookingCmd.Parameters.AddWithValue("@EventId", booking.Event.EventId); 
                bookingCmd.Parameters.AddWithValue("@TotalCost", booking.TotalCost);
                bookingCmd.Parameters.AddWithValue("@NumTickets", booking.NumTickets);

                int bookingId = (int)bookingCmd.ExecuteScalar();

                string updateSeatsQuery = "UPDATE Event SET AvailableSeats = AvailableSeats - @NumTickets WHERE EventId = @EventId";
                SqlCommand updateSeatsCmd = new SqlCommand(updateSeatsQuery, conn);
                updateSeatsCmd.Parameters.AddWithValue("@NumTickets", booking.NumTickets);
                updateSeatsCmd.Parameters.AddWithValue("@EventId", booking.Event.EventId);
                updateSeatsCmd.ExecuteNonQuery();

                foreach (var customer in booking.Customers)
                {
                    string customerQuery = "INSERT INTO Customer (CustomerName, Email, PhoneNumber) OUTPUT INSERTED.CustomerId VALUES (@CustomerName, @Email, @PhoneNumber)";
                    SqlCommand customerCmd = new SqlCommand(customerQuery, conn);
                    customerCmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    customerCmd.Parameters.AddWithValue("@Email", customer.Email);
                    customerCmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

                    int customerId = (int)customerCmd.ExecuteScalar(); 

                    string customerBookingQuery = "INSERT INTO Customer_Booking (CustomerId, BookingId) VALUES (@CustomerId, @BookingId)";
                    SqlCommand customerBookingCmd = new SqlCommand(customerBookingQuery, conn);
                    customerBookingCmd.Parameters.AddWithValue("@CustomerId", customerId);
                    customerBookingCmd.Parameters.AddWithValue("@BookingId", bookingId);
                    customerBookingCmd.ExecuteNonQuery();
                }
            }
        }


        public void CancelBooking(int bookingId)
        {
            using (var conn = DBUtil_Task11.GetDBConn())
            {
                conn.Open();

                string deleteCustomerBookingQuery = "DELETE FROM Customer_Booking WHERE BookingId = @BookingId";
                using (SqlCommand cmd = new SqlCommand(deleteCustomerBookingQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidBookingIDException("No booking found with the provided Booking ID.");
                    }
                }

                string deleteBookingQuery = "DELETE FROM Booking WHERE BookingId = @BookingId";
                using (SqlCommand cmd = new SqlCommand(deleteBookingQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
