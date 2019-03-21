using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class Flight
    {
        private readonly string _dest;
        private readonly string _orig;
        private readonly string _aname;
        private DateTime _time;
        private readonly Dictionary<SeatClass, FlightSection> _sections = new Dictionary<SeatClass, FlightSection>();

        public Dictionary<SeatClass, FlightSection> Sections => _sections;

        public DateTime Time
        {
            get => _time;
            set => _time = value;
        }

        public string Aname => _aname;

        public string Orig => _orig;

        public string Dest => _dest;


        public Flight(string aname, string orig, string dest, DateTime time)
        {
            _aname = aname;
            _orig = orig;
            _dest = dest;
            Time = time;
        }

    }
}