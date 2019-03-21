using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class Airline
    {
        public Dictionary<string, Flight> Flights { get; } = new Dictionary<string, Flight>();

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