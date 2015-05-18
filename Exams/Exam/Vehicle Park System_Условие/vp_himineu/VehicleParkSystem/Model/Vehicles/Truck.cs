namespace VehicleParkSystem.Model.Vehicles
{
    using System.Text;

    public class Truck : Vehicle
    {
        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, (decimal)4.75, 6.2M, reservedHours)
        {
        }
    }
}
