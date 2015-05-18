namespace VehicleParkSystemUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Model;
    using VehicleParkSystem.Model.Vehicles;

    [TestClass]
    public class VehicleParkSystemInsertCarUnitTests
    {
        private VehiclePark park;
        private Car car;

        [TestInitialize]
        public void TestInitialize()
        {
            park = new VehiclePark(5, 5);
            car = new Car("ЕН7697ВН", "Dinko Todorov", 10);
        }

        [TestMethod]
        public void InsertCarProperly()
        {
            string result = park.InsertCar(car, 3, 3, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000", 
                        null, 
                        System.Globalization.DateTimeStyles.RoundtripKind));

            Assert.AreEqual("Car parked successfully at place (3,3)", result);
        }

        [TestMethod]
        public void InsertTwoCarsWithSameNumbers()
        {
            park.InsertCar(car, 3, 3, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000",
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind));
            string result = park.InsertCar(car, 4, 4, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000",
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind));

            Assert.AreEqual("There is already a vehicle with license plate " + car.LicensePlate + " in the park", result);

        }

        [TestMethod]
        public void InsertTwoCarsOnSameSectorAndPlace()
        {
            park.InsertCar(car, 3, 3, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000",
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind));
            string result = park.InsertCar(car, 3, 3, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000",
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind));

            Assert.AreEqual("The place (3,3) is occupied", result);

        }

        [TestMethod]
        public void InsertCarsOnInvalidSectorNumber()
        {
            string result = park.InsertCar(car, 6, 3, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000",
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind));

            Assert.AreEqual("There is no sector 6 in the park", result);

        }

        [TestMethod]
        public void InsertCarsOnInvalidPlaceNumber()
        {
            string result = park.InsertCar(car, 3, 6, DateTime.Parse(
                        "2015-05-04T10:30:00.0000000",
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind));

            Assert.AreEqual("There is no place 6 in sector 3", result);

        }
    }
}
