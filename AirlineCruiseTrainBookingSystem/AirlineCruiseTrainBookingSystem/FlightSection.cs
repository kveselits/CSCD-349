using System;
using System.Collections.Generic;


namespace AirlineCruiseTrainBookingSystem
{
    public class FlightSection
    {
        public string Air { get; }

        public string FlId { get; }

        public SeatClass SeatClass { get; }

        public Dictionary<int, List<Seat>> Layout { get; }
        public string SeatId { get; set; }
        public SeatPriceObject SeatPrice { get; set; }

        public class SeatPriceObject
        {
            public int Price { get; set; }

            public SeatPriceObject(int price)
            {
                Price = price;
            }
        }

        public FlightSection(string air, string flId, SeatClass seatClass, char layout, int rows, int seatPrice)
        {
            Air = air;
            FlId = flId;
            SeatClass = seatClass;
            SeatPrice = new SeatPriceObject(seatPrice);
            SeatId = new string($"{air}:{flId}:{seatClass.ToString()}");
            Layout = CreateLayout(layout, rows);
        }



        private Dictionary<int, List<Seat>> CreateLayout(char layout, int rows)
        {
            layout = char.ToLower(layout);
            Dictionary<int, List<Seat>> tempLayout = new Dictionary<int, List<Seat>>();
            if (layout.Equals('s'))
                return (tempLayout = InitializeLayout(rows, 3, tempLayout));
            if (layout.Equals('m'))
                return (tempLayout = InitializeLayout(rows, 4, tempLayout));
            if (layout.Equals('w'))
                return (tempLayout = InitializeLayout(rows, 10, tempLayout));
            return tempLayout;
        }

        private Dictionary<int, List<Seat>> InitializeLayout(int rows, int column, Dictionary<int, List<Seat>> tempLayout)
        {
            int columns = column;
            for (int i = 1; i <= columns; i++)
            {
                tempLayout.Add(i, new List<Seat>());
                for (int j = 0; j < rows; j++)
                {
                    var seatPrice = SeatPrice;
                    tempLayout[i].Add(new Seat(j, i, seatPrice, SeatId));
                }
            }
            return tempLayout;
        }

        public bool hasAvailableSeats()
        {
            foreach (var column in Layout.Values)
            {
                foreach (var seat in column)
                {
                    if (!seat.Booked)
                        return true;
                }
            }

            return false;
        }
        public bool bookSeat(int col, int row)
        {
            if (Layout.Keys.Count >= col && Layout.Values.Count >= row)
            {
                if (!Layout[col][row].Booked)
                Layout[col][row].Booked = true;
                return true;
            }
            return false;
        }
    }
}