using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Partie1;
using System.Reflection;

namespace Partie2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Panier<Produit> pan = new Panier<Produit>();
            /*Panier<Produit> pan = new Panier<Produit>();
            Produit p1 = new Produit(42, "TestNom", (float)1.9, CategorieProduit.NonConsommable, "TestSousCat");
            pan.Add(p1);
            Produit p2 = new Produit(11, "Test2", (float)1, CategorieProduit.NonConsommable, "TestSousC");
            pan.Add(p2);
            Console.WriteLine(pan+"\n");
            pan.Sort();
            Console.WriteLine("--------------------------------\nTRIER\n" + pan);
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
            Console.WriteLine("\n\nAppuyez sur une touche pour continuer");
            Console.ReadLine();
            Console.Clear();*/
            

            //Début démo utilisateur
            Console.WriteLine("Choisir le type a utiliser pour le panier :\n\t1 - Produits\n\t2 - Magasins");
            string choixp = Console.ReadLine();
            
            Panier<Produit> pp;
            Panier<Magasin> pm;

            if (Int32.Parse(choixp) == 1)
            {
                pp = new Panier<Produit>();
                Produit p1 = new Produit(42, "TestNom", (float)1.9, CategorieProduit.NonConsommable, "TestSousCat");
                pp.Add(p1);
                Produit p2 = new Produit(11, "Test2", (float)1, CategorieProduit.NonConsommable, "TestSousC");
                pp.Add(p2);
                Console.WriteLine(pp + "\n");
                pp.Sort();
                Console.WriteLine("--------------------------------\nTRIER\n" + pp);
                pp.Remove(p2);
                Console.WriteLine("--------------------------------\nREMOVE P2\n" + pp);
                pp.Add(p2);
                Console.WriteLine("--------------------------------\nADD P2\n" + pp);
                pp.Remove(p1);
                Console.WriteLine("--------------------------------\nREMOVE P1\n" + pp);
                pp.Add(p1);
                Console.WriteLine("--------------------------------\nADD P1\n" + pp);
                Console.WriteLine("--------------------------------\nELEMENT AT (2)\n" + pp.ElementAt(2));
                Console.WriteLine("--------------------------------\nELEMENT AT (1)\n" + pp.ElementAt(1));
                Console.WriteLine("--------------------------------\nFIND P1\n" + pp.FindElement(p1));
                Console.WriteLine("--------------------------------\nFIND P2\n" + pp.FindElement(p2));
                Console.WriteLine("\n\nAppuyez sur une touche pour continuer");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                pm = new Panier<Magasin>();
                Magasin m1 = new Magasin(42, "Leclerc", 348465794, "Dijon");
                pm.Add(m1);
                Magasin m2 = new Magasin(11, "Carrefour", 349785477, "Dijon");
                pm.Add(m2);
                Console.WriteLine(pm + "\n");
                pm.Sort();
                Console.WriteLine("--------------------------------\nTRIER\n" + pm);
                pm.Remove(m2);
                Console.WriteLine("--------------------------------\nREMOVE P2\n" + pm);
                pm.Add(m2);
                Console.WriteLine("--------------------------------\nADD P2\n" + pm);
                pm.Remove(m1);
                Console.WriteLine("--------------------------------\nREMOVE P1\n" + pm);
                pm.Add(m1);
                Console.WriteLine("--------------------------------\nADD P1\n" + pm);
                Console.WriteLine("--------------------------------\nELEMENT AT (2)\n" + pm.ElementAt(2));
                Console.WriteLine("--------------------------------\nELEMENT AT (1)\n" + pm.ElementAt(1));
                Console.WriteLine("--------------------------------\nFIND P1\n" + pm.FindElement(m1));
                Console.WriteLine("--------------------------------\nFIND P2\n" + pm.FindElement(m2));
                Console.WriteLine("\n\nAppuyez sur une touche pour continuer");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
