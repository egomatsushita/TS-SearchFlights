using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFlights;

namespace UnitTestSearchFlights
{
    [TestClass]
    public class SearchFlightsTests
    {
        [TestMethod]
        public void GetDelimiter_Provider_ReturnVerticalBar()
        {
            string provider = "Provider3.txt";
            char expected = '|';
            char actual = HelperMethods.GetDelimiter(provider);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDelimiter_Provider_ReturnComma()
        {
            string provider = "Provider2.txt";
            char expected = ',';
            char actual = HelperMethods.GetDelimiter(provider);

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void CheckIfExist_DepTime_DestTime_Price_FlightData_ReturnFalse()
        //{
        //    string departureTime = "6/15/2014 6:45:00";
        //    string destinationTime = "6/15/2014 8:54:00";
        //    string price = "$578.00";
        //    FlightsCollection flightsData = new FlightsCollection();

        //    bool result = HelperMethods.CheckIfExist(departureTime, destinationTime, price, flightsData);

        //    Assert.IsFalse(result);
        //}

        //[TestMethod]
        //public void CheckIfExist_DepTime_DestTime_Price_FlightData_ReturnTrue()
        //{
        //    Flights flight1 = new Flights
        //    {
        //        Origin = "YYZ",
        //        DepartureTime = "6/15/2014 6:45:00",
        //        Destination = "YYC",
        //        DestinationTime = "6/15/2014 8:54:00",
        //        Price = "$578.00"
        //    };
        //    FlightsCollection flightsData = new FlightsCollection();
        //    flightsData.flightsCollection.Add(flight1);
        //    string departureTime = "6/15/2014 6:45:00";
        //    string destinationTime = "6/15/2014 8:54:00";
        //    string price = "$578.00";
           
        //    bool result = HelperMethods.CheckIfExist(departureTime, destinationTime, price, flightsData);

        //    Assert.IsTrue(result);
        //}
    }
}
