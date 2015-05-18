namespace TravelAgencyUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Engine;
    using TravelAgency.Enumerations;

    [TestClass]
    public class TravelAgencyBusTicketUnitTests
    {
        private TravelAgencyEngine catalog;

        [TestInitialize]
        public void TestInitialize()
        {
            catalog = new TravelAgencyEngine();
        }

        [TestMethod]
        public void TestAddBusTicketIsCorrectlyAdded()
        {
            string result = catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "Chavdar",dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestAddBusTicketIsDuplicated()
        {
            catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "Chavdar", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            string result = catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "Chavdar", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Duplicate ticket", result);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsTicketDeleted()
        {
            catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "Chavdar", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string result = catalog.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "Chavdar", 
                dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketDeleteNonExistingTicket()
        {
            string result = catalog.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "Chavdar", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}
