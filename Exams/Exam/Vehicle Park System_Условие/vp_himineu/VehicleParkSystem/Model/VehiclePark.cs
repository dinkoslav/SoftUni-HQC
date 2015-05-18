namespace VehicleParkSystem.Model
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Interfaces;
    using Vehicles;

    public class VehiclePark : IVehiclePark
    {
        public VehicleParkSectors vehicleParkSectors;
        public VehicleParkData vehicleParkData;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            vehicleParkSectors = new VehicleParkSectors(numberOfSectors, placesPerSector);
            vehicleParkData = new VehicleParkData(numberOfSectors);
        }

        public string InsertCar(Car car, int sector, int place, DateTime dateTime)
        {
            string validationResult = ValidateVehicle(car, sector, place);
            if (validationResult != string.Empty)
            {
                return validationResult;
            }

            return AddVehicleToParkData(car, sector, place, dateTime);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime dateTime)
        {
            string validationResult = ValidateVehicle(motorbike, sector, place);
            if (validationResult != string.Empty)
            {
                return validationResult;
            }

            return AddVehicleToParkData(motorbike, sector, place, dateTime);
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime dateTime)
        {
            string validationResult = ValidateVehicle(truck, sector, place);
            if (validationResult != string.Empty)
            {
                return validationResult;
            }

            return AddVehicleToParkData(truck, sector, place, dateTime);
        }

        public string ExitVehicle(string licensePlate, DateTime exitDateTime, decimal paid)
        {
            var vehicle = (vehicleParkData.VehiclesByLicensePlate.ContainsKey(licensePlate)) ? vehicleParkData.VehiclesByLicensePlate[licensePlate] : null;

            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var insertDateTime = vehicleParkData.VehiclesByDateTimes[vehicle];
            int parkHours = (int)Math.Round((exitDateTime - insertDateTime).TotalHours);
            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString()).AppendLine()
                .AppendFormat("at place {0}", vehicleParkData.InparkVehicles[vehicle]).AppendLine()
                .AppendFormat("Rate: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate)).AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", (parkHours > vehicle.ReservedHours ? (parkHours - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)).AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate + (parkHours > vehicle.ReservedHours ? (parkHours - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))).AppendLine()
                .AppendFormat("Paid: ${0:F2}", paid).AppendLine()
                .AppendFormat("Change: ${0:F2}", paid - ((vehicle.ReservedHours * vehicle.RegularRate) + (parkHours > vehicle.ReservedHours ? (parkHours - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))).AppendLine()
                .Append(new string('*', 20));

            int sector = int.Parse(vehicleParkData.InparkVehicles[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            vehicleParkData.VehiclesBySectorPlace.Remove(vehicleParkData.InparkVehicles[vehicle]);
            vehicleParkData.InparkVehicles.Remove(vehicle);
            vehicleParkData.VehiclesByLicensePlate.Remove(vehicle.LicensePlate);
            vehicleParkData.VehiclesByDateTimes.Remove(vehicle);
            vehicleParkData.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            vehicleParkData.NumberOfSectors[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = vehicleParkData.NumberOfSectors.Select(
                (takenPlaces, sector) => string.Format("Sector {0}: {1} / {2} ({3}% full)",
                sector + 1,
                takenPlaces,
                vehicleParkSectors.PlacesPerSector,
                Math.Round((double)takenPlaces / vehicleParkSectors.PlacesPerSector * 100)));
            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = (vehicleParkData.VehiclesByLicensePlate.ContainsKey(licensePlate)) ? vehicleParkData.VehiclesByLicensePlate[licensePlate] : null;

            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            // PERFORMANCE: Here was a select tru the vehicleParkData.VehiclesByLicensePlate search. I dont remember other things that was bottlenecks, but now i dont have problems with memory.
            var vehicles = (vehicleParkData.VehiclesByOwner.ContainsKey(owner)) ? vehicleParkData.VehiclesByOwner[owner] : null;
            
            if (vehicles == null)
            {
                return string.Format("No vehicles by {0}", owner);
            }

            return string.Join(Environment.NewLine, Input(vehicles));
        }

        private string Input(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(Environment.NewLine, vehicles.Select(vehicle => string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, vehicleParkData.InparkVehicles[vehicle])));
        }

        private string ValidateVehicle(Vehicle vehicle, int sector, int place)
        {
            if (sector > vehicleParkSectors.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > vehicleParkSectors.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (vehicleParkData.VehiclesBySectorPlace.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (vehicleParkData.VehiclesByLicensePlate.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", vehicle.LicensePlate);
            }

            return string.Empty;
        }

        private string AddVehicleToParkData(Vehicle vehicle, int sector, int place, DateTime dateTime)
        {
            vehicleParkData.InparkVehicles[vehicle] = string.Format("({0},{1})", sector, place);
            vehicleParkData.VehiclesBySectorPlace[string.Format("({0},{1})", sector, place)] = vehicle;
            vehicleParkData.VehiclesByLicensePlate[vehicle.LicensePlate] = vehicle;
            vehicleParkData.VehiclesByDateTimes[vehicle] = dateTime;
            vehicleParkData.VehiclesByOwner[vehicle.Owner].Add(vehicle);
            vehicleParkData.NumberOfSectors[sector - 1]++;
            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
        }
    }
}