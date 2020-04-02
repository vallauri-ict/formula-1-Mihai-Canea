using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class CircuitsDLL
    {
        private string name;
        private string location;
        private string country;
        private string url;

        public CircuitsDLL(string name, string location, string country, string url)
        {
            this.name = name;
            this.location = location;
            this.country = country;
            this.url = url;
        }

        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }
        public string Country { get => country; set => country = value; }
        public string Url { get => url; set => url = value; }
    }
}
