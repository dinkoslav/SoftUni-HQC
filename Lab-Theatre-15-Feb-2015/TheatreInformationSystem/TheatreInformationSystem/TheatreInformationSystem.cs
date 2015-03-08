/*//////////////////////////////////////
///                                  ///
///   Author: Huy Phuong Nguyen,     ///
///   Qui Nhơn, Bình Định, Vietnam   ///
///   Email: huy_p_n@yahoo.vn        ///
///                                  ///
//////////////////////////////////////*/

namespace TheatreInformationSystem
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System;
    using System.Threading;

    using global::TheatreInformationSystem.Contracts;
    using global::TheatreInformationSystem.Exceptions;

    internal class TheatreInformationSystem
    {
        private const int MaxCommandsCount = 50000;
        
        protected static void Main()
        {
            int counter = 0;

            while (counter < MaxCommandsCount)
            {
                string commandLine = Console.ReadLine(); 

                if (!string.IsNullOrEmpty(commandLine))
                {
                    string commandResult = Engine.ExecuteProcessCommand(commandLine);
                    Console.WriteLine(commandResult);
                }

                counter++;
            }
        }
    }
}
