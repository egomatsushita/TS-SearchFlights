using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFlights;

namespace UnitTestSearchFlights
{
    [TestClass]
    public class SearchFlightsTests
    {
        [TestMethod]
        public void CheckIfExist_DepTime_DestTime_Price_FlightData_ReturnFalse()
        {
            DateTime departureTime = Convert.ToDateTime("6/15/2014 6:45:00");
            DateTime destinationTime = Convert.ToDateTime("6/15/2014 8:54:00");
            Decimal price = 578.00m;
            FlightsCollection flightsData = new FlightsCollection();

            bool result = SearchFlightsMethods.CheckIfExist(departureTime, destinationTime, price, flightsData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfExist_DepTime_DestTime_Price_FlightData_ReturnTrue()
        {
            Flights flight1 = new Flights
            {
                Origin = "YYZ",
                DepartureTime = Convert.ToDateTime("6/15/2014 6:45:00"),
                Destination = "YYC",
                DestinationTime = Convert.ToDateTime("6/15/2014 8:54:00"),
                Price = 578.00m
            };
            FlightsCollection flightsData = new FlightsCollection();
            flightsData.flightsCollection.Add(flight1);
            DateTime departureTime = Convert.ToDateTime("6/15/2014 6:45:00");
            DateTime destinationTime = Convert.ToDateTime("6/15/2014 8:54:00");
            Decimal price = 578.00m;

            bool result = SearchFlightsMethods.CheckIfExist(departureTime, destinationTime, price, flightsData);

            Assert.IsTrue(result);
        }
    }
}
