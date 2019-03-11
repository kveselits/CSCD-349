namespace AirlineCruiseTrainBookingSystem
{
    public class Seat
    {
        private int _row;
        private char _column;
        private readonly bool _booked;

        public Seat(int row, char column, bool booked)
        {
            Row = row;
            Column = column;
            _booked = booked;
        }

        public int Row
        {
            get => _row;
            set => _row = value;
        }

        public char Column
        {
            get => _column;
            set => _column = value;
        }

        public bool Booked
        {
            get => _booked;
            set => throw new System.NotImplementedException();
        }
    }
}