namespace TravelAgency.Models
{
    using System;

    internal class TrainTicket : Ticket
    {
        private const string TicketType = "train";

        public TrainTicket(string from, string to, DateTime dateAndTime)
        {
            this.From = from;
            this.To = to;
            this.DateAndTime = dateAndTime;
        }

        public TrainTicket(string from, string to, DateTime dateAndTime, decimal price, decimal specialPrice)
            : this(from, to, dateAndTime)
        {
            this.Price = price;
            this.SpecialPrice = specialPrice;
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
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
            }
        }
    }
}
