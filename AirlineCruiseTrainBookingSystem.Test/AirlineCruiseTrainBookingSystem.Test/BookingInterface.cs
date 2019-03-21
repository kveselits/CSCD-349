using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;

namespace AirlineCruiseTrainBookingSystem.Test
{
    public class BookingInterface
    {
        public SystemManager Res { get; set; }

        public BookingInterface(SystemManager res)
        {
            Res = res;
        }

        public void StartUp()
        {
            int selection = 0;
            Console.WriteLine($"\nPlease choose an option from the following list:\n" +
                              $"1: Create an airport system by using information provided in an input file.\n" +
                              $"2: Change the price associated with seats in a flight section.\n" +
                              $"3: Query the system for flights with available seats\n" +
                              $"4: Change the seat class (e.g., economy) pricing for an origin and destination for a given airline.\n" +
                              $"5: Book a seat given a specific seat on a flight.\n" +
                              $"6: Book a seat on a flight given only a seating preference and seating class\n" +
                              $"7: Display details of the airport system" +
                              $"8: save detail to file\n");
            do
            {
                Console.WriteLine("Please select a valid option: ");
                var input = Console.ReadLine();
                int.TryParse(input, out selection);
            } while (selection < 1 || selection > 8);

            switch (selection)
            {
                case 1:
                    break;
                case 2:
                    ChangePrice();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    DisplaySystemDetails();
                    break;
                case 8:
                    break;
                default:
                    break;
            }

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
            Console.WriteLine("Change the price associated with seats in a flight section " +
                              "(all seats in a flight section have the same price).");
            Console.WriteLine("Which Airline would you like to choose?");
            Res.displaySystemDetails();
            string input;
            do
            {
                Console.WriteLine("Please select an Airline: ");
                input = Console.ReadLine();
                if(!Res.Airlines.ContainsKey(input))
                    Console.WriteLine("Airline doesn't exist.");
            } while (!Res.Airlines.ContainsKey(input));

            string airline = input;

            Console.WriteLine($"Please choose a flight:");
            Res.displaySystemDetails();

            do
            {
                Console.WriteLine("Please choose a flight (based on flight ID) ");
                input = Console.ReadLine();
                if (!Res.Airlines[airline].Flights.ContainsKey(input))
                    Console.WriteLine("Flight doesn't exist.");
            } while (!Res.Airlines[airline].Flights.ContainsKey(input));

            string flight = input;

            Console.WriteLine($"Please choose a flight section:");
            Res.displaySystemDetails();
           
        }
    }
}