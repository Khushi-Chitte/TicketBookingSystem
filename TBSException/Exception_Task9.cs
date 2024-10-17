namespace TBSException
{

    public class EventNotFoundException : System.Exception
    {
        public EventNotFoundException(string message) : base(message) { }
    }

    // InvalidBookingIDException.cs
    public class InvalidBookingIDException : System.Exception
    {
        public InvalidBookingIDException(string message) : base(message) { }
    }

    //// NullPointerException.cs
    //public class NullPointerException : Exception
    //    {
    //        public NullPointerException(string message) : base(message) { }
    //    }
}

