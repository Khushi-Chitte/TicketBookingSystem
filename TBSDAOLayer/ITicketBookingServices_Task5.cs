using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSEntityModel;

namespace TBSDAOLayer
{
    public interface ITicketBookingServices_Task5
    {
        void DisplayEventDetails(Event_Task5 eventObj);     // Polymorphic behavior for all events
        void DisplayMovieDetails(Movie_Task5 movie);
        void DisplayConcertDetails(Concert_Task5 concert);
        void DisplaySportsDetails(Sports_Task5 sports);
    }
}
