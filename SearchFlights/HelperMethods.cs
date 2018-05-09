using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchFlights
{
    public static class HelperMethods
    {
        public static void DisplayMenu(ref string inputText)
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

        public static string GetProviderPath(string provider)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            int index = path.IndexOf("SearchFlights");
            string excludePath = path.Substring(index);
            string includePath = $"SearchFlights\\Providers\\{provider}";
            string providerPath = path.Replace(excludePath, includePath);

            return providerPath;
        }

        public static char GetDelimiter(string provider)
        {
            char delimiter = ',';
            if (provider == "Provider3.txt")
            {
                delimiter = '|';
            }

            return delimiter;
        }

        public static bool CheckIfExist(string prvDepartureTime, string prvDestinationTime, string prvPrice, FlightsCollection flightsData)
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

        public static void SearchFligths(string origin, string destination, FlightsCollection flightsData)
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
