namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;

    public static class VehicleParkSystem
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new VehicleParkEngine(); 
            engine.ProcessCommand();
        }
    }
}