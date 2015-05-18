namespace TravelAgency.Models
{
    using System;

    internal class AirTicket : Ticket
    {
        private const string TicketType = "air";

        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
        }

        public AirTicket(string flightNumber, string from, string to, string company, DateTime dateAndTime, decimal price)
            : this(flightNumber)
        {
            this.From = from;
            this.To = to;
            this.Company = company;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public string FlightNumber { get; set; }

        public override string Type
        {
            get
            {
                return TicketType;
            }
        }

        public override string Description
        {
            get
            {
                return this.Type + ";;" + this.FlightNumber;
            }
        }
    }
}
