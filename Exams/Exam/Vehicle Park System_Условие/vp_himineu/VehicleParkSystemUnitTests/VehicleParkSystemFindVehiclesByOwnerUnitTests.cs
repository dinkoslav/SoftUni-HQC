namespace VehicleParkSystemUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Model;
    using VehicleParkSystem.Model.Vehicles;

    [TestClass]
    public class VehicleParkSystemFindVehiclesByOwnerUnitTests
    {
        private VehiclePark park;

        [TestInitialize]
        public void TestInitialize()
        {
            park = new VehiclePark(5, 5);
        }

        [TestMethod]
        public void SearchVehiclesForExistingOwner()
        {
            park.InsertCar(new Car("ЕН7697ВН", "Dinko Todorov", 10), 3, 3, DateTime.Parse(
                "2015-05-04T10:30:00.0000000",
                null,
                System.Globalization.DateTimeStyles.RoundtripKind));

            string expectedResult = "Car [ЕН7697ВН], owned by Dinko Todorov\r\nParked at (3,3)";
            string result = park.FindVehiclesByOwner("Dinko Todorov");
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SearchVehiclesForNonExistingOwner()
        {
            string result = park.FindVehiclesByOwner("Dinko Todorov");
            Assert.AreEqual("No vehicles by Dinko Todorov", result);
        }
    }
}