namespace TravelAgency.Models
{
    using System;

    internal class BusTicket : Ticket
    {
        private const string TicketType = "bus";

        public BusTicket(string from, string to, string company, DateTime dateAndTime)
        {
            this.From = from;
            this.To = to;
            this.Company = company;
            this.DateAndTime = dateAndTime;
        }

        public BusTicket(string from, string to, string company, DateTime dateAndTime, decimal price)
            : this(from, to, company, dateAndTime)
        {
            this.Price = price;
        }

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
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
            }
        }
    }
}
