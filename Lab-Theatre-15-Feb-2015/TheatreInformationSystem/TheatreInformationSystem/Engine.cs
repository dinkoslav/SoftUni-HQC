namespace TheatreInformationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Globalization;

    using global::TheatreInformationSystem.Contracts;

    static class Engine
    {

        private static IPerformanceDatabase PerformanceDatabase = new PerformanceDatabase();

        public static string ExecuteProcessCommand(string commandLine)
        {
            string[] commandParts = commandLine.Split('(');
            string command = commandParts[0];
            string commandResult;
            string[] commandParameters = ExtractCommandParameters(commandLine);

            try
            {
                switch (command)
                {
                    case "AddTheatre":
                        commandResult = ExecuteAddTheatreCommand(commandParameters);
                        break;
                    case "PrintAllTheatres":
                        commandResult = ExecutePrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        string theatreName = commandParameters[0];
                        string performanceTitle = commandParameters[1];
                        DateTime startDateTime = 
                            DateTime.ParseExact(commandParameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                        TimeSpan duration = TimeSpan.Parse(commandParameters[3]);
                        decimal price = decimal.Parse(commandParameters[4], NumberStyles.Float);

                        PerformanceDatabase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                        commandResult = "Performance added";
                        break;
                    case "PrintAllPerformances":
                        commandResult = Engine.ExecutePrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        string theatre = commandParameters[0];
                        var performances = PerformanceDatabase.ListPerformances(theatre)
                            .Select(p => {
                                string startTime = p.StartDateTime.ToString("dd.MM.yyyy HH:mm");
                                return string.Format("({0}, {1})", p.Name, startTime);})
                            .ToList();
                        commandResult = performances.Any() ? string.Join(", ", performances) : "No performances";
                        break;
                    default:
                        commandResult = "Invalid command!";
                        break;
                }
            }
            catch (Exception ex)
            {
                commandResult = "Error: " + ex.Message;
            }

            return commandResult;
        }

        private static string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[0];
            PerformanceDatabase.AddTheatre(theatreName);
            return "Theatre added";
        }

        private static string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = PerformanceDatabase.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = PerformanceDatabase.ListTheatres().ToList();
                return string.Join(", ", resultTheatres);
            } 
            
            return "No theatres";
        }

        private static string ExecutePrintAllPerformancesCommand()
        {
            var performances = PerformanceDatabase.ListAllPerformances().ToList();
            var result = new StringBuilder();
            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    if (i > 0)
                    {
                        result.Append(", ");
                    }

                    string startTime = performances[i].StartDateTime.ToString("dd.MM.yyyy HH:mm");
                    result.AppendFormat("({0}, {1}, {2})", performances[i].Name, performances[i].TheatreName, startTime);
                }

                return result.ToString();
            }

            return "No performances";
        }

        private static string[] ExtractCommandParameters(string commandLine) {
            string[] splittedCommandLine =
                            commandLine.Split(new[] { '(', ',', ')' },
                            StringSplitOptions.RemoveEmptyEntries);
            string[] commandParameters = splittedCommandLine.Skip(1).Select(p => p.Trim()).ToArray();
            return commandParameters;
        }
    }
}
