namespace TravelAgency.Models
{
    using System;

    internal class BoatTicket : Ticket
    {
        private const string TicketType = "boat";

        public BoatTicket(string from, string to, string company, DateTime dateAndTime, decimal price)
        {
            this.From = from;
            this.To = to;
            this.Company = company;
            this.DateAndTime = dateAndTime;
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
                return this.Type + ";;" + this.From + ";" + this.To + ";" +
                       this.Company + this.DateAndTime + ";";
            }
        }
    }
}
