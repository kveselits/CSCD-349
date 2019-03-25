using System;

namespace AirlineCruiseTrainBookingSystem
{
    public class Airport
    {
        private string _name;

        public Airport(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length != 3)
                {
                    throw new InvalidOperationException();
                }
                _name = value;
            }
        }
    }
}