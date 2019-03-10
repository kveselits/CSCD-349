using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class Airline
    {
        public List<Flight> Flights { get; }
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