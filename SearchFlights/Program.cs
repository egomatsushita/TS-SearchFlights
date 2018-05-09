using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            DisplayMenu(ref inputText);
           
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
                    DisplayMenu(ref inputText);
                    continue;
                }

                SearchFligths(origin, destination, flightsData);

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

                DisplayMenu(ref inputText);
            }
        }

        private static void DisplayMenu(ref string inputText)
        {
            Console.WriteLine("*************************************************************");
            Console.WriteLine("* ----------------- Search Flights v.1.0 ------------------ *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("* To Search: \"searchFlights -o (Origin) -d (Destination)\"   *");
            Console.WriteLine("* To Exit: -1                                               *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************\n");
            Console.Write("$");
            inputText = Console.ReadLine();
        }

        private static string GetProviderPath(string provider)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            int index = path.IndexOf("SearchFlights");
            string excludePath = path.Substring(index);
            string includePath = $"SearchFlights\\Providers\\{provider}";
            string providerPath = path.Replace(excludePath, includePath);

            return providerPath;
        }

        private static char GetDelimiter(string provider)
        {
            char delimiter = ',';
            if (provider == "Provider3.txt")
            {
                delimiter = '|';
            }

            return delimiter;
        }

        private static bool CheckIfExist(string prvDepartureTime, string prvDestinationTime, string prvPrice, FlightsCollection flightsData)
        {
            if (flightsData.flightsCollection != null)
            {
                foreach (var flight in flightsData.flightsCollection)
                {
                    if (flight.DepartureTime == prvDepartureTime &&
                        flight.DestinationTime == prvDestinationTime &&
                        flight.Price == prvPrice)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void SearchFligths(string origin, string destination, FlightsCollection flightsData)
        {
            string[] providers = { "Provider1.txt", "Provider2.txt", "Provider3.txt" };
            string[] fields;
            string prvOrigin;
            string prvDepartureTime;
            string prvDestination;
            string prvDestinationTime;
            string prvPrice;
            char delimiter;
            string providerPath;

            for (int i = 0; i < providers.Length; i++)
            {
                providerPath = GetProviderPath(providers[i]);
                delimiter = GetDelimiter(providers[i]);

                try
                {
                    StreamReader reader = new StreamReader(providerPath);
                    string recordIn = reader.ReadLine();

                    while (recordIn != null)
                    {
                        fields = recordIn.Split(delimiter);
                        prvOrigin = fields[0];
                        prvDepartureTime = fields[1].Replace('-', '/');
                        prvDestination = fields[2];
                        prvDestinationTime = fields[3].Replace('-', '/');
                        prvPrice = fields[4];

                        if (prvOrigin == origin && prvDestination == destination)
                        {
                            if (!CheckIfExist(prvDepartureTime, prvDestinationTime, prvPrice, flightsData))
                            {
                                flightsData.flightsCollection
                                    .Add(new Flights
                                    {
                                        Origin = prvOrigin,
                                        DepartureTime = prvDepartureTime,
                                        Destination = prvDestination,
                                        DestinationTime = prvDestinationTime,
                                        Price = prvPrice
                                    });
                            }
                        }

                        recordIn = reader.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("the file could not be read");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
