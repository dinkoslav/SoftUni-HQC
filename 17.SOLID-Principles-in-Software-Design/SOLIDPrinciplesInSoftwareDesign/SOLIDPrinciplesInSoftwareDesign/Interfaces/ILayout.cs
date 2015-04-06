namespace Logger.Interfaces
{
    using Enums;
    using System;

    public interface ILayout
    {
        DateTime Date { get; set; }
        ReportLevel Report { get; set; }
        string Message { get; set; }

        string FormatLog();
    }
}
