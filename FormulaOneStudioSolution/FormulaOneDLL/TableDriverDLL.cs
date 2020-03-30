using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class TableDriverDLL
    {
        private string forename;
        private string surname;
        private int number;
        private string dob;
        private string nationality;
        private string url;

        public TableDriverDLL(string forename, string surname, int number, string dob, string nationality, string url)
        {
            this.forename = forename;
            this.surname = surname;
            this.number = number;
            this.dob = dob;
            this.nationality = nationality;
            this.url = url;
        }

        public string Forename { get => forename; set => forename = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Number { get => number; set => number = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Url { get => url; set => url = value; }
    }
}
