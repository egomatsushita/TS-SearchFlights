using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSearchFlights
{
    [TestClass]
    public class SearchFlightsTests
    {
        [TestMethod]
        public void GetProviderPath_Provider_ReturnProviderPath()
        {
            string provider = "Provider3.txt";
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //string expected = path.Replace()
        }
    }
}
