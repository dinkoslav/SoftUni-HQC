namespace TicketOffice
{
    using System;

    public class TicketOffice
    {
        public static void Main()
        {
            TicketOfficeEngine catalog = new TicketOfficeEngine();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                string commandResult = catalog.ProcessCommand(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}
