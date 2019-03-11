using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AirlineCruiseTrainBookingSystem
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SystemManager
    {
        private readonly Dictionary<string, Airport> Airports = new Dictionary<string, Airport>();
        private readonly Dictionary<string, Airline> Airlines = new Dictionary<string, Airline>();

        public void createAirport(string n)
        {
            if (n.Length.Equals(3))
                if (!Airports.TryAdd(n, new Airport(n)))
                    Console.WriteLine("Invalid operation: Airport name already exists.");
            if (n.Length != 3)
                Console.WriteLine("Invalid length. Airport name must be exactly 3 characters long.");
        }

        public void createAirline(string n)
        {
            if (n.Length < 6)
                if (!Airlines.TryAdd(n, new Airline(n)))
                    Console.WriteLine("Invalid operation: Airline name already exists.");
            if (!(n.Length < 6))
                Console.WriteLine("Invalid length. Airline name must be less than 6 characters long.");
        }

        public void createFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            var date = CreateDate(year, month, day);
            if (!date.Equals(DateTime.MinValue))//Checking for Default MinValue 
            {
                if (!(orig.Equals(dest)))
                    if (Airlines.ContainsKey(aname))
                        if (!Airlines[aname].Flights.TryAdd(id, new Flight(aname, orig, dest, date)))
                            Console.WriteLine("Invalid operation: Flight ID already exists.");
            }
            if (orig.Equals(dest))
                Console.WriteLine("Origin cannot be the same as destination.");
            if (!Airlines.ContainsKey(aname))
                Console.WriteLine("Airport does not exist");
        }

        private static DateTime CreateDate(int year, int month, int day)
        {
            DateTime date = new DateTime();
            try
            {
                date = new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Date is impossible or in the past.");
                return new DateTime(); //DateTime defaults to MinValue
            }
            return date;
        }

        public void createSection(string air, string flID, int rows, int cols, SeatClass s)
        {
            if (rows <= 100 && cols <= 10)
                if (Airlines.ContainsKey(air))
                    if (!Airlines[air].Flights[flID].Sections.TryAdd(s, new FlightSection(air, flID, rows, cols, s)))
                        Console.WriteLine("Invalid Operation: Seat class already exists.");
            if (rows >= 100 && cols >= 10)
                Console.WriteLine("Section must have no more than 100 rows and 10 columns.");
            if (!Airlines.ContainsKey(air))
                Console.WriteLine("Airline does not exist.");
        }

        public void bookSeat(String air, String fl, SeatClass s, int row, char col)
        {
            if (Airlines.ContainsKey(air))
                if (Airlines[air].Flights.ContainsKey(fl))
                    if (!Airlines[air].Flights[fl].Sections[s].bookSeat(row, col))
                        Console.WriteLine("Seat already booked.");
            if (!Airlines.ContainsKey(air))
                Console.WriteLine("Airline does not exist.");
        }

        public void displaySystemDetails()
        {
            foreach (var airport in Airports.Values)
            {
                Console.WriteLine(airport.Name);
            }
            foreach (var airline in Airlines.Values)
            {
                Console.WriteLine(airline.Name);
                foreach (var flight in airline.Flights.Values)
                {
                    Console.WriteLine($"Flight Name:{flight.Aname} Origin: {flight.Orig} Destination: {flight.Dest} Date: {flight.Time}");
                    foreach (var section in flight.Sections.Values)
                    {
                        Console.WriteLine($"Seating Class: {section.SeatClass}");
                        foreach (var seat in section.Seats)
                        {
                            Console.WriteLine($"Seat: Row[{seat.Row}] Column[{seat.Column}] Booked: {seat.Booked}");
                        }
                    }
                }
            }
        }

        public void findAvailableFlights(string orig, string dest)
        {
            List<object> AvailableFlights = new List<object>();
            foreach (var airline in Airlines.Values)
            {
                foreach (var flight in airline.Flights)
                {
                    if (flight.Value.Orig.Equals(orig) && flight.Value.Dest.Equals(dest))
                        foreach (var section in flight.Value.Sections)
                        {
                            if (section.Value.hasAvailableSeats())
                                AvailableFlights.Add(flight);
                        }
                }
            }
        }
    }
}

public enum SeatClass
{
    first,
    economy,
    business,
}
