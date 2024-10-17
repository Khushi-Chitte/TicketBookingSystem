


using System;
using System.Collections.Generic;
using TBSEntityModel;
using TBSDAOLayer;
using TBSException;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Ticket Booking System ---");
            Console.WriteLine("Select a task to run:");
            Console.WriteLine("1. Task 1 - Basic Ticket Booking");
            Console.WriteLine("2. Task 2 - Nested Conditional Statements");
            Console.WriteLine("3. Task 3 - Looping");
            Console.WriteLine("4. Task 4 - Classes and Objects");
            Console.WriteLine("5. Task 5 - Inheritance and Polymorphism");
            Console.WriteLine("6. Task 6 - Abstraction");
            Console.WriteLine("7. Task 7 - Has A Relation / Association");
            Console.WriteLine("8. Task 8 - Exception Handling");
            Console.WriteLine("9. Task 9 - More Exception Handling");
            Console.WriteLine("10. Task 10 - Collections");
            Console.WriteLine("11. Task 11 - Database Connectivity");
            Console.WriteLine("12. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                case "6":
                    Task6();
                    break;
                case "7":
                    Task7();
                    break;
                case "8":
                    Task8();
                    break;
                case "9":
                    Task9();
                    break;
                case "10":
                    Task10();
                    break;
                case "11":
                    Task11();
                    break;
                case "12":
                    Console.WriteLine("Assignment End!! ThankYou");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid task.");
                    break;
            }
        }
    }

    // Task 1 Method
    static void Task1()
    {
        Console.WriteLine("Enter the number of available tickets:");
        int availableTickets = int.Parse(Console.ReadLine());

        Ticket_Task1 ticket = new Ticket_Task1(availableTickets);
        ITicketBookingServices_Task1 bookingService = new TicketBookingService_Task1(ticket);

        Console.WriteLine("Enter the number of tickets to be booked:");
        int noOfBookingTickets = int.Parse(Console.ReadLine());

        bookingService.BookTickets(noOfBookingTickets);
        Console.WriteLine($"Booking successful! Remaining tickets: {bookingService.GetRemainingTickets()}");
    }

    // Task 2 Method
    static void Task2()
    {
        Console.WriteLine("Enter the number of available tickets:");
        int availableTickets = int.Parse(Console.ReadLine());

        Ticket_Task2 ticket = new Ticket_Task2(availableTickets);
        ITicketBookingServices_Task2 bookingService = new TicketBookingService_Task2(ticket);

        Console.WriteLine("Available Ticket Categories:");
        Console.WriteLine("1. Silver - Price: Rs. 100");
        Console.WriteLine("2. Gold - Price: Rs. 200");
        Console.WriteLine("3. Diamond - Price: Rs. 300");
        Console.WriteLine("Select your ticket category (1-3):");

        string categoryInput = Console.ReadLine();
        int ticketPrice = 0;

        switch (categoryInput)
        {
            case "1":
                ticketPrice = 100;
                break;
            case "2":
                ticketPrice = 200;
                break;
            case "3":
                ticketPrice = 300;
                break;
            default:
                Console.WriteLine("Invalid category selected.");
                return;
        }

        Console.WriteLine("Enter the number of tickets to be booked:");
        int noOfBookingTickets = int.Parse(Console.ReadLine());

        if (noOfBookingTickets > 0 && availableTickets >= noOfBookingTickets)
        {
            int totalCost = noOfBookingTickets * ticketPrice;
            Console.WriteLine($"Total cost for {noOfBookingTickets} tickets: Rs. {totalCost}");

            if (bookingService.BookTickets(noOfBookingTickets))
            {
                Console.WriteLine($"Booking successful! Remaining tickets: {bookingService.GetRemainingTickets()}");
            }
            else
            {
                Console.WriteLine("Tickets unavailable! Not enough tickets.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input! Number of tickets must be greater than zero and available.");
        }
    }

    // Task 3 Method
    static void Task3()
    {
        Console.WriteLine("Enter the number of available tickets:");
        int availableTickets = int.Parse(Console.ReadLine());

        Ticket_Task3 ticket = new Ticket_Task3(availableTickets);
        ITicketBookingServices_Task3 bookingService = new TicketBookingService_Task3(ticket);

        while (true)
        {
            Console.WriteLine("Enter the number of tickets to be booked (or type 'exit' to quit):");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit") break;

            if (int.TryParse(input, out int noOfBookingTickets) && noOfBookingTickets > 0)
            {
                if (bookingService.BookTickets(noOfBookingTickets))
                {
                    Console.WriteLine($"Booking successful! Remaining tickets: {bookingService.GetRemainingTickets()}");
                }
                else
                {
                    Console.WriteLine("Tickets unavailable! Not enough tickets.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number of tickets.");
            }
        }

        Console.WriteLine("Thank you for using the Ticket Booking System!");
    }

    // Task 4 Method (Classes and Objects)
    static void Task4()
    {
        Console.WriteLine("Enter event name:");
        string eventName = Console.ReadLine();

        Console.WriteLine("Enter event date (yyyy-mm-dd):");
        DateTime eventDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter event time (hh:mm):");
        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());

        Console.WriteLine("Enter venue name:");
        string venueName = Console.ReadLine();

        Console.WriteLine("Enter total number of seats:");
        int totalSeats = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter ticket price:");
        decimal ticketPrice = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter event type (e.g., Concert, Movie, Sports):");
        string eventType = Console.ReadLine();

        Event_Task4 concert = new Event_Task4
        {
            EventName = eventName,
            EventDate = eventDate,
            EventTime = eventTime,
            VenueName = venueName,
            TotalSeats = totalSeats,
            AvailableSeats = totalSeats,
            TicketPrice = ticketPrice,
            EventType = eventType
        };

        TicketBookingService_Task4 ticketBookingService = new TicketBookingService_Task4(concert);
        List<Customer_Task4> customers = new List<Customer_Task4>();

        while (true)
        {
            Console.WriteLine("\n--- Event Menu ---");
            Console.WriteLine("1. Book Tickets");
            Console.WriteLine("2. Cancel Booking");
            Console.WriteLine("3. Display Event Details");
            Console.WriteLine("4. Display Venue Details");
            Console.WriteLine("5. Display Customer Details");
            Console.WriteLine("6. Calculate Total Revenue");
            Console.WriteLine("7. Get Number of Booked Tickets");
            Console.WriteLine("8. Get Available Tickets");
            Console.WriteLine("9. Add Customers");
            Console.WriteLine("10. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Book Tickets
                    Console.Write("Enter number of tickets to book: ");
                    int ticketsToBook = int.Parse(Console.ReadLine());
                    if (ticketBookingService.BookTickets(ticketsToBook))
                    {
                        Console.WriteLine($"Successfully booked {ticketsToBook} tickets!");
                    }
                    else
                    {
                        Console.WriteLine("Not enough tickets available.");
                    }
                    break;

                case "2": // Cancel Booking
                    Console.Write("Enter number of tickets to cancel: ");
                    int ticketsToCancel = int.Parse(Console.ReadLine());
                    ticketBookingService.CancelBooking(ticketsToCancel);
                    Console.WriteLine($"Successfully canceled {ticketsToCancel} tickets.");
                    break;

                case "3": // Display Event Details
                    ticketBookingService.DisplayEventDetails(concert);
                    break;

                case "4": // Display Venue Details
                    Venue_Task4 venue = new Venue_Task4
                    {
                        VenueName = venueName,
                        Address = "Sample Address"
                    };
                    ticketBookingService.DisplayVenueDetails(venue);
                    break;

                case "5": // Display Customer Details
                    if (customers.Count == 0)
                    {
                        Console.WriteLine("No customers available. Please add customers first.");
                    }
                    else
                    {
                        foreach (var customer in customers)
                        {
                            ticketBookingService.DisplayCustomerDetails(customer);
                        }
                    }
                    break;

                case "6": // Calculate Total Revenue
                    decimal totalRevenue = ticketBookingService.CalculateTotalRevenue();
                    Console.WriteLine($"Total Cost: Rs. {totalRevenue}");
                    break;

                case "7": // Get Number of Booked Tickets
                    int bookedTickets = ticketBookingService.GetBookedNoOfTickets();
                    Console.WriteLine($"Number of booked tickets: {bookedTickets}");
                    break;

                case "8": // Get Available Tickets
                    int availableTickets = ticketBookingService.GetAvailableNoOfTickets();
                    Console.WriteLine($"Available tickets: {availableTickets}");
                    break;

                case "9": // Add Customers
                    Console.WriteLine("Enter number of customers to add:");
                    int numCustomers = int.Parse(Console.ReadLine());

                    for (int i = 0; i < numCustomers; i++)
                    {
                        Console.WriteLine($"Enter details for customer {i + 1}:");
                        Console.Write("Customer name: ");
                        string customerName = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone number: ");
                        string phoneNumber = Console.ReadLine();

                        customers.Add(new Customer_Task4
                        {
                            CustomerName = customerName,
                            Email = email,
                            PhoneNumber = phoneNumber
                        });
                    }

                    Console.WriteLine($"{numCustomers} customers have been added.");
                    break;

                case "10": // Exit
                    Console.WriteLine("Exiting the system.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Task 5 Method (Inheritance and Polymorphism)
    static void Task5()
    {
        ITicketBookingServices_Task5 eventService = new TicketBookingService_Task5();
        Event_Task5 selectedEvent = null;

        while (true)
        {
            Console.WriteLine("\n--- Ticket Booking System Task 5 ---");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Add Concert");
            Console.WriteLine("3. Add Sports");
            Console.WriteLine("4. Display Movie Details");
            Console.WriteLine("5. Display Concert Details");
            Console.WriteLine("6. Display Sports Details");
            Console.WriteLine("7. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Movie_Task5 movie = new Movie_Task5();
                    Console.WriteLine("\n--- Add Movie ---");
                    Console.Write("Enter Movie Name: ");
                    movie.EventName = Console.ReadLine();
                    Console.Write("Enter Movie Date (yyyy-mm-dd): ");
                    movie.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Movie Time (hh:mm): ");
                    movie.EventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    movie.VenueName = Console.ReadLine();
                    Console.Write("Enter Total Seats: ");
                    movie.TotalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Available Seats: ");
                    movie.AvailableSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    movie.TicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Genre: ");
                    movie.Genre = Console.ReadLine();
                    Console.Write("Enter Actor Name: ");
                    movie.ActorName = Console.ReadLine();
                    Console.Write("Enter Actress Name: ");
                    movie.ActressName = Console.ReadLine();

                    selectedEvent = movie;
                    Console.WriteLine("\nMovie added successfully!");
                    break;

                case "2":
                    Concert_Task5 concert = new Concert_Task5();
                    Console.WriteLine("\n--- Add Concert ---");
                    Console.Write("Enter Concert Name: ");
                    concert.EventName = Console.ReadLine();
                    Console.Write("Enter Concert Date (yyyy-mm-dd): ");
                    concert.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Concert Time (hh:mm): ");
                    concert.EventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    concert.VenueName = Console.ReadLine();
                    Console.Write("Enter Total Seats: ");
                    concert.TotalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Available Seats: ");
                    concert.AvailableSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    concert.TicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Artist Name: ");
                    concert.Artist = Console.ReadLine();
                    Console.Write("Enter Concert Type (Theatrical, Classical, Rock, Recital): ");
                    concert.ConcertType = Console.ReadLine();

                    selectedEvent = concert;
                    Console.WriteLine("\nConcert added successfully!");
                    break;

                case "3":
                    Sports_Task5 sports = new Sports_Task5();
                    Console.WriteLine("\n--- Add Sports ---");
                    Console.Write("Enter Sports Event Name: ");
                    sports.EventName = Console.ReadLine();
                    Console.Write("Enter Sports Event Date (yyyy-mm-dd): ");
                    sports.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Sports Event Time (hh:mm): ");
                    sports.EventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    sports.VenueName = Console.ReadLine();
                    Console.Write("Enter Total Seats: ");
                    sports.TotalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Available Seats: ");
                    sports.AvailableSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    sports.TicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Sport Name: ");
                    sports.SportName = Console.ReadLine();
                    Console.Write("Enter Teams Playing: ");
                    sports.TeamsName = Console.ReadLine();

                    selectedEvent = sports;
                    Console.WriteLine("\nSports event added successfully!");
                    break;

                case "4":
                    if (selectedEvent is Movie_Task5 movieEvent)
                    {
                        eventService.DisplayMovieDetails(movieEvent);
                    }
                    else
                    {
                        Console.WriteLine("No movie event available to display.");
                    }
                    break;

                case "5":
                    if (selectedEvent is Concert_Task5 concertEvent)
                    {
                        eventService.DisplayConcertDetails(concertEvent);
                    }
                    else
                    {
                        Console.WriteLine("No concert event available to display.");
                    }
                    break;

                case "6":
                    if (selectedEvent is Sports_Task5 sportsEvent)
                    {
                        eventService.DisplaySportsDetails(sportsEvent);
                    }
                    else
                    {
                        Console.WriteLine("No sports event available to display.");
                    }
                    break;

                case "7":
                    Console.WriteLine("Exiting the system.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Task 6 Method (Abstraction)
    static void Task6()
    {
        TicketBookingSystem_Task6 bookingSystem = new TicketBookingSystem_Task6();

        while (true)
        {
            Console.WriteLine("\n--- Ticket Booking System Task 6 ---");
            Console.WriteLine("1. Create Movie Event");
            Console.WriteLine("2. Create Concert Event");
            Console.WriteLine("3. Create Sports Event");
            Console.WriteLine("4. Book Tickets");
            Console.WriteLine("5. Get Available Seats");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Create Movie Event
                    Movie_Task6 movie = new Movie_Task6();
                    Console.WriteLine("\n--- Create Movie Event ---");
                    Console.Write("Enter Movie Name: ");
                    movie.EventName = Console.ReadLine();
                    Console.Write("Enter Movie Date (yyyy-mm-dd): ");
                    movie.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Movie Time (hh:mm): ");
                    movie.EventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    movie.VenueName = Console.ReadLine();
                    Console.Write("Enter Total Seats: ");
                    movie.TotalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Available Seats: ");
                    movie.AvailableSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    movie.TicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Genre: ");
                    movie.Genre = Console.ReadLine();
                    Console.Write("Enter Actor Name: ");
                    movie.ActorName = Console.ReadLine();
                    Console.Write("Enter Actress Name: ");
                    movie.ActressName = Console.ReadLine();

                    bookingSystem.CreateEvent(movie); 
                    break;

                case "2": // Create Concert Event
                    Concert_Task6 concert = new Concert_Task6();
                    Console.WriteLine("\n--- Create Concert Event ---");
                    Console.Write("Enter Concert Name: ");
                    concert.EventName = Console.ReadLine();
                    Console.Write("Enter Concert Date (yyyy-mm-dd): ");
                    concert.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Concert Time (hh:mm): ");
                    concert.EventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    concert.VenueName = Console.ReadLine();
                    Console.Write("Enter Total Seats: ");
                    concert.TotalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Available Seats: ");
                    concert.AvailableSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    concert.TicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Artist Name: ");
                    concert.Artist = Console.ReadLine();
                    Console.Write("Enter Concert Type (Theatrical, Classical, Rock, Recital): ");
                    concert.ConcertType = Console.ReadLine();

                    bookingSystem.CreateEvent(concert); 
                    break;

                case "3": // Create Sports Event
                    Sports_Task6 sports = new Sports_Task6();
                    Console.WriteLine("\n--- Create Sports Event ---");
                    Console.Write("Enter Sports Event Name: ");
                    sports.EventName = Console.ReadLine();
                    Console.Write("Enter Sports Event Date (yyyy-mm-dd): ");
                    sports.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Sports Event Time (hh:mm): ");
                    sports.EventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    sports.VenueName = Console.ReadLine();
                    Console.Write("Enter Total Seats: ");
                    sports.TotalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Available Seats: ");
                    sports.AvailableSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    sports.TicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Sport Name: ");
                    sports.SportName = Console.ReadLine();
                    Console.Write("Enter Teams Playing (e.g., India vs Australia): ");
                    sports.TeamsName = Console.ReadLine();

                    bookingSystem.CreateEvent(sports); 
                    break;

                case "4": // Book Tickets
                    Console.WriteLine("Enter the event name to book tickets:");
                    string eventNameToBook = Console.ReadLine();
                    Console.WriteLine("Enter number of tickets to book:");
                    int ticketsToBook = int.Parse(Console.ReadLine());

                    foreach (var eventObj in bookingSystem.events)
                    {
                        if (eventObj.EventName.Equals(eventNameToBook, StringComparison.OrdinalIgnoreCase))
                        {
                            bookingSystem.BookTickets(eventObj, ticketsToBook); 
                            break;
                        }
                    }
                    break;

                case "5": // Get Available Seats
                    Console.WriteLine("Enter the event name to get available seats:");
                    string eventNameToCheck = Console.ReadLine();

                    foreach (var eventObj in bookingSystem.events)
                    {
                        if (eventObj.EventName.Equals(eventNameToCheck, StringComparison.OrdinalIgnoreCase))
                        {
                            int availableSeats = bookingSystem.GetAvailableSeats(eventObj); 
                            Console.WriteLine($"Available seats for {eventObj.EventName}: {availableSeats}");
                            break;
                        }
                    }
                    break;

                case "6": // Exit
                    Console.WriteLine("Exiting the system. Thank you!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Task 7 Method (Has A Relation / Association)
    static void Task7()
    {
        IBookingSystem_Task7 bookingSystem = new BookingSystem_Task7();

        while (true)
        {
            Console.WriteLine("\n--- Ticket Booking System Task 7 ---");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Get Available Seats");
            Console.WriteLine("5. Get Event Details");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Event Name: ");
                    string eventName = Console.ReadLine();
                    Console.Write("Enter Event Date (yyyy-mm-dd): ");
                    DateTime eventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Event Time (hh:mm): ");
                    TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    string venueName = Console.ReadLine();
                    Console.Write("Enter Venue Address: ");
                    string address = Console.ReadLine();
                    Venue_Task7 venue = new Venue_Task7(venueName, address);
                    Console.Write("Enter Total Seats: ");
                    int totalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    decimal ticketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Event Type (Movie, Concert, Sports): ");
                    string eventType = Console.ReadLine();

                    bookingSystem.CreateEvent(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType);
                    break;

                case "2":
                    Console.Write("Enter Event Name to Book: ");
                    string bookEventName = Console.ReadLine();
                    Console.Write("Enter Number of Tickets: ");
                    int numTickets = int.Parse(Console.ReadLine());

                    List<Customer_Task7> customers = new List<Customer_Task7>();
                    for (int i = 0; i < numTickets; i++)
                    {
                        Console.WriteLine($"Enter details for Customer {i + 1}:");
                        Console.Write("Name: ");
                        string customerName = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string phoneNumber = Console.ReadLine();

                        customers.Add(new Customer_Task7(customerName, email, phoneNumber));
                    }

                    bookingSystem.BookTickets(bookEventName, numTickets, customers);
                    break;

                case "3":
                    Console.Write("Enter Booking ID to Cancel: ");
                    int bookingId = int.Parse(Console.ReadLine());
                    bookingSystem.CancelBooking(bookingId);
                    break;

                case "4":
                    Console.Write("Enter Event Name: ");
                    string availableSeatsEvent = Console.ReadLine();
                    int availableSeats = bookingSystem.GetAvailableNoOfTickets(availableSeatsEvent);
                    Console.WriteLine($"Available Seats for {availableSeatsEvent}: {availableSeats}");
                    break;

                case "5":
                    Console.Write("Enter Event Name: ");
                    string eventDetailsName = Console.ReadLine();
                    Event_Task7 eventDetails = bookingSystem.GetEventDetails(eventDetailsName);
                    if (eventDetails != null)
                    {
                        Console.WriteLine($"Event: {eventDetails.EventName}, Date: {eventDetails.EventDate.ToShortDateString()}, " +
                                          $"Time: {eventDetails.EventTime}, Venue: {eventDetails.Venue.VenueName}, " +
                                          $"Total Seats: {eventDetails.TotalSeats}, Available Seats: {eventDetails.AvailableSeats}");
                    }
                    else
                    {
                        Console.WriteLine("Event not found.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Exiting the system.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    //Task8
    static void Task8()
    {
        IBookingSystemServiceProvider_Task8 bookingSystem = new BookingSystemServiceProviderImpl_Task8();

        while (true)
        {
            Console.WriteLine("\n--- Ticket Booking System Task 8 ---");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Get Available Seats");
            Console.WriteLine("5. Get Event Details");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Create Event
                    Console.Write("Enter Event Name: ");
                    string eventName = Console.ReadLine();
                    Console.Write("Enter Event Date (yyyy-mm-dd): ");
                    DateTime eventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Event Time (hh:mm): ");
                    TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Enter Venue Name: ");
                    string venueName = Console.ReadLine();
                    Console.Write("Enter Venue Address: ");
                    string address = Console.ReadLine();
                    Venue venue = new Venue(venueName, address);
                    Console.Write("Enter Total Seats: ");
                    int totalSeats = int.Parse(Console.ReadLine());
                    Console.Write("Enter Ticket Price: ");
                    decimal ticketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Event Type (Movie, Concert, Sports): ");
                    string eventType = Console.ReadLine();

                    bookingSystem.CreateEvent(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType);
                    break;

                case "2": // Book Tickets
                    Console.Write("Enter Event Name to Book: ");
                    string bookEventName = Console.ReadLine();
                    Console.Write("Enter Number of Tickets: ");
                    int numTickets = int.Parse(Console.ReadLine());

                  
                    Event eventToBook = bookingSystem.GetEventDetails().Find(ev => ev.EventName.Equals(bookEventName, StringComparison.OrdinalIgnoreCase));

                    if (eventToBook != null)
                    {
                        List<Customer> customers = new List<Customer>();
                        for (int i = 0; i < numTickets; i++)
                        {
                            Console.WriteLine($"Enter details for Customer {i + 1}:");
                            Console.Write("Name: ");
                            string customerName = Console.ReadLine();
                            Console.Write("Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Phone Number: ");
                            string phoneNumber = Console.ReadLine();

                            customers.Add(new Customer(customerName, email, phoneNumber));
                        }

                        bookingSystem.BookTickets(bookEventName, numTickets, customers);
                    }
                    else
                    {
                        Console.WriteLine("Event not found.");
                    }
                    break;

                case "3": // Cancel Booking
                    Console.Write("Enter Booking ID to Cancel: ");
                    int bookingId = int.Parse(Console.ReadLine());
                    bookingSystem.CancelBooking(bookingId);
                    break;

                case "4": // Get Available Seats
                    Console.Write("Enter Event Name: ");
                    string availableSeatsEvent = Console.ReadLine();
                    int availableSeats = bookingSystem.GetAvailableNoOfTickets(availableSeatsEvent);
                    Console.WriteLine($"Available Seats for {availableSeatsEvent}: {availableSeats}");
                    break;

                case "5": // Get Event Details
                    Console.Write("Enter Event Name: ");
                    string eventDetailsName = Console.ReadLine();
                    Event eventDetails = bookingSystem.GetEventDetails().Find(ev => ev.EventName.Equals(eventDetailsName, StringComparison.OrdinalIgnoreCase));
                    if (eventDetails != null)
                    {
                        Console.WriteLine($"Event: {eventDetails.EventName}, Date: {eventDetails.EventDate.ToShortDateString()}, " +
                                          $"Time: {eventDetails.EventTime}, Venue: {eventDetails.Venue.VenueName}, " +
                                          $"Total Seats: {eventDetails.TotalSeats}, Available Seats: {eventDetails.AvailableSeats}");
                    }
                    else
                    {
                        Console.WriteLine("Event not found.");
                    }
                    break;

                case "6": // Exit
                    Console.WriteLine("Exiting the system. Thank you!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    //Task9
    static void Task9()
    {
        IBookingSystemServiceProvider_Task9 bookingSystem = new BookingSystemServiceProvider_Task9();

        while (true)
        {
            try
            {
                Console.WriteLine("\n--- Ticket Booking System Task 9 ---");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Get Available Seats");
                Console.WriteLine("5. Get Event Details");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Create Event
                        Console.Write("Enter Event Name: ");
                        string eventName = Console.ReadLine();
                        Console.Write("Enter Event Date (yyyy-mm-dd): ");
                        DateTime eventDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter Event Time (hh:mm): ");
                        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());
                        Console.Write("Enter Venue Name: ");
                        string venueName = Console.ReadLine();
                        Console.Write("Enter Venue Address: ");
                        string address = Console.ReadLine();
                        Venue_Task9 venue = new Venue_Task9(venueName, address);
                        Console.Write("Enter Total Seats: ");
                        int totalSeats = int.Parse(Console.ReadLine());
                        Console.Write("Enter Ticket Price: ");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Event Type (Movie, Concert, Sports): ");
                        string eventType = Console.ReadLine();

                        bookingSystem.CreateEvent(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType);
                        break;

                    case "2": // Book Tickets
                        Console.Write("Enter Event Name to Book: ");
                        string bookEventName = Console.ReadLine();
                        Console.Write("Enter Number of Tickets: ");
                        int numTickets = int.Parse(Console.ReadLine());

                        List<Customer_Task9> customers = new List<Customer_Task9>();
                        for (int i = 0; i < numTickets; i++)
                        {
                            Console.WriteLine($"Enter details for Customer {i + 1}:");
                            Console.Write("Name: ");
                            string customerName = Console.ReadLine();
                            Console.Write("Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Phone Number: ");
                            string phoneNumber = Console.ReadLine();

                            customers.Add(new Customer_Task9(customerName, email, phoneNumber));
                        }

                        bookingSystem.BookTickets(bookEventName, numTickets, customers);
                        break;

                    case "3": // Cancel Booking
                        Console.Write("Enter Booking ID to Cancel: ");
                        int bookingId = int.Parse(Console.ReadLine());
                        bookingSystem.CancelBooking(bookingId);
                        break;

                    case "4": // Get Available Seats
                        Console.Write("Enter Event Name: ");
                        string availableSeatsEvent = Console.ReadLine();
                        int availableSeats = bookingSystem.GetAvailableNoOfTickets(availableSeatsEvent);
                        Console.WriteLine($"Available Seats for {availableSeatsEvent}: {availableSeats}");
                        break;

                    case "5": // Get Event Details
                        Console.Write("Enter Event Name: ");
                        string eventDetailsName = Console.ReadLine();
                        Event_Task9 eventDetails = bookingSystem.GetEventDetails(eventDetailsName);
                        if (eventDetails != null)
                        {
                            Console.WriteLine($"Event: {eventDetails.EventName}, Date: {eventDetails.EventDate.ToShortDateString()}, " +
                                              $"Time: {eventDetails.EventTime}, Venue: {eventDetails.Venue.VenueName}, " +
                                              $"Total Seats: {eventDetails.TotalSeats}, Available Seats: {eventDetails.AvailableSeats}");
                        }
                        else
                        {
                            Console.WriteLine("Event not found.");
                        }
                        break;

                    case "6": // Exit
                        Console.WriteLine("Exiting the system. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    // Task 10 Method (Collections)
    static void Task10()
    {
        IBookingSystemRepository_Task10 bookingRepository = new BookingSystemRepositoryImpl_Task10();

        while (true)
        {
            Console.WriteLine("\n--- Ticket Booking System ---");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Get Available Seats");
            Console.WriteLine("5. Get Event Details");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1": // Create Event
                        Console.WriteLine("\n--- Create Event ---");
                        Console.Write("Enter Event ID: ");
                        int eventId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Event Name: ");
                        string eventName = Console.ReadLine();

                        Console.Write("Enter Event Date (yyyy-mm-dd): ");
                        DateTime eventDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Event Time (hh:mm): ");
                        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());

                        Console.Write("Enter Venue Name: ");
                        string venueName = Console.ReadLine();

                        Console.Write("Enter Venue Address: ");
                        string venueAddress = Console.ReadLine();
                        Venue_Task10 venue = new Venue_Task10(venueName, venueAddress);

                        Console.Write("Enter Total Seats: ");
                        int totalSeats = int.Parse(Console.ReadLine());

                        Console.Write("Enter Ticket Price: ");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Event Type (Movie, Concert, Sports): ");
                        string eventType = Console.ReadLine();

                        
                        Event_Task10 newEvent = new Event_Task10(eventId, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType);

                        bookingRepository.CreateEvent(newEvent);

                        Console.WriteLine("Event created successfully!");
                        break;

                    case "2": // Book Tickets
                        Console.WriteLine("--- Book Tickets ---");
                        Console.Write("Enter Event Name: ");
                        string bookEventName = Console.ReadLine();

                        Console.Write("Enter Number of Tickets: ");
                        int numTickets = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Enter details for Customer 1:");
                        Console.Write("Customer Name: ");
                        string customerName = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        string phoneNumber = Console.ReadLine();

                        var customer = new Customer_Task10(customerName, email, phoneNumber);

                        var booking = new Booking_Task10(bookingRepository.GetEventDetails().Find(e => e.EventName.Equals(bookEventName, StringComparison.OrdinalIgnoreCase)),
                                                          new HashSet<Customer_Task10> { customer }, numTickets);

                        bookingRepository.BookTickets(booking);
                        Console.WriteLine("Booking successful!");
                        break;

                    case "3": // Cancel Booking
                        Console.WriteLine("--- Cancel Booking ---");
                        Console.Write("Enter Booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine());

                        bookingRepository.CancelBooking(bookingId);
                        Console.WriteLine("Booking cancelled successfully!");
                        break;

                    case "4": // Get Available Seats
                        Console.WriteLine("--- Get Available Seats ---");
                        Console.Write("Enter Event Name: ");
                        string availableSeatsEvent = Console.ReadLine();
                        int availableSeats = bookingRepository.GetAvailableNoOfTickets(availableSeatsEvent);
                        Console.WriteLine($"Available Seats for {availableSeatsEvent}: {availableSeats}");
                        break;

                    case "5": // Get Event Details
                        Console.WriteLine("--- Get Event Details ---");
                        foreach (var evt in bookingRepository.GetEventDetails())
                        {
                            Console.WriteLine($"Event ID: {evt.EventId}, Name: {evt.EventName}, Date: {evt.EventDate.ToShortDateString()}, Time: {evt.EventTime}, " +
                                              $"Venue: {evt.Venue.VenueName}, Total Seats: {evt.TotalSeats}, Available Seats: {evt.AvailableSeats}, " +
                                              $"Ticket Price: {evt.TicketPrice}, Type: {evt.EventType}");
                        }
                        break;

                    case "6": // Exit
                        Console.WriteLine("Exiting the system. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }

    //Task 11 DBConnection
    static void Task11()
    {
        IBookingSystemRepository_Task11 bookingRepository = new BookingSystemRepositoryImpl_Task11();

        while (true)
        {
            Console.WriteLine("\n--- Ticket Booking System ---");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Get Available Seats");
            Console.WriteLine("5. Get Event Details");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1": 
                        Console.WriteLine("\n--- Create Event ---");
                        Console.WriteLine("Enter EventId");
                        int eventid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Event Name: ");
                        string eventName = Console.ReadLine();

                        Console.Write("Enter Event Date (yyyy-mm-dd): ");
                        DateTime eventDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Event Time (hh:mm): ");
                        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());

                        Console.Write("Enter Venue Name: ");
                        string venueName = Console.ReadLine();

                        Console.Write("Enter Venue Address: ");
                        string venueAddress = Console.ReadLine();
                        Venue_Task11 venue = new Venue_Task11(venueName, venueAddress);

                        Console.Write("Enter Total Seats: ");
                        int totalSeats = int.Parse(Console.ReadLine());

                        Console.Write("Enter Ticket Price: ");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Event Type (Movie, Concert, Sports): ");
                        string eventType = Console.ReadLine();

                        Event_Task11 newEvent = new Event_Task11(eventid, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType);

                        bookingRepository.CreateEvent(newEvent);

                        Console.WriteLine("Event created successfully!");
                        break;

                    case "2":

                        Console.WriteLine("--- Book Tickets ---");
                        Console.Write("Enter Event Name: ");
                        string eventNameToBook = Console.ReadLine();
                        Console.Write("Enter Number of Tickets: ");
                        int numTicketsToBook = int.Parse(Console.ReadLine());

                        Event_Task11 eventToBook = bookingRepository.GetEventByName(eventNameToBook);
                        if (eventToBook == null)
                        {
                            Console.WriteLine("Event not found. Please check the event name.");
                            break; 
                        }

                        // Create a list of customers
                        List<Customer_Task11> customers = new List<Customer_Task11>();
                        for (int i = 0; i < numTicketsToBook; i++)
                        {
                            Console.WriteLine($"Enter details for Customer {i + 1}:");
                            Console.Write("Customer Name: ");
                            string customerName = Console.ReadLine();
                            Console.Write("Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Phone Number: ");
                            string phoneNumber = Console.ReadLine();

                            customers.Add(new Customer_Task11(customerName, email, phoneNumber));
                        }

                        // Create a new booking
                        try
                        {
                            var booking = new Booking_Task11(eventToBook, customers, numTicketsToBook);
                            bookingRepository.BookTickets(booking); 
                            Console.WriteLine("Booking successful!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred while booking tickets: " + ex.Message);
                        }
                        break;

                    case "3":
                        // Cancel booking
                        Console.WriteLine("--- Cancel Booking ---");
                        Console.Write("Enter Booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine());

                        try
                        {
                            bookingRepository.CancelBooking(bookingId);
                            Console.WriteLine("Booking canceled successfully!");
                        }
                        catch (InvalidBookingIDException ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        break;

                    case "4":
                        // Get available seats
                        break;

                    case "5":
                         //Get event details
                        Console.WriteLine("\n--- Get Event Details ---");
                        var events = bookingRepository.GetEventDetails();
                        foreach (var ev in events)
                        {
                            Console.WriteLine($"Event: {ev.EventName}, Date: {ev.EventDate}, Time: {ev.EventTime}, Venue: {ev.Venue.VenueName}, Total Seats: {ev.TotalSeats}, Available Seats: {ev.AvailableSeats}, Ticket Price: {ev.TicketPrice}, Type: {ev.EventType}");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting the system. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

}



