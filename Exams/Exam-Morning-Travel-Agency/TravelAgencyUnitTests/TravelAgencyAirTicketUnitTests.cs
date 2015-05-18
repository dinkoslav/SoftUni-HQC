namespace TravelAgencyUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Engine;
    using TravelAgency.Enumerations;

    [TestClass]
    public class TravelAgencyAirTicketUnitTests
    {
        private TravelAgencyEngine catalog;

        [TestInitialize]
        public void TestInitialize()
        {
            catalog = new TravelAgencyEngine();
        }
        
        [TestMethod]
        public void TestAddAirTicketIsCorrectlyAdded()
        {
            string result = catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna",
                airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicketIsDuplicated()
        {
            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna",
                airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            string result = catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna",
                airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Duplicate ticket", result);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTicketDeleted()
        {
            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna",
                airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string result = catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketDeleteNonExistingTicket()
        {
            string result = catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }
    }
}
