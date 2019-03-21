using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class SystemManager
    {
        public Dictionary<string, Airport> Airports { get; } = new Dictionary<string, Airport>();
        public Dictionary<string, Airline> Airlines { get; } = new Dictionary<string, Airline>();

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

        public void createFlight(string aname, string orig, string dest, int year, int month, int day, int hour, int minute, string id)
        {
            var date = CreateDate(year, month, day, hour, minute);
            if (!date.Equals(DateTime.MinValue))//Checking for Default MinValue which indicates DateTime exception
            {
                if (!(orig.Equals(dest)))
                    if (Airlines.ContainsKey(aname))
                        if (!Airlines[aname].Flights.TryAdd(id, new Flight(aname, orig, dest, date, id)))
                            Console.WriteLine("Invalid operation: Flight ID already exists.");
            }
            if (orig.Equals(dest))
                Console.WriteLine("Origin cannot be the same as destination.");
            if (!Airlines.ContainsKey(aname))
                Console.WriteLine("Airport does not exist");
        }

        private static DateTime CreateDate(int year, int month, int day, int hour, int minute)
        {
            DateTime date = new DateTime();
            try
            {
                date = new DateTime(year, month, day, hour, minute, 0);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Date is impossible or in the past.");
                return new DateTime(); //DateTime defaults to MinValue
            }
            return date;
        }

        public void createSection(string air, string flID, SeatClass s, int seatPrice, char layout, int rows)
        {
            if (rows <= 100)
                if (Airlines.ContainsKey(air))
                    if (!Airlines[air].Flights[flID].Sections.TryAdd(s, new FlightSection(air, flID, s, layout, rows, seatPrice)))
                        Console.WriteLine("Invalid Operation: Seat class already exists.");
            if (rows >= 100)
                Console.WriteLine("Section must have no more than 100 rows and 10 columns.");
            if (!Airlines.ContainsKey(air))
                Console.WriteLine("Airline does not exist.");
        }

        public void bookSeat(String air, String fl, SeatClass s, int col, int row)
        {
            if (Airlines.ContainsKey(air))
                if (Airlines[air].Flights.ContainsKey(fl))
                    if (!Airlines[air].Flights[fl].Sections[s].bookSeat(col, row))
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
                    Console.WriteLine($"Flight Name:{flight.Aname} Flight ID: {flight.Id} Origin: {flight.Orig} Destination: {flight.Dest} Date: {flight.Time}");
                    foreach (var section in flight.Sections.Values)
                    {
                        Console.WriteLine($"Seating Class: {section.SeatClass}");
                        foreach (var column in section.Layout.Values)
                        {
                            foreach (var seat in column)
                            {
                                Console.WriteLine($"Seat: Row[{seat.Row}] Column[{seat.Column}] Seat Price: [{seat.SeatPrice}] Seat Available: [{seat.Booked}]");
                            }
                        }
                    }
                }
            }
        }
        public void displaySystemDetails(int selection)
        {
            switch (selection)
            {
                case 1:
                    foreach (var airport in Airports.Values)
                    {
                        Console.WriteLine(airport.Name);
                    }

                    break;
                case 2:
                    foreach (var airline in Airlines.Values)
                    {
                        Console.WriteLine(airline.Name);
                    }
                    break;
                case 3:
                    foreach (var airline in Airlines.Values)
                    {
                        foreach (var flight in airline.Flights.Values)
                        {
                            Console.WriteLine($"Flight Name:{flight.Aname} Flight ID: {flight.Id} Origin: {flight.Orig} Destination: {flight.Dest} Date: {flight.Time}");
                        }
                    }
                    break;
                case 4:
                    {
                        foreach (var airline in Airlines.Values)
                        {
                            foreach (var flight in airline.Flights.Values)
                            {
                                foreach (var section in flight.Sections.Values)
                                {
                                    Console.WriteLine($"Section Flight ID: {section.FlId} Seating Class: {section.SeatClass}");
                                }
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        foreach (var airline in Airlines.Values)
                        {
                            foreach (var flight in airline.Flights.Values)
                            {
                                foreach (var section in flight.Sections.Values)
                                {
                                    foreach (var column in section.Layout.Values)
                                    {
                                        foreach (var seat in column)
                                        {
                                            Console.WriteLine($"Seat: Row[{seat}] Column[{seat.Column}] Seat Price: [{seat.SeatPrice}] Seat Available: [{seat.Booked}]");
                                        }
                                    }
                                }
                            }
                        }
                        break;
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
    first = 'F',
    economy = 'E',
    business = 'B'
}
