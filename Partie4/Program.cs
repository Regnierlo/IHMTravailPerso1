using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie4
{
    //Déclaration des délégués
    public delegate double CalculatriceV1(double nb1, double nb2);
    delegate double CalculatriceV2(double nb1, double nb2); //!\\ Non apprecie par le compilateur avec le mot cle private

    class Program
    {
        //public delegate double CalculatriceV1(double nb1, double nb2); //!\\ Non apprecie dans la declaration de CalculatriceV1 de la classe Deleg

        //Méthode static respectant la signature de délégué associé
        public static double AdditionV1(double nb1, double nb2)
        {
            return nb1 + nb2;
        }

        static void Main(string[] args)
        {
            //Methode 1  - Déclaration d'un pointeur de fonction (grande portée)
            CalculatriceV1 add = AdditionV1;
            //Methode 2 - Declaration d'un pointeur de fonction (portée plus courte)
            CalculatriceV1 Soustraction = delegate(double nb1, double nb2)
            {
                return nb1 - nb2;
            };
            //Methode 3 - Declaration d'un nouveau délégué (portée tres courte)
            Action<double> AfficheV1 = (s) => Console.WriteLine("Resultat : {0}", s);
            //Utilisation du délégué AfficheV1 avec celui du add
            AfficheV1(add(7, 3));
            //Idem mais avec la soustraction
            AfficheV1(Soustraction(7, 3));
            //Declaration d'une deuxieme version située dans une autre classe
            CalculatriceV2 addV2 = Deleg.AdditionV2;
            //Utilisation de cette deuxieme version
            AfficheV1(addV2(7, 4));

            //Suite du test dans une autre classe
            Deleg d = new Deleg();
            
        }
    }
}
