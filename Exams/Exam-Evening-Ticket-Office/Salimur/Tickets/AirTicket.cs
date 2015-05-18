namespace TicketOffice.Tickets
{
    using System;

    internal class AirTicket : Ticket
    {
        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
        }

        public AirTicket(string flightNumber, string from, string to, string airline, string dateAndTime, string price)
            : this(flightNumber)
        {
            this.From = from;
            this.To = to;
            this.Company = airline;
            this.DateAndTime = Ticket.ParseDateTime(dateAndTime);
            this.Price = decimal.Parse(price);
        }

        public string FlightNumber { get; set; }

        public override string Type
        {
            get
            {
                return "Flight";
            }
        }

        public override string Key
        {
            get
            {
                return this.Type + ";;" + this.FlightNumber;
            }
        }
    }
}
