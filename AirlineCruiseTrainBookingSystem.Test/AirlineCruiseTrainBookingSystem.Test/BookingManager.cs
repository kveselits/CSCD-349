using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AirlineCruiseTrainBookingSystem.Test
{
    class BookingManager
    {
        private static SystemManager Res { get; } = new SystemManager();

        private static List<Regex> RegexPatterns { get; } = new List<Regex>()
        {
            new Regex("(\\[[A-Z]{3}[^\\]]+\\])(\\{.*?\\})", RegexOptions.IgnoreCase), //Matches Airport Codes and Airlines
            new Regex("[A-Z]{0,6}", RegexOptions.IgnoreCase), //Matches Airline names less than 6 characters
            new Regex("(\\w{0,4})\\|(\\d{4}..\\d{1,2}..\\d{1,2}..\\d{1,2}..\\d{1,2})\\|(\\w{3})\\|(\\w{3})", RegexOptions.IgnoreCase), //Matches Flight ID, Date, and Origin/Destination
            new Regex("(\\w):(\\d{3,4}):(\\w):(\\d)", RegexOptions.IgnoreCase) //Matches seating arrangements
        };

        public static void Main(string[] args)
        {
            string flightData = LoadFlightData();
            MatchCollection matches = RegexPatterns[0].Matches(flightData);
            if (matches.Count == 0)
                Console.WriteLine("Invalid input: no flight data found.");

            string airportCodes = matches[0].Groups[1].ToString();
            string airlineFlightData = matches[0].Groups[2].ToString();

            RegisterFlightData(airlineFlightData);
            BookingInterface uI = new BookingInterface(Res);
            uI.StartUp();
        }

        private static void RegisterFlightData(string flightData)
        {
            Stack<string> tempNames = new Stack<string>();
            Stack<string> tempIDs = new Stack<string>();
            string airlineData = flightData.Split('{', '}')[1];
            string[] separatingCharacters = { "[", "]," };
            string[] airlineFlights = airlineData.Split(separatingCharacters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var airline in airlineFlights)
            {
                MatchCollection airlineNames;
                MatchCollection flightInfo;
                MatchCollection seatingArrangements;

                if ((airlineNames = RegexPatterns[1].Matches(airline)).Count > 0 && airline.Length < 6)
                {
                    Res.createAirline(airline);
                    tempNames.Push(airline);
                }

                if ((flightInfo = RegexPatterns[2].Matches(airline)).Count > 0 && airline.Length >= 6)
                {
                    GroupCollection match = flightInfo[0].Groups;
                    tempIDs.Push(match[1].ToString());
                    string[] date = match[2].ToString().Trim().Split(',');

                    Res.createFlight(tempNames.Peek(), match[3].ToString(), match[4].ToString(),
                        Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]),
                        Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), match[1].ToString());
                }

                if ((seatingArrangements = RegexPatterns[3].Matches(airline)).Count > 0 && airline.Length >= 6)
                {
                    Match group0 = seatingArrangements[0];
                    Match group1 = seatingArrangements[1];

                    var class0 = (SeatClass)Convert.ToChar(group0.Groups[1].ToString());
                    var class1 = (SeatClass)Convert.ToChar(group1.Groups[1].ToString());
                    Res.createSection(tempNames.Peek(), tempIDs.Peek(), class0, Convert.ToInt32(group0.Groups[2].Value),
                        Convert.ToChar(group0.Groups[3].Value), Convert.ToInt32(group0.Groups[4].Value));
                    Res.createSection(tempNames.Peek(), tempIDs.Peek(), class1, Convert.ToInt32(group1.Groups[2].Value),
                        Convert.ToChar(group1.Groups[3].Value), Convert.ToInt32(group1.Groups[4].Value));
                }
            }
        }

        private static void RunTests()
        {
            Res.createAirport("DEN");
            Res.createAirport("DFW");
            Res.createAirport("LON");
            Res.createAirport("DEN");//invalid
            Res.createAirport("DENW");//invalid

            Res.createAirline("DELTA");
            Res.createAirline("AMER");
            Res.createAirline("FRONT");
            Res.createAirline("FRONTIER"); //invalid
            Res.createAirline("FRONT"); //invalid

            Res.createFlight("DELTA", "DEN", "LON", 2018, 10, 10, 10, 10, "123");
            Res.createFlight("DELTA", "DEN", "DEN", 2018, 8, 8, 10, 10, "567abc");//same airprt
            Res.createFlight("DEL", "DEN", "LON", 2018, 9, 8, 10, 10, "567"); //invalid airline
            Res.createFlight("DELTA", "LON33", "DEN33", 2019, 5, 7, 10, 10, "123");//invalid airports
            Res.createFlight("AMER", "DEN", "LON", 2010, 40, 100, 10, 10, "123abc");//invalid date


            /*Res.createSection("DELTA", "123", SeatClass.economy, 200, 's', 2);
            Res.createSection("DELTA", "123", SeatClass.first, 1000, 'W', 3);
            Res.createSection("DELTA", "123", SeatClass.first, 1200, 'M', 5);//Invalid 
            Res.createSection("SWSERTT", "123", SeatClass.economy, 300, 's', 2);//Invalid airline*/


            Res.bookSeat("DELTA", "123", SeatClass.first, 1, 2);
            Res.bookSeat("DELTA", "123", SeatClass.economy, 1, 2);
            Res.bookSeat("DELTA", "123", SeatClass.economy, 1, 2);
            Res.bookSeat("DELTA888", "123", SeatClass.business, 1, 3); //Invalid airline
            Res.bookSeat("DELTA", "123haha7", SeatClass.business, 1, 3); //Invalid flightId
            Res.bookSeat("DELTA", "123", SeatClass.economy, 1, 4); //already booked

            Res.displaySystemDetails();

            Res.findAvailableFlights("DEN", "LON");
        }

        private static string LoadFlightData()
        {
            StreamReader sr = new StreamReader("C:\\Users\\kjuli\\Source\\Repos\\kveselits\\CSCD-349\\AirlineCruiseTrainBookingSystem\\AirlineCruiseTrainBookingSystem\\Boot.txt");
            StringBuilder sb = new StringBuilder();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.Append(line);
            }
            return sb.ToString();
        }
    }
}
