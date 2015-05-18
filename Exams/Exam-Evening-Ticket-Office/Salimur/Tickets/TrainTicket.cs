namespace TicketOffice.Tickets
{
    using System;

    internal class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, string dateAndTime)
        {
            this.From = from;
            this.To = to;
            this.DateAndTime = Ticket.ParseDateTime(dateAndTime);
        }

        public TrainTicket(string from, string to, string dateAndTime, string price, string studentPrice)
            : this(from, to, dateAndTime)
        {
            this.Price = decimal.Parse(price);
            this.StudentPrice = decimal.Parse(studentPrice);
        }

        public decimal StudentPrice { get; set; }

        public override string Type
        {
            get
            {
                return "Train";
            }
        }

        public override string Key
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
            }
        }
    }
}
