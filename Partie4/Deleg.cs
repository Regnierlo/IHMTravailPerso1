using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie4
{
    //delegate double CalculatriceV2(double nb1, double nb2);

    class Deleg
    {
        //Declaration de l'affichage V2 mais cette fois ci en dehors du main().
        //Comme pour une déclaration de variable
        Action<double> AfficheV2 = s => Console.WriteLine("Resultat : {0}", s);

        public Deleg()
        {
            start(); //Suite du test
        }

        private void start()
        {
            //Utilisation de AfficheV2 déclaré en haut
            AfficheV2(AdditionV2(1,1));
            //Utilisation de l'addition V1 dans la classe Program
            CalculatriceV1 addv1 = Program.AdditionV1;
            //Idem mais cette fois ci on utilise la version 2 - Méthode Basique -> appel de fonction
            AfficheV2(AdditionV2(1, 2));
            //Idem mais cette fois ci en utilisant le délégué
            CalculatriceV2 addv2 = AdditionV2;
            //Utilisation du délégué déclaré au dessus
            AfficheV2(addv2(1, 3));
        }

        //Utilisation du mot clé static obligatoire pour utilisé les délégué
        public static double AdditionV2(double nb1, double nb2)
        {
            return nb1 + nb2;
        }
    }
}
