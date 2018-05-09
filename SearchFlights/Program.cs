using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlights
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightsCollection flightsData;
            int indexOrigin;
            int indexDestination;
            string origin;
            string destination;
            string inputText = "";
            int cityLength = 3;
            int space = 3;

            HelperMethods.DisplayMenu(ref inputText);
           
            while (inputText != "-1")
            {
                flightsData = new FlightsCollection();
                indexOrigin = inputText.IndexOf("-o") + space;
                indexDestination = inputText.IndexOf("-d") + space;

                try
                {
                    origin = inputText.Substring(indexOrigin, cityLength).ToUpper();
                    if (origin.Contains('-') || origin.Trim() == "")
                    {
                        throw new Exception();
                    }

                    destination = inputText.Substring(indexDestination, cityLength).ToUpper();
                }
                catch(Exception e)
                {
                    Console.WriteLine("\nPlease, enter origin and destination.\n");
                    HelperMethods.DisplayMenu(ref inputText);
                    continue;
                }

                HelperMethods.SearchFligths(origin, destination, flightsData);

                var searchedFlights =
                    flightsData.flightsCollection
                        .OrderBy(flight => flight.Price.Substring(1))
                        .ThenBy(flight => Convert.ToDateTime(flight.DepartureTime));

                if (searchedFlights.Any())
                {
                    Console.WriteLine();
                    foreach (var flight in searchedFlights)
                    {
                        Console.WriteLine($"{flight.Origin}-- > {flight.Destination}({flight.DepartureTime.Replace('-', '/')}-- >{flight.DestinationTime.Replace('-', '/')}) - {flight.Price}");
                    }
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine($"\nNo Flights Found for {origin} --> {destination}\n");
                }

                HelperMethods.DisplayMenu(ref inputText);
            }
        }    
    }
}
