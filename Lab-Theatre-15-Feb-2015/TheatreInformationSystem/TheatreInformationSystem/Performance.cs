namespace TheatreInformationSystem
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatreName, string name, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.Name = name;
            this.StartDateTime = startDateTime;
            this.Duration = duration; 
            this.Price = price;
        }

        public string TheatreName { get; protected internal set; }
        public string Name { get; private set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; private set; }
        protected internal decimal Price { get; protected set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int result = this.StartDateTime.CompareTo(otherPerformance.StartDateTime);
            return result;
        }

        public override string ToString()
        {
            string result = string.Format("Performance(Theatre: {0}; Name: {1}; Date: {2}, Duration: {3}, Price: {4})",
                this.TheatreName, 
                this.Name, 
                this.StartDateTime.ToString("dd.MM.yyyy HH:mm"),
                this.Duration.ToString("hh':'mm"), 
                this.Price.ToString("f2"));
            return result;
        }
    }
}
