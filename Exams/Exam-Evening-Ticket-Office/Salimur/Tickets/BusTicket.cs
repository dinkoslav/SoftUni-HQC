namespace TicketOffice.Tickets
{
    using System;

    internal class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string travelCompany, string dateAndTime)
        {
            this.From = from;
            this.To = to;
            this.Company = travelCompany;
            this.DateAndTime = Ticket.ParseDateTime(dateAndTime);
        }

        public BusTicket(string from, string to, string travelCompany, string dateAndTime, string price)
            : this(from, to, travelCompany, dateAndTime)
        {
            this.Price = decimal.Parse(price);
        }

        public override string Type
        {
            get
            {
                return "Bus";
            }
        }

        public override string Key
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
            }
        }
    }
}
