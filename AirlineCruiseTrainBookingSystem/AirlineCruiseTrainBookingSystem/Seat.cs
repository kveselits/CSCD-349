namespace AirlineCruiseTrainBookingSystem
{
    public class Seat
    {
        public Seat(int row, char column, bool booked)
        {
            Row = row;
            Column = column;
            Booked = booked;
        }

        public int Row { get; set; }
        public char Column { get; set; }
        public bool Booked { get; } 
    }
}