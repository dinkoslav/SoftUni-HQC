namespace Logger.Interfaces
{
    public interface ILogger
    {
        IAppender[] Appenders { get; set; }

        void Error(string message);
        void Info(string message);
        void Warn(string message);
        void Critical(string message);
        void Fatal(string message);
    }
}
