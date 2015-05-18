namespace TicketOffice
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Enumerations;
    using Interfaces;
    using Tickets;
    using Wintellect.PowerCollections;

    public class TicketOfficeEngine : ITicketRepository
    {
        private Dictionary<string, Ticket> ticketsByKey = new Dictionary<string, Ticket>();
        private MultiDictionary<string, Ticket> ticketsByFromTo = new MultiDictionary<string, Ticket>(true);
        private OrderedMultiDictionary<DateTime, Ticket> ticketsByDateAndTime = new OrderedMultiDictionary<DateTime, Ticket>(true);
        private int airTicketsCount = 0;
        private int busTicketsCount = 0;
        private int trainTicketsCount = 0;
        
        public string AddAirTicket(string flightNumber, string from, string to, string airline, string dateAndTime, string price)
        {
            AirTicket ticket = new AirTicket(flightNumber, from, to, airline, dateAndTime, price);
            string result = this.AddTicket(ticket);
            if (result.Contains("created"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string flightTicket)
        {
            AirTicket ticket = new AirTicket(flightTicket);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, string dateAndTime, string price, string studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime, price, studentPrice);
            string result = this.AddTicket(ticket);
            if (result.Contains("created"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string from, string to, string dateAndTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(string from, string to, string travelCompany, string dateAndTime, string price)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateAndTime, price);
            string result = this.AddTicket(ticket);
            if (result.Contains("created"))
            {
                this.busTicketsCount++;
            }

            return result;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, string dateAndTime)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateAndTime);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        // TODO ??
        public string FindTickets(string from, string to)
        {
            string fromToKey = Ticket.CreateFromToKey(from, to);
            if (this.ticketsByFromTo.ContainsKey(fromToKey))
            {
                List<Ticket> ticketsFound = this.ticketsByFromTo.Values.Where(t => t.FromToKey == fromToKey).ToList();
                string ticketsAsString = ReadTickets(ticketsFound);
                return ticketsAsString;
            }
            else
            {
                return "No matches";
            }
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDateAndTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = ReadTickets(ticketsFound);
                return ticketsAsString;
            }

            return "No matches";
        }
        
        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateAndTime, decimal price)
        {
            return this.AddAirTicket(flightNumber, from, to, airline, dateAndTime.ToString("dd.MM.yyyy HH:mm"), price.ToString(CultureInfo.InvariantCulture));
        }

        string ITicketRepository.DeleteAirTicket(string flightNumber)
        {
            return this.DeleteAirTicket(flightNumber);
        }

        public string AddTrainTicket(string from, string to, DateTime dateAndTime, decimal price, decimal studentPrice)
        {
            return this.AddTrainTicket(from, to, dateAndTime.ToString("dd.MM.yyyy HH:mm"), price.ToString(CultureInfo.InvariantCulture), studentPrice.ToString(CultureInfo.InvariantCulture));
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateAndTime)
        {
            return this.DeleteTrainTicket(from, to, dateAndTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateAndTime, decimal price)
        {
            return this.AddBusTicket(from, to, travelCompany, dateAndTime.ToString("dd.MM.yyyy HH:mm"), price.ToString(CultureInfo.InvariantCulture));
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateAndTime)
        {
            return this.DeleteBusTicket(from, to, travelCompany, dateAndTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Flight)
            {
                return this.airTicketsCount;
            }

            if (type == TicketType.Bus)
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }
        
        internal string AddTicket(Ticket ticket)
        {
            string key = ticket.Key;
            if (this.ticketsByKey.ContainsKey(key))
            {
                return "Duplicated " + ticket.Type.ToLower();
            }

            this.ticketsByKey.Add(key, ticket);
            this.ticketsByFromTo.Add(ticket.FromToKey, ticket);
            this.ticketsByDateAndTime.Add(ticket.DateAndTime, ticket);
            return ticket.Type + " added";
        }

        internal string DeleteTicket(Ticket ticket)
        {
            string key = ticket.Key;
            if (this.ticketsByKey.ContainsKey(key))
            {
                ticket = this.ticketsByKey[key];
                this.ticketsByKey.Remove(key);
                this.ticketsByFromTo.Remove(ticket.FromToKey, ticket);
                this.ticketsByDateAndTime.Remove(ticket.DateAndTime, ticket);
                return ticket.Type + " deleted";
            }

            return ticket.Type + " does not exist";
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
            string result = "Invalid command!";
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(
            new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            switch (command)
            {
                case "CreateFlight":
                    result = this.AddAirTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
                    break;
                case "DeleteFlight":
                    result = this.DeleteAirTicket(parameters[0]);
                    break;
                case "CreateTrain":
                    result = this.AddTrainTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;
                case "DeleteTrain":
                    result = this.DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                    break;
                case "CreateBus":
                    result = this.AddBusTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;
                case "DeleteBus":
                    result = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
                    break;
                case "FindTickets":
                    result = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindByDates":
                    DateTime startDateTime = Ticket.ParseDateTime(parameters[0]);
                    DateTime endDateTime = Ticket.ParseDateTime(parameters[1]);
                    result = this.FindTicketsInInterval(startDateTime, endDateTime);
                    break;
            }

            return result;
        }
        
        // TODO ??
        private static string ReadTickets(ICollection<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);
            sortedTickets.Sort();
            string result = string.Empty;
            for (int i = 0; i < sortedTickets.Count; i++)
            {
                Ticket ticket = sortedTickets[i];
                result += ticket.ToString();
                if (i < sortedTickets.Count - 1)
                {
                    result += " ";
                }
            }

            return result;
        }
    }
}
