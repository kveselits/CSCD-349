using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AirlineCruiseTrainBookingSystem.Test
{
    class BookingManager
    {
        public static SystemManager Res { get; } = new SystemManager();

        private static List<Regex> RegexPatterns { get; } = new List<Regex>()
        {
            new Regex("(\\[[A-Z]{3}[^\\]]+\\])(\\{.*?\\})", RegexOptions.IgnoreCase), // Matches Airport Codes and Airlines
            new Regex("[A-Z]{0,6}", RegexOptions.IgnoreCase), // Matches Airline names less than 6 characters
            new Regex("(\\w{0,4})\\|(\\d{4}..\\d{1,2}..\\d{1,2}..\\d{1,2}..\\d{1,2})\\|(\\w{3})\\|(\\w{3})", RegexOptions.IgnoreCase), //Matches Flight ID, Date, and Origin/Destination
            new Regex("(\\w):(\\d{3,4}):(\\w):(\\d)", RegexOptions.IgnoreCase), // Matches seating arrangements
            new Regex("(([A-Z]{3}))", RegexOptions.IgnoreCase) // Matches just airport codes.
        };

        public static void Main(string[] args)
        {
            BookingInterface uI = new BookingInterface();
            bool keepRunning = true;
            while (keepRunning)
            {
                keepRunning = uI.StartUp();
            }
        }
        public static void InitializeAirportSystem(string path)
        {
            MatchCollection matches = RegexPatterns[0].Matches(path);
            if (matches.Count == 0)
                Console.WriteLine("Invalid input: no flight data found.");

            string airportCodes = matches[0].Groups[1].ToString();
            string airlineFlightData = matches[0].Groups[2].ToString();

            RegisterFlightData(airlineFlightData);
            RegisterAirports(airportCodes);
        }

        public static string LoadFlightData(string path)
        {
            string line = null;
            try
            { 
                using (StreamReader sr = new StreamReader(path))
                {
                    line = sr.ReadToEnd();
                    Console.WriteLine($"Airport system loaded from: {Path.GetFullPath(path)}");
                    return line;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return line;
        }
        private static void RegisterAirports(string airportCodes)
        {
            string airportData = airportCodes.Split('[', ']')[1];
            string[] airports = airportData.Split(',');
            MatchCollection airportNames;
            foreach (var airport in airports)
            {
                if ((airportNames = RegexPatterns[4].Matches(airport.Trim())).Count > 0 && airport.Trim().Length < 4)
                {
                    Res.createAirport(airport.Trim());
                }
            }
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

                if ((airlineNames = RegexPatterns[1].Matches(airline.Trim())).Count > 0 && airline.Trim().Length < 6)
                {
                    Res.createAirline(airline.Trim());
                    tempNames.Push(airline.Trim());
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
                    GroupCollection group0 = seatingArrangements[0].Groups;
                    GroupCollection group1 = seatingArrangements[1].Groups;

                    var seatClass0 = (SeatClass)Convert.ToInt32(Convert.ToChar((group0[1].Value)));
                    var seatClass = (SeatClass)Convert.ToInt32(Convert.ToChar((group1[1].Value)));
                    Res.createSection(tempNames.Peek(), tempIDs.Peek(), seatClass0, Convert.ToInt32(group0[2].Value),
                        Convert.ToChar(group0[3].Value), Convert.ToInt32(group0[4].Value));
                    Res.createSection(tempNames.Peek(), tempIDs.Peek(), seatClass, Convert.ToInt32(group1[2].Value),
                        Convert.ToChar(group1[3].Value), Convert.ToInt32(group1[4].Value));
                }
            }
        }

        public static void WriteToFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            int i = 0;
            foreach (var airport in Res.Airports.Values)
            {
                i++;
                if (i != Res.Airports.Values.Count)
                    sb.Append($"{airport.Name}, ");
                if (i == Res.Airports.Values.Count)
                    sb.Append($"{airport.Name}]");
            }
            sb.Append('{');
            foreach (var airline in Res.Airlines.Values)
            {
                sb.Append($"{airline.Name}[");
                foreach (var flight in airline.Flights.Values)
                {
                    sb.Append(($"{flight.Id}|{flight.Date.Year}, {flight.Date.Month}, {flight.Date.Day}, {flight.Date.Hour}, {flight.Date.Minute}|{flight.Orig}|{flight.Dest}["));
                    i = 0;
                    foreach (var section in flight.Sections.Values)
                    {
                        i++;
                        if(i != flight.Sections.Values.Count)
                            sb.Append(
                                $"{section.SeatClass.ToString()[0]}:{section.SeatPrice.Price}:{char.ToUpper(section.SectionLayout)}:{section.SectionRows},");
                        if (i == flight.Sections.Count)
                            sb.Append(
                                $"{section.SeatClass.ToString()[0]}:{section.SeatPrice.Price}:{char.ToUpper(section.SectionLayout)}:{section.SectionRows}");
                    }
                    sb.Append("], ");
                }
            }

            sb.Append('}');
            string line = sb.ToString();

            string fixedLine = line.Remove((line.Length - 3), 2);
            using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\WriteFile.ams"))
            {
                outputFile.WriteLine(fixedLine);
                Console.WriteLine($"Airport system written to: {Path.GetFullPath("..\\..\\..\\WriteFile.ams")}");
            }
        }
    }
}
