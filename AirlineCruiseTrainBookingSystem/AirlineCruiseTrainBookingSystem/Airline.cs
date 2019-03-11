using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class Airline
    {
        private readonly Dictionary<string, Flight> _flights = new Dictionary<string, Flight>();
        public Dictionary<string, Flight> Flights => _flights;

        private string _name;

        public Airline(string name)
        {
            _name = name;
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 6)
                {
                    throw new InvalidOperationException();
                }

                _name = value;
            }
        }
    }
}