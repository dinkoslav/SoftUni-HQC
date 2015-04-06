namespace Logger
{
    using Enums;
    using Interfaces;
    using System;

    public class SimpleLayout : ILayout
    {
        private string message;

        public DateTime Date { get; set; }

        public ReportLevel Report { get; set; }

        public string Message
        {
            get { return this.message; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Message can not be null or empty!");
                }

                this.message = value;
            }
        }

        public string FormatLog()
        {
            return this.Date + " - " + this.Report + " - " + this.Message;
        }
    }
}
