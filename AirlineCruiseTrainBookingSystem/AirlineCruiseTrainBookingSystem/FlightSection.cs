using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlineCruiseTrainBookingSystem
{
    public class FlightSection
    {
        private readonly string _air;
        private readonly SeatClass _seatClass;
        private int[,] _seating;
        private readonly string _flId;
        public string Air => _air;

        public string FlId => _flId;

        public SeatClass SeatClass => _seatClass;

        public int[,] Seating
        {
            get => _seating;
            set => _seating = value;
        }

        public List<Seat> Seats = new List<Seat>();

        public FlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            _air = air;
            _flId = flId;
            _seatClass = seatClass;
            Seating = new int[rows, cols];
        }

        public bool hasAvailableSeats()
        {
            foreach (var seat in Seats)
            {
                if (seat.Equals(0))
                    return true;
            }
            return false;
        }
        public bool bookSeat(char col, int row)
        {
            if (Seats.Any(item => item.Row == row && item.Column == col))
                return false;
            Seats.Add(new Seat(row, col, true));
            return true;
        }
    }
}