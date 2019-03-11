using System;
using System.Collections.Generic;
using System.Linq;

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
        /*/// <summary>
        /// An element of array having a value of 1 indicates it has been booked.
        /// </summary>
        /// <param name="row">Row of airplane section</param>
        /// <param name="col">Column of airplane section from A-J</param>
        public void bookSeat(int row, char col)
        {
            Seats.Add(new Seat(row, col, true));
            string charToString = Char.ToString(col);
            int stringToInt = TextToNumber(charToString) - 1;
            Seating[row, stringToInt] = 1;

        }
        /// <summary>
        /// Algorithm from:
        /// https://stackoverflow.com/questions/1951517/convert-a-to-1-b-to-2-z-to-26-and-then-aa-to-27-ab-to-28-column-indexes-to
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static int TextToNumber(string text)
        {
            return text
                .Select(c => c - 'A' + 1)
                .Aggregate((sum, next) => sum * 26 + next);
        }*/
        public bool bookSeat(int row, char col)
        {
            if (Seats.Any(item => item.Row == row && item.Column == col))
                return false;
            Seats.Add(new Seat(row, col, true));
            return true;
        }
    }
}