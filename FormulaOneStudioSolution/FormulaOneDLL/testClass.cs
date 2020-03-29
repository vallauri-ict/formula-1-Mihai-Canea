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
        private string surname;

        public testClass(string pathImage, string name, string dob)
        {
            this.pathImage = pathImage;
            this.name = name;
            this.surname = dob;
        }

        public string PathImage { get => pathImage; set => pathImage = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
    }
}
