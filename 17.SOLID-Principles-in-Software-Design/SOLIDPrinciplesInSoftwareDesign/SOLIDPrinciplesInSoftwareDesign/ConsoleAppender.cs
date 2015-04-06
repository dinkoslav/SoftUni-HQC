namespace Logger
{
    using Enums;
    using Interfaces;
    using System;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void AppendMessage(ReportLevel report, string message)
        {
            if ((int) report >= (int) ReportLevel)
            {
                this.Layout.Date = DateTime.Now;
                this.Layout.Report = report;
                this.Layout.Message = message;

                string result = this.Layout.FormatLog();
                Console.WriteLine(result);
                Console.WriteLine(ReportLevel.Critical.GetHashCode());
            }
        }
    }
}
