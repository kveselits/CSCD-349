using System;
using System.Collections.Generic;

namespace AirlineCruiseTrainBookingSystem.Test
{
    public class BookingInterface
    {
        public SystemManager Res { get; set; }

        public BookingInterface(SystemManager res)
        {
            Res = res;
        }

        public bool StartUp()
        {
            int selection = 0;
            Console.WriteLine($"\nPlease choose an option from the following list:\n" +
                              $"1: Create an airport system by using information provided in an input file.\n" +
                              $"2: Change the price associated with seats in a flight section.\n" +
                              $"3: Query the system for flights with available seats\n" +
                              $"4: Change the seat class (e.g., economy) pricing for an origin and destination for a given airline.\n" +
                              $"5: Book a seat given a specific seat on a flight.\n" +
                              $"6: Book a seat on a flight given only a seating preference and seating class\n" +
                              $"7: Display details of the airport system\n" +
                              $"8: Save details to file\n" +
                              $"9: Quit");
            do
            {
                Console.WriteLine("Please select a valid option: ");
                var input = Console.ReadLine();
                int.TryParse(input, out selection);
            } while (selection < 1 || selection > 9);

            switch (selection)
            {
                case 1:
                    CreateAirportSystem();
                    break;
                case 2:
                    ChangePrice();
                    break;
                case 3:
                    QueryAvailableFlights();
                    break;
                case 4:
                    ChangeSeatClass();
                    break;
                case 5:
                    BookSpecificSeat();
                    break;
                case 6:
                    BookByPreference();
                    break;
                case 7:
                    DisplaySystemDetails();
                    break;
                case 8:
                    SaveDetailsToFile();
                    break;
                case 9:
                    return false;
            }
            return true;
        }

        private void SaveDetailsToFile()
        {
            throw new NotImplementedException();
        }

        private void BookByPreference()
        {
            throw new NotImplementedException();
        }

        private void BookSpecificSeat()
        {
            throw new NotImplementedException();
        }

        private void ChangeSeatClass()
        {
            throw new NotImplementedException();
        }

        private void QueryAvailableFlights()
        {
            Console.WriteLine("Please select an origin");
            string origin = Console.ReadLine();
            Console.WriteLine("Please select a destination");
            string destination = Console.ReadLine();
            SeatClass seatingClass = CreateSeatingClass();
            Console.WriteLine("Please select a date");
            string tempDate = Console.ReadLine();
            DateTime date = new DateTime();
            DateTime.TryParse(tempDate, out date);
            List<Flight> flights = Res.findAvailableFlights(origin, destination, seatingClass, date);

            foreach (var flight in flights)
            {
                Console.WriteLine(
                    $"Flight Name:{flight.Aname} Flight ID: {flight.Id} Origin: {flight.Orig} Destination: {flight.Dest} Date: {flight.Date} Price: {flight.Sections[seatingClass].SeatPrice}");
            }
            /*flight.Sections[seatingClass].SeatPrice;*/
        }

        private SeatClass CreateSeatingClass()
        {
            int selection;
            do
            {
                Console.WriteLine("Please select a seating class:\n" +
                                  "1: First\n" +
                                  "2: Economy\n" +
                                  "3: Business\n");
                var input = Console.ReadLine();
                int.TryParse(input, out selection);
            } while (selection < 1 || selection > 3);

            if (selection.Equals(1))
                return SeatClass.first;
            if (selection.Equals(2))
                return SeatClass.economy;
            return (SeatClass.business);
        }

        private void CreateAirportSystem()
        {
            throw new NotImplementedException();
        }

        private void DisplaySystemDetails()
        {
            int selection;
            Console.WriteLine($"\nPlease selection an option:\n" +
                              $"1: Display Airports\n" +
                              $"2: Display Airlines\n" +
                              $"3: Display Flight Names\n" +
                              $"4: Display Sections\n" +
                              $"5: Display Seating Arrangements \n");
            do
            {
                Console.WriteLine("Please select a valid option: ");
                var input = Console.ReadLine();
                int.TryParse(input, out selection);
            } while (selection < 1 || selection > 5);
            Res.displaySystemDetails(selection);
        }

        private void ChangePrice()
        {
            //Yeah, this got really messy...
            Console.WriteLine("Change the price associated with seats in a flight section " +
                              "(all seats in a flight section have the same price).");
            Console.WriteLine("Which Airline would you like to choose?");
            Res.displaySystemDetails(2);
            string input;
            do
            {
                Console.WriteLine("Please select an Airline: ");
                input = Console.ReadLine();
                if (!Res.Airlines.ContainsKey(input))
                    Console.WriteLine("Airline doesn't exist.");
            } while (!Res.Airlines.ContainsKey(input));

            string airline = input;

            Console.WriteLine($"Please choose a flight:");
            Res.displaySystemDetails(3);

            do
            {
                Console.WriteLine("Please choose a flight (based on flight ID) ");
                input = Console.ReadLine();
                if (!Res.Airlines[airline].Flights.ContainsKey(input))
                    Console.WriteLine("Flight doesn't exist.");
            } while (!Res.Airlines[airline].Flights.ContainsKey(input));

            string flight = input;

            Console.WriteLine($"Please choose a flight section:\n");

            foreach (var section in Res.Airlines[airline].Flights[flight].Sections)
            {
                Console.WriteLine(section.Value.SeatClass);
            }


            bool foundItem = false;
            FlightSection sectionItem;
            do
            {
                Console.WriteLine("Please choose a flight section ");
                input = Console.ReadLine();
                foreach (var section in Res.Airlines[airline].Flights[flight].Sections.Values)
                {
                    if (section.SeatClass.ToString().Equals(input))
                    {
                        foundItem = true;
                        Console.WriteLine("What would you like the price to be?");
                        int selection;
                        string newInput;
                        do
                        {
                            Console.WriteLine("Please select a valid price: ");
                            newInput = Console.ReadLine();
                        } while (!int.TryParse(newInput, out selection));

                        section.SeatPrice = selection;
                        /*foreach (var column in section.Layout.Values)
                        {
                            foreach (var seat in column)
                            {
                                seat.SeatPrice = 400;
                            }
                        }*/
                    }
                }
            } while (foundItem == false);



        }
    }
}