namespace VehicleParkSystem.Model.Vehicles
{
    using System.Text;

    public class Car : Vehicle
    {
        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, 2, 3.5M, reservedHours)
        {
        }
    }
}
