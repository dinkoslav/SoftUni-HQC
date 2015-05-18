namespace VehicleParkSystem.Model.Vehicles
{
    using System.Text;

    public class Motorbike : Vehicle
    {
        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, (decimal)1.35, 3M, reservedHours)
        {
        }
    }
}
