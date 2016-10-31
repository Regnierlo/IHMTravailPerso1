using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;

            Console.WriteLine("Il est actuellement : " + dt.Hour + "h " + dt.Minute + "min\n");
            string resBi = DateTime.IsLeapYear(dt.Year) ? "Vrai ! :D" : "Faux... :'(";
            Console.WriteLine("Année bissextile ? " +resBi);
        }
    }
}
