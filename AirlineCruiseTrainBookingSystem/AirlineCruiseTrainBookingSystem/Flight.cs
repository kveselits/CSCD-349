using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class Flight
    {
        private List<FlightSection> _sections;
        private string Aname { get; }
        private string Orig { get; }
        private string Dest { get; }
        private int Year { get; }
        private int Month { get; }
        private int Day { get; }
        public string Id { get; }

        public Flight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            Aname = aname;
            Orig = orig;
            Dest = dest;
            Year = year;
            Month = month;
            Day = day;
            Id = id;
        }
    }
}