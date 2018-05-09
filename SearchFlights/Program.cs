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
        }

        private static void DisplayMenu(ref string inputText)
        {
            Console.WriteLine("*************************************************************");
            Console.WriteLine("* To Exit: -1                                               *");
            Console.WriteLine("* To Search: \"searchFlights -o (Origin) -d (Destination)\"   *");
            Console.WriteLine("*************************************************************\n");
            Console.Write("$");
            inputText = Console.ReadLine();
        }


    }
}
