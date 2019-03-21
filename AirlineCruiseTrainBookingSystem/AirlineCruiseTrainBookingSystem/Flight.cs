using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class Flight
    {
        public Dictionary<SeatClass, FlightSection> Sections { get; } = new Dictionary<SeatClass, FlightSection>();

        public DateTime Date { get; set; }

        public string Aname { get; }

        public string Orig { get; }

        public string Dest { get; }
        public string Id { get; }


        public Flight(string aname, string orig, string dest, DateTime date, string id)
        {
            Aname = aname;
            Orig = orig;
            Dest = dest;
            Date = date;
            Id = id;
        }

    }
}