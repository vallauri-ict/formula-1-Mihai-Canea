using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class testClass
    {
        private string pathImage;
        private string name;
        private string dob;

        public testClass(string pathImage, string name, string dob)
        {
            this.pathImage = pathImage;
            this.name = name;
            this.dob = dob;
        }

        public string PathImage { get => pathImage; set => pathImage = value; }
        public string Name { get => name; set => name = value; }
        public string Dob { get => dob; set => dob = value; }
    }
}
