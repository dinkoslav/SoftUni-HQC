namespace VehicleParkSystem.Interfaces
{
    using System;
    using Model.Vehicles;

    /// <summary>
    /// Interface that handles all operations of the park (insert/remove/status ...)
    /// </summary>
    internal interface IVehiclePark
    {
        /// <summary>
        /// Insert a car with the specified properties to the vehicle park database.
        /// </summary>
        /// <param name="car">The car object with the specified properties</param>
        /// <param name="sector">The sector in the vehicle park where should be added</param>
        /// <param name="placeNumber">The place number in the sector in the vehicle park where should be added</param>
        /// <param name="startTime">The time when the car is parked in the vehicle park</param>
        /// <returns>Returns a success message ("Car parked successfully at place (<sector>,<place>)") if the car
        /// has been added successfully, and an error message depending on the error</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Insert a motorbike with the specified properties to the vehicle park database.
        /// </summary>
        /// <param name="motorbike">The motorbike object with the specified properties</param>
        /// <param name="sector">The sector in the vehicle park where should be added</param>
        /// <param name="placeNumber">The place number in the sector in the vehicle park where should be added</param>
        /// <param name="startTime">The time when the motorbike is parked in the vehicle park</param>
        /// <returns>Returns a success message ("Motorbike parked successfully at place (<sector>,<place>)") if the motorbike
        /// has been added successfully, and an error message depending on the error</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Insert a truck with the specified properties to the vehicle park database.
        /// </summary>
        /// <param name="truck">The truck object with the specified properties</param>
        /// <param name="sector">The sector in the vehicle park where should be added</param>
        /// <param name="placeNumber">The place number in the sector in the vehicle park where should be added</param>
        /// <param name="startTime">The time when the truck is parked in the vehicle park</param>
        /// <returns>Returns a success message ("Truck parked successfully at place (<sector>,<place>)") if the truck
        /// has been added successfully, and an error message depending on the error</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);
        
        /// <summary>
        /// Removes a vehicle with specified license plate and calculate the price for the stay 
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <param name="endTime">The end time of the stay</param>
        /// <param name="amountPaid">The amount given by the driver</param>
        /// <returns>If the vehicle has been removed successfully, returns ticket with license plate, owner, place, rate, overtime rate, total, paid and change. In case of error returns error message ("There is no vehicle with license plate {0} in the park")</returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);
        
        /// <summary>
        /// Give us the status of the park at the moment.
        /// </summary>
        /// <returns>Returns message for each sector("Sector number: places taken / places in sector (% full)")</returns>
        string GetStatus();
        
        /// <summary>
        /// Finds vehicle by given license plate.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <returns>Returns message with license plate and owner if the vehicle has been found, and an error message("There is no vehicle with license plate (given license plate) in the park")</returns>
        string FindVehicle(string licensePlate);
        
        /// <summary>
        /// Finds vehicle by given owner.
        /// </summary>
        /// <param name="owner">The owner of the vehicle</param>
        /// <returns>Returns message with license plate and owner for all vehicles found if there are any, and an error message("No vehicles by (owner)")</returns>
        string FindVehiclesByOwner(string owner);
    }
}