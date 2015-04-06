namespace Logger
{
    using Enums;
    using Interfaces;
    using System;
    using System.Text;

    public class XmlLayout: ILayout
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
            StringBuilder result = new StringBuilder();
            result.Append("<log>").AppendLine()
                .AppendFormat("   <date>{0}</date>", this.Date).AppendLine()
                .AppendFormat("   <level>{0}</level>", this.Report).AppendLine()
                .AppendFormat("   <message>{0}</message>", this.Message).AppendLine()
                .Append("<log>");

            return result.ToString();
        }
    }
}
