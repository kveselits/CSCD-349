using System;

namespace AirlineCruiseTrainBookingSystem
{
    public class FlightSection
    {
        public string Air { get; }
        public string FlId { get; }
        public SeatClass SeatClass { get; }
        private int[,] _seats;

        public FlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            Air = air;
            FlId = flId;
            SeatClass = seatClass;
            _seats = new int[rows, cols];

        }
    }
}