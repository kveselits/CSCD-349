namespace AirlineCruiseTrainBookingSystem
{
    public class Seat
    {
        public Seat(int row, char column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public char Column { get; set; }
        public bool Booked { get; } = false;
    }
}