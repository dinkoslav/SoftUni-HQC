namespace VehicleParkSystem
{
    using System;
    using CommandUtilities;
    using Interfaces;

    public class VehicleParkEngine : IEngine
    {
        private readonly ExecuteCommand executeCommand;

        public VehicleParkEngine(ExecuteCommand executeCommand)
        {
            this.executeCommand = executeCommand;
        }

        public VehicleParkEngine()
            : this(new ExecuteCommand())
        {
        }

        public void ProcessCommand()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.executeCommand.Execute(command);
                        Console.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}