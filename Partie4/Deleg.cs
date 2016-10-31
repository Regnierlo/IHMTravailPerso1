using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie4
{
    class Deleg
    {
        delegate double Calculatrice(double nb1, double nb2);
        public Deleg()
        {
            Calculatrice addition = delegate(double input1, double input2)
            {
                return input1 + input2;
            };

            Calculatrice soustraction = delegate(double input1, double input2)
            {
                return input1 - input2;
            };

            Console.WriteLine("Resultat de 4+5 : {0}", addition(4, 5));

            Action<double> Affiche = (s) => Console.WriteLine("Résultat : {0}", s);
            Affiche(soustraction(7, 3));
        }
    }
}
