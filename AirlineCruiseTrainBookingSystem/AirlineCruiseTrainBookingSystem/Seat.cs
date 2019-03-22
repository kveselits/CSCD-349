namespace AirlineCruiseTrainBookingSystem
{
    public class Seat
    {

        public int Row { get; }
        public int Column { get; }
        public FlightSection.SeatPriceObject SeatPrice { get; }
        public string SeatId { get; }
        public bool Booked { get; set; }

        public Seat(int row, int column, FlightSection.SeatPriceObject seatPrice, string seatId)
        {
            Row = row;
            Column = column;
            SeatPrice = seatPrice;
            SeatId = $"{seatId}:{Column}:{Row}";
            SeatPrice = seatPrice;
        }

    }
}