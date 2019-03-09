using System;

namespace AirlineCruiseTrainBookingSystem
{
    public class Airline
    {
        private string _name;

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