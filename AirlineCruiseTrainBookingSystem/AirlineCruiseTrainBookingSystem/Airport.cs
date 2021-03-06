﻿using System;

namespace AirlineCruiseTrainBookingSystem
{
    public class Airport
    {
        private string _name;

        public Airport(string name)
        {
            _name = name;
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