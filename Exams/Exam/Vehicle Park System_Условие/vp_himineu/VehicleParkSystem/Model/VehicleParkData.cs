namespace VehicleParkSystem.Model
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Wintellect.PowerCollections;

    public class VehicleParkData
    {
        public VehicleParkData(int numberOfSectors)
        {
            this.InparkVehicles = new Dictionary<IVehicle, string>();
            this.VehiclesBySectorPlace = new Dictionary<string, IVehicle>();
            this.VehiclesByLicensePlate = new Dictionary<string, IVehicle>();
            this.VehiclesByDateTimes = new Dictionary<IVehicle, DateTime>();
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false);
            this.NumberOfSectors = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> InparkVehicles { get; set; }

        public Dictionary<string, IVehicle> VehiclesBySectorPlace { get; set; }

        public Dictionary<string, IVehicle> VehiclesByLicensePlate { get; set; }

        public Dictionary<IVehicle, DateTime> VehiclesByDateTimes { get; set; }

        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; set; }

        public int[] NumberOfSectors { get; set; }
    }
}