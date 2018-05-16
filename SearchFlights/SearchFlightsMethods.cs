using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SearchFlights
{
    public static class SearchFlightsMethods
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
            string providerPath = GetProviderPath(provider);
            StreamReader reader = new StreamReader(providerPath);
            string recordIn = reader.ReadLine();
            string pattern = @"\W";
            Regex re = new Regex(pattern);
            Match mc = re.Match(recordIn);
            char delimiter = Convert.ToChar(mc.Value);

            return delimiter;
        }

        public static void SearchFligths(string origin, string destination, FlightsCollection flightsData)
        {
            string[] providers = { "Provider1.txt", "Provider2.txt", "Provider3.txt" };          
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
                        AddFlights(recordIn, delimiter, origin, destination, flightsData);
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

        public static void AddFlights(string recordIn, char delimiter, string origin, string destination, FlightsCollection flightsData)
        {
            string[] fields;
            DateTime prvDepartureTime;
            DateTime prvDestinationTime;
            Decimal prvPrice;
            fields = recordIn.Split(delimiter);
            string prvOrigin = fields[0];
            DateTime.TryParse(fields[1].Replace('-', '/'), out prvDepartureTime);
            string prvDestination = fields[2];
            DateTime.TryParse(fields[3].Replace('-', '/'), out prvDestinationTime);
            Decimal.TryParse(fields[4].Substring(1), out prvPrice);

            if (prvOrigin == origin && prvDestination == destination)
            {
                Flights aFlight = new Flights
                {
                    Origin = prvOrigin,
                    DepartureTime = prvDepartureTime,
                    Destination = prvDestination,
                    DestinationTime = prvDestinationTime,
                    Price = prvPrice
                };

                if (!flightsData.flightsCollection.Contains(aFlight))
                {
                    flightsData.flightsCollection.Add(aFlight);
                }
            }
        }       
    }
}
