namespace TravelAgency.Interfaces
{
    using System;
    using Enumerations;
    
    /// <summary>
    /// Interface that handles all Ticket operations
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Create new instance of Air Ticket and push it in the catalog
        /// </summary>
        /// <param name="flightNumber">Flight number as a string</param>
        /// <param name="from">Departure from</param>
        /// <param name="to">Arive to</param>
        /// <param name="airline">Airline company</param>
        /// <param name="dateTime">Date and time of departure</param>
        /// <param name="price">Ticket price</param>
        /// <returns>String with the result of adding</returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Delete the bus ticket from the catalog if exists
        /// </summary>
        /// <param name="from">Departure from</param>
        /// <param name="to">Arive to</param>
        /// <param name="travelCompany">Travel company</param>
        /// <param name="dateTime">Date and time of departure</param>
        /// <returns>String with the result of delete</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        // TODO: document this method
        string FindTickets(string from, string to);

        // TODO: document this method
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}
