using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AirlineCruiseTrainBookingSystem
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SystemManager
    {
        private readonly Dictionary<string, Airport> Airports = new Dictionary<string, Airport>();
        private readonly Dictionary<string, Airline> Airlines = new Dictionary<string, Airline>();

        public void createAirport(string n)
        {
            if (n.Length != 3)
                Console.WriteLine("Invalid length. Airport name must be exactly 3 characters long.");
            if (!Airports.TryAdd(n, new Airport(n)))
                Console.WriteLine("Invalid operation: Airport name already exists.");
        }

        public void createAirline(string n)
        {
            if (n.Length < 6)
                Console.WriteLine("Invalid length. Airline name must be less than 6 characters long.");
            if (!Airlines.TryAdd(n, new Airline(n)))
                Console.WriteLine("Invalid operation: Airline name already exists.");
        }

        public void createFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            if (!Airlines[aname].Flights.TryAdd(id, new Flight(aname, orig, dest, year, month, day)))
                Console.WriteLine("Invalid operation: Flight ID already exists.");
        }


        public void createSection(string air, string flID, int rows, int cols, SeatClass s)
        {
            if (rows >= 100 && cols >= 10)
                if (!Airlines[air].Flights[flID].Sections.TryAdd(s, new FlightSection(air, flID, rows, cols, s)))
                    Console.WriteLine("Invalid Operation: Seat class already exists.");
            Console.WriteLine("Section must have no more than 100 rows and 10 columns.");
        }

        public void bookSeat(String air, String fl, SeatClass s, int row, char col)
        {
            if (Airlines[air].Flights[fl].Sections[s].hasAvailableSeats())
                Airlines[air].Flights[fl].Sections[s].bookSeat(row, col);
        }

        public void displaySystemDetails()
        {
            throw new NotImplementedException();
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
