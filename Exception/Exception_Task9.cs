using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    internal class Exception_Task9
    {
        public class EventNotFoundException : System.Exception
        {
            public EventNotFoundException(string message) : base(message) { }
        }
        public class InvalidBookingIDException : System.Exception
        {
            public InvalidBookingIDException(string message) : base(message) { }
        }
    }
}
