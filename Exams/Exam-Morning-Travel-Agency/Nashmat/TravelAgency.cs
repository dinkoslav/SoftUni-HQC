namespace TravelAgency
{
    using System;
    using Engine;

    public class TravelAgency
    {
        public static void Main()
        {
            TravelAgencyEngine engine = new TravelAgencyEngine();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim(); 
                string commandResult = engine.ProcessCommand(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}