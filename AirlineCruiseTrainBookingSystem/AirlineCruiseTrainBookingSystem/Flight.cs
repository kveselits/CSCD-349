using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class Flight
    {
        public Dictionary<SeatClass, FlightSection> Sections { get; }
        public string Aname { get; }
        public string Orig { get; }
        public string Dest { get; }
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public Flight(string aname, string orig, string dest, int year, int month, int day)
        {
            Aname = aname;
            Orig = orig;
            Dest = dest;
            Year = year;
            Month = month;
            Day = day;
        }
    }
}