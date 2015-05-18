namespace VehicleParkSystem.CommandUtilities
{
    using System;
    using Interfaces;
    using Model;
    using Model.Vehicles;

    public class ExecuteCommand
    {
        public VehiclePark VehiclePark { get; set; }

        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            var parameters = command.Parameters;
            switch (command.Name)
            {
                case "SetupPark":
                    if (int.Parse(parameters["sectors"]) < 0)
                    {
                        return "The number of sectors must be positive";
                    }

                    if (int.Parse(parameters["placesPerSector"]) < 0)
                    {
                        return "The number of places per sector must be positive";
                    }

                    this.VehiclePark = new VehiclePark(
                        int.Parse(parameters["sectors"]),
                        int.Parse(parameters["placesPerSector"]));
                    return "Vehicle park created";
                case "Park":
                    string licensePlate = parameters["licensePlate"];
                    string owner = parameters["owner"];
                    int reservedHours = int.Parse(parameters["hours"]);
                    int sector = int.Parse(parameters["sector"]);
                    int place = int.Parse(parameters["place"]);
                    DateTime dateTime = DateTime.Parse(
                        parameters["time"], 
                        null, 
                        System.Globalization.DateTimeStyles.RoundtripKind);

                    switch (command.Parameters["type"])
                    {
                        case "car":
                            return VehiclePark.InsertCar(
                                new Car(licensePlate, owner, reservedHours),
                                sector, 
                                place, 
                                dateTime);
                        case "motorbike":
                            return VehiclePark.InsertMotorbike(
                                new Motorbike(licensePlate, owner, reservedHours),
                                sector,
                                place,
                                dateTime);
                        case "truck":
                            return VehiclePark.InsertTruck(
                                new Truck(licensePlate, owner, reservedHours),
                                sector,
                                place,
                                dateTime);
                    }

                    break;
                case "Exit": 
                    return VehiclePark.ExitVehicle(
                        parameters["licensePlate"], 
                        DateTime.Parse(parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind),
                        decimal.Parse(parameters["paid"]));
                case "Status": 
                    return VehiclePark.GetStatus();
                case "FindVehicle": 
                    return VehiclePark.FindVehicle(
                        parameters["licensePlate"]);
                case "VehiclesByOwner": 
                    return VehiclePark.FindVehiclesByOwner(
                        parameters["owner"]);
                default: 
                    throw new IndexOutOfRangeException("Invalid command.");
            }

            return string.Empty;
        }
    }
}