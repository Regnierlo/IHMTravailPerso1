using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Partie1;

namespace Partie2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Panier<Produit> pan = new Panier<Produit>();
            Panier<Produit> pan = new Panier<Produit>();
            Produit p1 = new Produit(42, "TestNom", (float)1.9, CategorieProduit.NonConsommable, "TestSousCat");
            pan.Add(p1);
            Produit p2 = new Produit(11, "Test2", (float)1, CategorieProduit.NonConsommable, "TestSousC");
            pan.Add(p2);
            Console.WriteLine(pan+"\n");
            pan.Sort();
            Console.WriteLine("--------------------------------\nTRIER (A FAIRE)\n" + pan);
            pan.Remove(p2);
            Console.WriteLine("--------------------------------\nREMOVE P2\n" + pan);
            pan.Add(p2);
            Console.WriteLine("--------------------------------\nADD P2\n" + pan);
            pan.Remove(p1);
            Console.WriteLine("--------------------------------\nREMOVE P1\n" + pan);
            pan.Add(p1);
            Console.WriteLine("--------------------------------\nADD P1\n" + pan);
            Console.WriteLine("--------------------------------\nELEMENT AT (2)\n" + pan.ElementAt(2));
            Console.WriteLine("--------------------------------\nELEMENT AT (1)\n" + pan.ElementAt(1));
            Console.WriteLine("--------------------------------\nFIND P1\n" + pan.FindElement(p1));
            Console.WriteLine("--------------------------------\nFIND P2\n" + pan.FindElement(p2));
        }
    }
}
