namespace Logger
{
    using Enums;
    using Interfaces;

    public class Logger: ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders { get; set; }

        public void Error(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.AppendMessage(ReportLevel.Error, message);
            }
        }

        public void Info(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.AppendMessage(ReportLevel.Info, message);
            }
        }

        public void Warn(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.AppendMessage(ReportLevel.Warning, message);
            }
        }

        public void Critical(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.AppendMessage(ReportLevel.Critical, message);
            }
        }

        public void Fatal(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.AppendMessage(ReportLevel.Fatal, message);
            }
        }
    }
}
