namespace TravelAgency.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Enumerations;
    using Interfaces;
    using Models;
    using Wintellect.PowerCollections;

    public class TravelAgencyEngine : ITicketCatalog
    {
        private Dictionary<string, Ticket> ticketsByDesctiption = new Dictionary<string, Ticket>();
        private MultiDictionary<string, Ticket> ticketsByFromToPlaces = new MultiDictionary<string, Ticket>(true);
        private OrderedMultiDictionary<DateTime, Ticket> ticketsByDateAndTime = new OrderedMultiDictionary<DateTime, Ticket>(true);
        private int airTicketsCount = 0;
        private int busTicketsCount = 0;
        private int trainTicketsCount = 0;

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price)
        {
            AirTicket ticket = new AirTicket(flightNumber, from, to, airline, dateTime, price);
            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            AirTicket ticket = new AirTicket(flightNumber);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateTime, price, studentPrice);
            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateTime);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateTime, price);
            string result = this.AddTicket(ticket);

            if (result.Contains("added"))
            {
                this.busTicketsCount++;
            }

            return result;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateTime);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Air)
            {
                return this.airTicketsCount;
            }

            if (type == TicketType.Bus)
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = from + "; " + to;
            if (this.ticketsByFromToPlaces.ContainsKey(fromToKey))
            {
                var ticketsFound = this.ticketsByFromToPlaces[fromToKey];
                string ticketsAsString = SortTicketsToString(ticketsFound);
                return ticketsAsString;
            }

            return "Not found";
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDateAndTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                return SortTicketsToString(ticketsFound);
            }

            return "Not found";
        }

        internal string ProcessCommand(string line)
        {
            if (line == string.Empty)
            {
                return null;
            }

            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string command = line.Substring(0, firstSpaceIndex); 
            string outputMessage = "Invalid command!";
            switch (command)
            {
                case "AddAir":
                    string allParameters = line.Substring(firstSpaceIndex + 1);
                    string[] parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    DateTime airDateAndTime = ParseDateTime(parameters[4]);
                    decimal airPrice = decimal.Parse(parameters[5]);

                    outputMessage = this.AddAirTicket(parameters[0], parameters[1], parameters[2], parameters[3], airDateAndTime, airPrice);
                    break;
                case "DeleteAir":
                    allParameters = line.Substring(firstSpaceIndex + 1); 
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    outputMessage = this.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    DateTime trainDateAndTime = ParseDateTime(parameters[2]);
                    decimal trainPrice = decimal.Parse(parameters[3]);
                    decimal trainSpecialPrice = decimal.Parse(parameters[4]);

                    outputMessage = this.AddTrainTicket(parameters[0], parameters[1], trainDateAndTime, trainPrice, trainSpecialPrice);
                    break;
                case "DeleteTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1); 
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    DateTime trainDeleteDateAndTime = ParseDateTime(parameters[2]);

                    outputMessage = this.DeleteTrainTicket(parameters[0], parameters[1], trainDeleteDateAndTime);
                    break;
                case "AddBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    DateTime addBusDateAndTime = ParseDateTime(parameters[3]);
                    decimal addBusPrice = decimal.Parse(parameters[4]);

                    outputMessage = this.AddBusTicket(parameters[0], parameters[1], parameters[2], addBusDateAndTime, addBusPrice);
                    break;
                case "DeleteBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    DateTime deleteBusDateAndTime = ParseDateTime(parameters[3]);

                    outputMessage = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], deleteBusDateAndTime);
                    break;
                case "FindTickets":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    outputMessage = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    DateTime startDateTime = ParseDateTime(parameters[0]);
                    DateTime endDateTime = ParseDateTime(parameters[1]);
                    outputMessage = this.FindTicketsInInterval(startDateTime, endDateTime);
                    break;
            }

            return outputMessage;
        }

        private static string SortTicketsToString(ICollection<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);
            sortedTickets.Sort();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < sortedTickets.Count; i++)
            {
                Ticket ticket = sortedTickets[i];
                result.Append(ticket);
                if (i < sortedTickets.Count - 1)
                {
                    result.Append(" ");
                }
            }

            return result.ToString();
        }

        private static DateTime ParseDateTime(string dateTime)
        {
            DateTime result = DateTime.ParseExact(dateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }

        private string AddTicket(Ticket ticket)
        {
            string key = ticket.Description;
            if (this.ticketsByDesctiption.ContainsKey(key))
            {
                return "Duplicate ticket";
            }

            this.ticketsByDesctiption.Add(key, ticket);
            string fromToKey = ticket.FromToKey;
            this.ticketsByFromToPlaces.Add(fromToKey, ticket);
            this.ticketsByDateAndTime.Add(ticket.DateAndTime, ticket);
            return "Ticket added";
        }

        private string DeleteTicket(Ticket ticket)
        {
            string key = ticket.Description;
            if (this.ticketsByDesctiption.ContainsKey(key))
            {
                ticket = this.ticketsByDesctiption[key];
                this.ticketsByDesctiption.Remove(key);
                string fromToKey = ticket.FromToKey;
                this.ticketsByFromToPlaces.Remove(fromToKey, ticket);
                this.ticketsByDateAndTime.Remove(ticket.DateAndTime, ticket);
                return "Ticket deleted";
            }

            return "Ticket does not exist";
        }
    }
}