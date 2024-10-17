using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public class TicketBookingService_Task5: ITicketBookingServices_Task5
    {
        public void DisplayEventDetails(Event_Task5 eventObj)
        {
            Console.WriteLine($"Event: {eventObj.EventName}, Date: {eventObj.EventDate.ToShortDateString()}, Time: {eventObj.EventTime}, Venue: {eventObj.VenueName}");
            Console.WriteLine($"Seats Available: {eventObj.AvailableSeats}/{eventObj.TotalSeats}, Ticket Price: {eventObj.TicketPrice:C}, Type: {eventObj.EventType}");
        }

        public void DisplayMovieDetails(Movie_Task5 movie)
        {
            DisplayEventDetails(movie);
            Console.WriteLine($"Genre: {movie.Genre}, Actor: {movie.ActorName}, Actress: {movie.ActressName}");
        }

        public void DisplayConcertDetails(Concert_Task5 concert)
        {
            DisplayEventDetails(concert);
            Console.WriteLine($"Artist: {concert.Artist}, Type: {concert.ConcertType}");
        }

        public void DisplaySportsDetails(Sports_Task5 sports)
        {
            DisplayEventDetails(sports);
            Console.WriteLine($"Sport: {sports.SportName}, Teams: {sports.TeamsName}");
        }
    }
}
