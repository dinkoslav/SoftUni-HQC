namespace Logger.Interfaces
{
    using Enums;

    public interface IAppender
    {
        ILayout Layout { get; set; }
        ReportLevel ReportLevel { get; set; }

        void AppendMessage(ReportLevel report, string message);
    }
}
