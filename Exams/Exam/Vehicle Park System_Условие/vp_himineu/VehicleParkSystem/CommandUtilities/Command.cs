namespace VehicleParkSystem.CommandUtilities
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using Interfaces;

    public class Command : ICommand
    {
        private string name;

        public Command(string name)
        {
            this.Name = name;
            this.Parameters = new JavaScriptSerializer()
                .Deserialize<Dictionary<string, string>>(name.Substring(name.IndexOf(' ') + 1));
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value.Substring(0, value.IndexOf(' '));
            }
        }

        public IDictionary<string, string> Parameters { get; set; }
    }
}
