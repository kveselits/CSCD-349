using System;
using System.Linq;
using static AirlineCruiseTrainBookingSystem.Test.BookingManager;

namespace AirlineCruiseTrainBookingSystem.Test
{
    public class AdministratorInterface
    {
        public bool StartUp()
        {
            int selection = 0;
            Console.WriteLine($"\nPlease choose an option from the following list:\n" +
                              $"1: Create airports, airlines, and flights with flight sections and seats.\n" +
                              $"2: Create cruises, ports, trips, and ships with cabin sections and cabins.\n" +
                              $"3: Print the current state of the airline subsystem.\n" +
                              $"4: Print the current state of the cruise subsystem.\n" +
                              $"5: Quit");
            selection = BookingInterface.obtainSelection(1, 5);

            switch (selection)
            {
                case 1:
                    CreateAirportsAirlinesOrFlights();
                    break;
                case 2:
                    CreateCruisesPortsTripsOrShips();
                    break;
                case 3:
                    PrintAirlineSubsystem();
                    break;
                case 4:
                    PrintCruiseSubsytem();
                    break;
                case 5:
                    return false;
            }
            return true;
        }

        private void CreateAirportsAirlinesOrFlights()
        {
            int selection = 0;
            Console.WriteLine($"\nPlease choose an option from the following list:\n" +
                              $"1: Create airport: \n" +
                              $"2: Create airline: \n" +
                              $"3: Create Flight \n" +
                              $"4: Quit");
            selection = BookingInterface.obtainSelection(1, 4);
            bool worked;
            switch (selection)
            {
                case 1:
                    string airport;
                    do
                    {
                        Console.WriteLine("What would you like the airport to be named? (Airport codes are 3 characters long, for example: \"LAX\"");
                        airport = Console.ReadLine();
                        worked = Res.createAirport(airport);
                    } while (!worked);
                    Console.WriteLine($"Creating airport: {airport}");
                    break;
                case 2:
                    string airline;
                    do
                    {
                        Console.WriteLine("What would you like the airline to be named?");
                        airline = Console.ReadLine();
                        worked = Res.createAirport(airline);
                    } while (!worked);
                    Console.WriteLine($"Creating airline: {airline}");
                    break;
                case 3:
                    FlightCreationSystem();
                    break;
                case 4:
                    break;
            }
        }

        private void FlightCreationSystem()
        {
            Console.WriteLine("Flight creation system.\n");
            string flightAirline;
            do
            {
                Console.WriteLine("Please choose an airline: \n");
                flightAirline = Console.ReadLine();
            } while (!Res.Airlines.ContainsKey(flightAirline));

            string originAirport;
            do
            {
                Console.WriteLine("Please choose an origin airport: \n");
                originAirport = Console.ReadLine();
            } while (originAirport != null && !originAirport.Length.Equals(3));

            string destinationAirport;
            do
            {
                Console.WriteLine("Please choose a destination airport: \n");
                destinationAirport = Console.ReadLine();
            } while (destinationAirport != null && !destinationAirport.Length.Equals(3));

            Console.WriteLine("Please choose a date:");
            DateTime date = ObtainDateTime();

            string flightId;
            do
            {
                Console.WriteLine("Please choose a flight ID: (must contain at least one digit) \n");
                flightId = Console.ReadLine();
            } while (flightId != null && !flightId.Any(char.IsDigit));

            Console.WriteLine("Please choose a seating class");
            SeatClass seatingClass = BookingInterface.ChooseSeatingClass();

            Console.WriteLine("What would you like the seat price to be?");

            int seatingPrice = BookingInterface.obtainSelection(0, int.MaxValue);

            Console.WriteLine($"Please choose one of the following layouts: S, M, W" +
                              $"(where S is a seat layout with 3 columns with an aisle between columns 1 and 2, " +
                              $"M is a seat layout with 4 columns with an aisle between columns 2 and 3, and " +
                              $"W is a seat layout with 10 columns with aisles between columns 3 and 4, and between columns 7 and 8)");

            Console.WriteLine($"1: S \n" +
                              "2: M \n" +
                              "3: W \n");
            int layoutSelection = BookingInterface.obtainSelection(1, 3);
            char layout = 'S';
            if (layoutSelection == 1)
                layout = 'S';
            else if (layoutSelection == 2)
                layout = 'M';
            else if (layoutSelection == 3) layout = 'W';

            Console.WriteLine("How many rows would you like your layout to have? (between 1 and 100");
            int rows = BookingInterface.obtainSelection(1, 100);

            Console.WriteLine("Attempting to create flight...");

            if (!Res.createFlight(flightAirline, originAirport, destinationAirport, date.Year, date.Month,
                date.Day, date.Hour, date.Minute, flightId))
                Console.WriteLine("Failed to create flight.");
            Console.WriteLine("Successfully created flight.");
            if (!Res.createSection(flightAirline, flightId, seatingClass, seatingPrice, layout, rows))
                Console.WriteLine("Failed to create flight section");
            Console.WriteLine("Successfully created flight section");
        }

        private DateTime ObtainDateTime()
        {
            string input;
            DateTime year, month, day, hour, minute;
            do
            {
                Console.WriteLine("Please choose a year: (E.G., 2011) ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out year));
            do
            {
                Console.WriteLine("Please choose a month: (E.G., December (or 12) ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out month));
            do
            {
                Console.WriteLine("Please choose a day-of-month: (E.G., 31 ) ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out day));
            do
            {
                Console.WriteLine("Please choose a hour: (E.G., 16 (or 4) ) ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out hour));
            do
            {
                Console.WriteLine("Please choose a minute: (E.G., 30) ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out minute));

            return new DateTime(year.Year, month.Month, day.Day, hour.Hour, minute.Minute, 0);
        }

        private void CreateCruisesPortsTripsOrShips()
        {
            throw new NotImplementedException();
        }

        private void PrintAirlineSubsystem()
        {
            throw new NotImplementedException();
        }

        private void PrintCruiseSubsytem()
        {
            throw new NotImplementedException();
        }
    }
}