using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AirlineCruiseTrainBookingSystem
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SystemManager
    {
        public List<Airport> Airports { get; }
        public List<Airline> Airlines { get; }

        public void createAirport(string n)
        {
            if (n.Length != 3)
                throw new ArgumentOutOfRangeException();
            var nameExists = NameExists(n);
            if (nameExists.Equals(false)) //check if airport already exists
                Airports.Add(new Airport(n));
        }

        private bool NameExists(string n)
        {
            bool nameExists = false;
            foreach (var airport in Airports)
            {
                if (airport.Name.Equals(n))
                    nameExists = true;
            }

            return nameExists;
        }

        public void createAirline(string n)
        {
            if (n.Length < 6)
                throw new ArgumentOutOfRangeException();
            var nameExists = NameExists(n);
            if(nameExists.Equals(false))
                Airlines.Add(new Airline(n));
        }

        public void createFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            var nameExists = DuplicateID(aname, id);
            if(nameExists.Equals(false))
            Flights.Add(new Flight(aname, orig, dest, year, month, day, id));
        }

        private bool DuplicateID(string aname, string id)
        {
            bool nameExists = false;
            foreach (Airline airline in Airlines)
            {
                if (airline.Name.Equals(aname))
                {
                    foreach (Flight flight in airline.Flights)
                    {
                        if (flight.Id.Equals(id))
                            nameExists = true;
                    }
                }
            }

            return nameExists;
        }

        public void createSection(string air, string flID, int rows, int cols, SeatClass s)
        {
            Airlines.Find(item => item.Name == "air").Find
        }
    }

    public enum SeatClass
    {
        first,
        economy,
        business,

    }
}
