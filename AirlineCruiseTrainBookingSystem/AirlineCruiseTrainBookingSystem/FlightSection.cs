using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem
{
    public class FlightSection
    {
        public string Air { get; }
        public string FlId { get; }
        public SeatClass SeatClass { get; }
        public int[,] Seating { get; set; }

        public List<Seat> Seats = new List<Seat>();

        public FlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            Air = air;
            FlId = flId;
            SeatClass = seatClass;
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
        /// <summary>
        /// An element of array having a value of 1 indicates it has been booked.
        /// </summary>
        /// <param name="row">Row of airplane section</param>
        /// <param name="col">Column of airplane section from A-J</param>
        public void bookSeat(int row, char col)
        {
            Seats.Add(new Seat(row, col));
        }
    }
}