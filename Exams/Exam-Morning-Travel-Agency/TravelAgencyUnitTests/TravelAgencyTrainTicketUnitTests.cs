namespace TravelAgencyUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Engine;
    using TravelAgency.Enumerations;

    [TestClass]
    public class TravelAgencyTrainTicketUnitTests
    {
        private TravelAgencyEngine catalog;

        [TestInitialize]
        public void TestInitialize()
        {
            catalog = new TravelAgencyEngine();
        }

        [TestMethod]
        public void TestAddTrainTicketIsCorrectlyAdded()
        {
            string result = catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M, studentPrice: 50.50M);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestAddTrainTicketIsDuplicated()
        {
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M, studentPrice: 50.50M);
            string result = catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M, studentPrice: 50.50M);

            Assert.AreEqual("Duplicate ticket", result);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTicketDeleted()
        {
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M, studentPrice: 50.50M);

            string result = catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketDeleteNonExistingTicket()
        {
            string result = catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }
    }
}
