CREATE DATABASE TBSAssignment;
GO

USE TBSAssignment;

CREATE TABLE Venue (
    VenueId INT IDENTITY(1,1) PRIMARY KEY,
    VenueName VARCHAR(100) NOT NULL,
    Address VARCHAR(255) NOT NULL
);

CREATE TABLE Event (
    EventId INT IDENTITY(1,1) PRIMARY KEY,
    EventName VARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    EventTime TIME NOT NULL,
    VenueId INT NOT NULL FOREIGN KEY REFERENCES Venue(VenueId),
    TotalSeats INT NOT NULL,
    AvailableSeats INT NOT NULL,
    TicketPrice DECIMAL(10, 2) NOT NULL,
    EventType VARCHAR(50) CHECK (EventType IN ('Movie', 'Sports', 'Concert')) NOT NULL
);

CREATE TABLE Customer (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL
);

CREATE TABLE Booking (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    EventId INT NOT NULL FOREIGN KEY REFERENCES Event(EventId),
    TotalCost DECIMAL(10, 2) NOT NULL,
    NumTickets INT NOT NULL,
    BookingDate DATETIME DEFAULT GETDATE()
);


CREATE TABLE Customer_Booking (
    CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerId),
    BookingId INT NOT NULL FOREIGN KEY REFERENCES Booking(BookingId),
    PRIMARY KEY (CustomerId, BookingId)
);


INSERT INTO Venue (VenueName, Address) 
VALUES 
('Grand Hall', '123 Main St'),
('Stadium', '456 Oak St'),
('Cinema Complex', '789 Pine St');


INSERT INTO Event (EventName, EventDate, EventTime, VenueId, TotalSeats, AvailableSeats, TicketPrice, EventType)
VALUES 
('Rock Concert', '2024-12-10', '18:00', 1, 300, 300, 100.00, 'Concert'),
('Football Match', '2024-11-05', '16:00', 2, 50000, 50000, 50.00, 'Sports'),
('Movie Premiere', '2024-10-20', '20:00', 3, 100, 100, 10.00, 'Movie');

INSERT INTO Customer (CustomerName, Email, PhoneNumber)
VALUES 
('John Doe', 'john@example.com', '555-1234'),
('Jane Smith', 'jane@example.com', '555-5678');


INSERT INTO Booking (EventId, TotalCost, NumTickets)
VALUES
(1, 200.00, 2),
(2, 100.00, 2),
(3, 350.00,3);


INSERT INTO Customer_Booking (CustomerId, BookingId)
VALUES
(1, 1),  -- John Doe's booking for Rock Concert
(2, 1),  -- Jane Smith's booking for Rock Concert
(1, 2);