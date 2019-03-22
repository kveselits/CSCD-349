﻿using System;
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

            Res.AirportCodes = matches[0].Groups[1].ToString();
            string airlineFlightData = matches[0].Groups[2].ToString();

            RegisterFlightData(airlineFlightData);
            BookingInterface uI = new BookingInterface(Res);
            while (true)
            {
                uI.StartUp();
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

                    var seatClass0 = (SeatClass) Convert.ToInt32(Convert.ToChar((group0[1].Value)));
                    var SeatClass1 = (SeatClass) Convert.ToInt32(Convert.ToChar((group1[1].Value)));
                    Res.createSection(tempNames.Peek(), tempIDs.Peek(), seatClass0, Convert.ToInt32(group0[2].Value),
                        Convert.ToChar(group0[3].Value), Convert.ToInt32(group0[4].Value));
                    Res.createSection(tempNames.Peek(), tempIDs.Peek(), SeatClass1, Convert.ToInt32(group1[2].Value),
                        Convert.ToChar(group1[3].Value), Convert.ToInt32(group1[4].Value));
                }
            }
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