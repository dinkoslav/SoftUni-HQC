namespace VehicleParkSystemUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Model;
    using VehicleParkSystem.Model.Vehicles;

    [TestClass]
    public class VehicleParkSystemExitVehicleUnitTests
    {
        private VehiclePark park;
        private Car car;
        private DateTime exitDate;
        private DateTime exitDateWithOvertime;
        private decimal paid;

        [TestInitialize]
        public void TestInitialize()
        {
            park = new VehiclePark(5, 5);
            car = new Car("ЕН7697ВН", "Dinko Todorov", 3);
            park.InsertCar(car, 3, 3, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000",
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind));
            exitDate = DateTime.Parse(
                "2015-05-04T12:30:00.0000000",
                null,
                System.Globalization.DateTimeStyles.RoundtripKind);
            exitDateWithOvertime = DateTime.Parse(
                "2015-05-04T14:30:00.0000000",
                null,
                System.Globalization.DateTimeStyles.RoundtripKind);
            paid = 10M;
        }

        [TestMethod]
        public void ExitVehicleWithExistingLicensePlateWithoutOvertime()
        {
            string expectedResult = "********************\r\nCar [ЕН7697ВН], owned by Dinko Todorov\r\nat place (3,3)\r\nRate: $6.00\r\nOvertime rate: $0.00\r\n--------------------\r\nTotal: $6.00\r\nPaid: $10.00\r\nChange: $4.00\r\n********************";
            string result = park.ExitVehicle("ЕН7697ВН", exitDate, paid);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ExitVehicleWithExistingLicensePlateWithOvertime()
        {
            string expectedResult = "********************\r\nCar [ЕН7697ВН], owned by Dinko Todorov\r\nat place (3,3)\r\nRate: $6.00\r\nOvertime rate: $3.50\r\n--------------------\r\nTotal: $9.50\r\nPaid: $10.00\r\nChange: $0.50\r\n********************";
            string result = park.ExitVehicle("ЕН7697ВН", exitDateWithOvertime, paid);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ExitVehicleWithNotExistingLicensePlate()
        {
            string result = park.ExitVehicle("ЕН7117ВН", exitDate, paid);
            Assert.AreEqual("There is no vehicle with license plate ЕН7117ВН in the park", result);
        }
    }
}