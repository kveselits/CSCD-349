using System;
using System.Collections.Generic;
using System.Linq;

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
                              $"4: Change the seat class (e.g., Economy) pricing for an origin and destination for a given airline.\n" +
                              $"5: Book a seat given a specific seat on a flight.\n" +
                              $"6: Book a seat on a flight given only a seating preference and seating class\n" +
                              $"7: Display details of the airport system\n" +
                              $"8: Save details to file\n" +
                              $"9: Quit");
            selection = obtainSelection(1, 9);

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
                    ChangeSeatClassPricing();
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

        private int obtainSelection(int min, int max)
        {
            int selection;
            do
            {
                Console.WriteLine("Please select a valid option: ");
                string input = Console.ReadLine();
                int.TryParse(input, out selection);
            } while (selection < min || selection > max);

            return selection;
        }

        private void SaveDetailsToFile()
        {
            BookingManager.WriteToFile();
        }

        private void BookByPreference()
        {
            SeatClass seatClass = ChooseSeatingClass();

            Console.WriteLine("Would you like a Window or a Aisle seat?\n" +
                              "1: Window seat\n" +
                              "2: Aisle seat\n");
            int selection = obtainSelection(1, 2);

            FindSeat(selection, seatClass);
        }

        private bool FindSeat(int selection, SeatClass seatClass)
        {
            if (selection.Equals(1))
            {
                foreach (var airline in Res.Airlines.Values)
                {
                    foreach (var flight in airline.Flights.Values)
                    {
                        foreach (var section in flight.Sections.Values)
                        {
                            if (section.SeatClass.Equals(seatClass))
                                foreach (var layout in section.Layout.Values)
                                {
                                    foreach (var seat in layout)
                                    {
                                        if (seat.SectionLayout.Equals('s'))
                                        {
                                            if (seat.Column.Equals(1) || seat.Column.Equals(3) && seat.Booked == false)
                                            {
                                                seat.Booked = true;
                                                Console.WriteLine($"Booked seat: {seat.SeatId}");
                                                return true;
                                            }
                                        }

                                        if (seat.SectionLayout.Equals('m'))
                                        {
                                            if (seat.Column.Equals(1) || seat.Column.Equals(4) && seat.Booked == false)
                                            {
                                                seat.Booked = true;
                                                Console.WriteLine($"Booked seat: {seat.SeatId}");
                                                return true;
                                            }
                                        }

                                        if (seat.SectionLayout.Equals('w'))
                                        {
                                            if (seat.Column.Equals(1) || seat.Column.Equals(10) && seat.Booked == false)
                                            {
                                                seat.Booked = true;
                                                Console.WriteLine($"Booked seat: {seat.SeatId}");
                                                return true;
                                            }
                                        }
                                    }
                                }
                        }
                    }
                }
            }
            if (selection.Equals(2))
            {
                foreach (var airline in Res.Airlines.Values)
                {
                    foreach (var flight in airline.Flights.Values)
                    {
                        foreach (var section in flight.Sections.Values)
                        {
                            if (section.SeatClass.Equals(seatClass))
                                foreach (var layout in section.Layout.Values)
                                {
                                    foreach (var seat in layout)
                                    {
                                        if (seat.SectionLayout.Equals('s'))
                                        {
                                            if (seat.Column.Equals(1) || seat.Column.Equals(2) && seat.Booked == false)
                                            {
                                                seat.Booked = true;
                                                Console.WriteLine($"Booked seat: {seat.SeatId}");
                                                return true;
                                            }
                                        }

                                        if (seat.SectionLayout.Equals('m'))
                                        {
                                            if (seat.Column.Equals(2) || seat.Column.Equals(3) && seat.Booked == false)
                                            {
                                                seat.Booked = true;
                                                Console.WriteLine($"Booked seat: {seat.SeatId}");
                                                return true;
                                            }
                                        }

                                        if (seat.SectionLayout.Equals('w'))
                                        {
                                            if (seat.Column.Equals(3) || seat.Column.Equals(4) || seat.Column.Equals(7) || seat.Column.Equals(8) && seat.Booked == false)
                                            {
                                                seat.Booked = true;
                                                Console.WriteLine($"Booked seat: {seat.SeatId}");
                                                return true;
                                            }
                                        }

                                    }
                                }
                        }
                    }
                }
            }

            return false;
        }

        private void BookSpecificSeat()
        {
            Res.displaySystemDetails(5);

            Console.WriteLine("Please select a seat," +
                              "For example, \"UNTD:UA12:First:3:1\": ");
            (bool, FlightSection) section;
            do
            {
                int column, row;
                Console.WriteLine("Please select a valid option: ");
                var input = Console.ReadLine();
                string[] ip = input.Trim().Split(':');
                if ((section = ValidateInput(ip)).Item1)
                    if (int.TryParse(ip[3], out column) && int.TryParse(ip[4], out row))
                        section.Item1 = section.Item2.bookSeat(column, row);

            } while (!section.Item1);

        }

        private (bool, FlightSection) ValidateInput(string[] ip)
        {
            var air = Res.Airlines;
            var seatClass = (SeatClass)Convert.ToInt32(Convert.ToChar(ip[2][0]));
            if (air.ContainsKey(ip[0]))
                if (air[ip[0]].Flights.ContainsKey(ip[1]))
                    if (air[ip[0]].Flights[ip[1]].Sections.ContainsKey(seatClass))
                        return (true, air[ip[0]].Flights[ip[1]].Sections[seatClass]);
            return (false, null);
        }

        private void ChangeSeatClassPricing()
        {
            Res.displaySystemDetails(2);
            Console.WriteLine("Which airline would you like to change the pricing for: ");
            string air = Console.ReadLine();
            Console.WriteLine($"{Res.AirportCodes}");
            Console.WriteLine("Please select a origin: ");
            string origin = Console.ReadLine();
            Console.WriteLine("Please select a destination: ");
            string destination = Console.ReadLine();
            Console.WriteLine("Please choose a seat class (E.G., Business, Economy, First Class): ");
            string seatClass = Console.ReadLine();

            Console.WriteLine("What would you like to change the price to?");
            int newPrice = obtainSelection(0, int.MaxValue);

            var sc = (SeatClass)Convert.ToInt32(Convert.ToChar(seatClass[0]));

            foreach (var airline in Res.Airlines)
            {
                if (airline.Key.Equals(air))
                {
                    foreach (var flight in airline.Value.Flights.Values)
                    {
                        if (flight.Orig.Equals(origin) && flight.Dest.Equals(destination))
                            foreach (var section in flight.Sections.Values)
                            {
                                if (section.SeatClass.Equals(sc))
                                    section.SeatPrice.Price = newPrice;
                            }
                    }
                }
            }

        }

        private void QueryAvailableFlights()
        {
            Console.WriteLine("Please select an origin");
            string origin = Console.ReadLine();
            Console.WriteLine("Please select a destination");
            string destination = Console.ReadLine();
            SeatClass seatingClass = ChooseSeatingClass();
            Console.WriteLine("Please select a date");
            string tempDate = Console.ReadLine();
            DateTime date = new DateTime();
            DateTime.TryParse(tempDate, out date);
            List<Flight> flights = Res.findAvailableFlights(origin, destination, seatingClass, date);

            foreach (var flight in flights)
            {
                Console.WriteLine(
                    $"Flight Name:{flight.Aname} Flight ID: {flight.Id} Origin: {flight.Orig} Destination: {flight.Dest} Date: {flight.Date} Price: {flight.Sections[seatingClass].SeatPrice.Price}");
            }
        }

        private SeatClass ChooseSeatingClass()
        {
            Console.WriteLine("Please select a seating class:\n" +
                              "1: First\n" +
                              "2: Economy\n" +
                              "3: Business\n");
            int selection = obtainSelection(1, 3);

            if (selection.Equals(1))
                return SeatClass.First;
            if (selection.Equals(2))
                return SeatClass.Economy;
            return (SeatClass.Business);
        }

        private void CreateAirportSystem()
        {

        }

        private void DisplaySystemDetails()
        {
            do
            {
                int selection = 0;
                Console.WriteLine($"\nPlease selection an option:\n" +
                                  $"1: Display Airports\n" +
                                  $"2: Display Airlines\n" +
                                  $"3: Display Flight Names\n" +
                                  $"4: Display Sections\n" +
                                  $"5: Display Seating Arrangements \n" +
                                  $"6: Quit \n");
                selection = obtainSelection(1, 6);
                Res.displaySystemDetails(selection);
                if (selection.Equals(6))
                    break;
            } while (true);
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

                        section.SeatPrice.Price = selection;
                    }
                }
            } while (foundItem == false);



        }
    }
}