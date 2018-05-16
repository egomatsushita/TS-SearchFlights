using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFlights;

namespace UnitTestSearchFlights
{
    [TestClass]
    public class SearchFlightsTests
    {
        [TestMethod]
        public void AddFlights_RecordIn_Delimiter_Origin_Destination_FlightsData_ReturnTrue()
        {
            Flights flight = new Flights
            {
                Origin = "YYZ",
                DepartureTime = Convert.ToDateTime("6/15/2014 6:45:00"),
                Destination = "YYC",
                DestinationTime = Convert.ToDateTime("6/15/2014 8:54:00"),
                Price = 578.00m
            };
            FlightsCollection flights = new FlightsCollection();

            SearchFlightsMethods.AddFlights(
                "YYZ,6/15/2014 6:45:00,YYC,6/15/2014 8:54:00,$578.00",
                ',',
                "YYZ",
                "YYC",
                flights);

            bool result = flights.flightsCollection.Contains(flight);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddFlights_RecordIn_Delimiter_Origin_Destination_FlightsData_ReturnFalse()
        {
            Flights flight = new Flights
            {
                Origin = "MIA",
                DepartureTime = Convert.ToDateTime("6/15/2014 6:45:00"),
                Destination = "ORD",
                DestinationTime = Convert.ToDateTime("6/15/2014 8:54:00"),
                Price = 578.00m
            };
            FlightsCollection flights = new FlightsCollection();

            SearchFlightsMethods.AddFlights(
                "YYZ,6/15/2014 6:45:00,YYC,6/15/2014 8:54:00,$578.00",
                ',',
                "YYZ",
                "YYC",
                flights);

            bool result = flights.flightsCollection.Contains(flight);
            Assert.IsFalse(result);
        }       
    }
}
