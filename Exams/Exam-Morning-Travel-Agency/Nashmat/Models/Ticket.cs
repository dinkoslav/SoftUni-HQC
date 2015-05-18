namespace TravelAgency.Models
{
    using System;

    internal abstract class Ticket : IComparable<Ticket>
    {
        public abstract string Type { get; }

        public virtual string From { get; set; }

        public virtual string To { get; set; }

        public virtual string Company { get; set; }

        public virtual DateTime DateAndTime { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal SpecialPrice { get; set; }

        public abstract string Description { get; }

        public string FromToKey
        {
            get
            {
                return this.From + "; " + this.To;
            }
        }

        public int CompareTo(Ticket otherTicket)
        {
            int difference = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (difference == 0)
            {
                difference = string.Compare(this.Type, otherTicket.Type, StringComparison.Ordinal);
                if (difference == 0)
                {
                    difference = this.Price.CompareTo(otherTicket.Price);
                }
            }

            return difference;
        }

        public override string ToString()
        {
            string input = "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + "; " + this.Type + "; " +
                           string.Format("{0:f2}", this.Price) + "]";
            return input;
        }
    }
}
