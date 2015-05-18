namespace VehicleParkSystemUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Model;
    using VehicleParkSystem.Model.Vehicles;

    [TestClass]
    public class VehicleParkSystemGetStatusUnitTests
    {
        private VehiclePark park;

        [TestInitialize]
        public void TestInitialize()
        {
            park = new VehiclePark(2, 2);
        }

        [TestMethod]
        public void GetStatusOnEmptyPark()
        {
            string result = park.GetStatus();
            string expectedResult = "Sector 1: 0 / 2 (0% full)\r\nSector 2: 0 / 2 (0% full)";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetStatusOnNotEmptyPark()
        {
            park.InsertCar(new Car("ЕН7697ВН", "Dinko Todorov", 10), 1, 2, DateTime.Parse(
                "2015-05-04T10:30:00.0000000",
                null,
                System.Globalization.DateTimeStyles.RoundtripKind));

            string result = park.GetStatus();
            string expectedResult = "Sector 1: 1 / 2 (50% full)\r\nSector 2: 0 / 2 (0% full)";
            Assert.AreEqual(expectedResult, result);
        }
    }
}