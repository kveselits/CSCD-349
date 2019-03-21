namespace AirlineCruiseTrainBookingSystem
{
    public class Seat
    {
        public int Row { get; }
        public int Column { get; }
        public int SeatPrice { get; set; }
        public bool Booked { get; set; }

        public Seat(int row, int column, int seatPrice)
        {
            Row = row;
            Column = column;
            SeatPrice = seatPrice;
        }
    }
}