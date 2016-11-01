using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie3
{
    class Program
    {
        static void Main(string[] args)
        {
            Coureur coureur1 = new Coureur(2, "Maggie");
            Coureur coureur2 = new Coureur(11, "Rosita");
            Coureur coureur3 = new Coureur(15, "Michonne");
            Coureur coureur4 = new Coureur(2, "Judith");
            Coureur coureur5 = new Coureur(5, "Glenn");
            Coureur coureur6 = new Coureur(27, "Rick");
            Coureur coureur7 = new Coureur(1, "Abraham");
            Coureur coureur8 = new Coureur(42, "Jesus");
            Coureur coureur9 = new Coureur(24, "Daryl");
            
            Console.WriteLine("\n Que voulez-vous faire ?\n\n");
           
            Console.WriteLine("\n 1 : Travailler sur une collection générique ? \n");
            Console.WriteLine("\n 2 : Travailler sur une collection non générique ? \n");
            int nombre = 0;
            try
            {
                nombre = int.Parse(Console.In.ReadLine());
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("L'erreur suivante s'est produite : " + e.Message);
            }

            if (nombre == 1)
            {
                Console.WriteLine("--- 1 = Un dictionnaire correspondant à la liste des coureurs nom /n° maillot\n");
                Console.WriteLine("--- 2 = Une queue<Coureur>\n");
                Console.WriteLine("--- 3 = Un stack<Coureur>\n");
                try
                {
                    nombre = int.Parse(Console.In.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("L'erreur suivante s'est produite : " + e.Message);
                }

                switch (nombre)
                {
                    case 1:
                        Generique_Dictionnaire dictionnaire = new Generique_Dictionnaire();

                        dictionnaire.Ajouter( 12 , coureur1 );
                        dictionnaire.Ajouter( 2 , coureur2 );
                        dictionnaire.Ajouter( 34 , coureur3 );
                        dictionnaire.Ajouter( 14 , coureur4 );
                        dictionnaire.Ajouter( 5 , coureur5 );
                        dictionnaire.Ajouter( 67 , coureur6 );
                        dictionnaire.Ajouter( 17 , coureur7 );
                        dictionnaire.Ajouter( 98 , coureur8 );
                        dictionnaire.Ajouter( 97 , coureur9 );
                        dictionnaire.RechercherKey(5);
                        dictionnaire.TriKey();
                        dictionnaire.Afficher();
                        dictionnaire.Supprimer(5);
                        dictionnaire.Supprimer(1);
                        dictionnaire.RechercherKey(5);
                        dictionnaire.RechercherValue(coureur9);
                        dictionnaire.Inserer(4, new Coureur(1, "Negan"),1);
                        dictionnaire.Afficher();
                        dictionnaire.SupprimerDictionary();
                        dictionnaire.Afficher();

                        break;

                    case 2:
                        Generique_Queue queue = new Generique_Queue();
                        queue.Ajouter(coureur1);
                        queue.Ajouter(coureur2);
                        queue.Ajouter(coureur3);
                        queue.Ajouter(coureur4);
                        queue.Ajouter(coureur5);
                        queue.Ajouter(coureur6);
                        queue.Ajouter(coureur7);
                        queue.Ajouter(coureur8);
                        queue.Ajouter(coureur9);
                        queue.Afficher();
                        queue.Rechercher(coureur1);
                        queue.Supprimer(coureur5);
                        queue.SupprimerIndex(7);
                        queue.Rechercher(coureur5);
                        queue.Insérer(coureur5, 2);
                        queue.Afficher();
                        queue.Tri();
                        queue.Afficher();
                        queue.SupprimerQueue();
                        queue.Afficher();

                        break;
                    case 3:
                        Generique_Stack stack = new Generique_Stack();
                        Console.WriteLine("\n------ Ajout des coureurs \n");
                        stack.Ajouter(coureur1);
                        stack.Ajouter(coureur2);
                        stack.Ajouter(coureur3);
                        stack.Ajouter(coureur4);
                        stack.Ajouter(coureur5);
                        stack.Ajouter(coureur6);
                        stack.Ajouter(coureur7);
                        stack.Ajouter(coureur8);
                        stack.Ajouter(coureur9);

                        Console.WriteLine("\n------- Suppression de Abraham------\n");
                        stack.Supprimer(coureur7);
                        stack.Afficher();


                        Console.WriteLine("\n------- Ajout de Abraham en bas de la collection------\n");
                        stack.Inserer(coureur7, 1);
                        stack.Afficher();

                        Console.WriteLine("\n------- Recherche de Daryl------\n");
                        stack.Rechercher(coureur9);
                        stack.Afficher();

                        Console.WriteLine("\n------- Tri des coureurs------\n");
                        stack.Tri();
                        stack.Afficher();

                        Console.WriteLine("\n------- Suppression de la collection------\n");
                        stack.SupprimerStack();
                        stack.Afficher();
                        

                        break;

                    default:
                        Console.WriteLine("Le numéro tapé ne correspond à rien.");
                        break;
                }

            }
            else if (nombre == 2)
            {
                Console.WriteLine("\n    1 = Utilisation de Hashtable\n");
                Console.WriteLine("    2 = Utilisation de SortedList\n");
                Console.WriteLine("    3 = Utilisation de Queue\n");
                try
                {
                    nombre = int.Parse(Console.In.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("L'erreur suivante s'est produite : " + e.Message);
                }

                switch (nombre)
                {
                    case 1:
                        NonGenerique_Hashtable hashtable = new NonGenerique_Hashtable();
                        hashtable.Ajouter(coureur1, "Rhee");
                        hashtable.Ajouter(coureur1.Nom, true);
                        hashtable.Ajouter(coureur1.Nom, 15);
                        hashtable.Ajouter(coureur9, null);
                        hashtable.Ajouter(coureur8.Maillot, false);
                        hashtable.Ajouter(coureur8, "Paul Rovia");
                        hashtable.Ajouter(coureur5, "Rhee");
                        hashtable.Afficher();
                        hashtable.RechercherValue("Rhee");
                        hashtable.RechercherValue(null);
                        hashtable.RechercherKey(coureur7);
                        hashtable.RechercherKey(coureur9);
                        hashtable.SupprimerKey(coureur5);
                        hashtable.Afficher();
                        hashtable.SupprimerHashtable();
                        hashtable.Afficher();
                        break;

                    case 2:
                        NonGenerique_SortedList sortedList = new NonGenerique_SortedList();
                        sortedList.ajouter(coureur2, coureur1);
                        sortedList.ajouter(coureur3, coureur4);
                        sortedList.ajouter(coureur9, coureur8.Maillot);
                        sortedList.ajouter(coureur8, coureur7.Nom);
                        sortedList.ajouter(coureur1, null);
                        sortedList.afficher();
                        sortedList.supprimerIndex(sortedList.recupererIndexKey(coureur9));
                        sortedList.afficher();
                        sortedList.supprimerKey(coureur8);
                        sortedList.afficher();
                        sortedList.ajouter(coureur1, coureur8);
                        sortedList.ajouter(coureur7, coureur4);
                        sortedList.rechercherKey(coureur8);
                        sortedList.rechercherValue(coureur4);
                        sortedList.ajouter(coureur4, null);
                        sortedList.rechercherValue(null);
                        sortedList.rechercher(coureur1);
                        sortedList.supprimerCollection();
                        sortedList.afficher();
                        break;

                    case 3:
                        NonGenerique_Queue queue = new NonGenerique_Queue();
                        queue.ajouter(coureur1);
                        queue.ajouter(true);
                        queue.ajouter(coureur7.Nom);
                        queue.ajouter(coureur4.Nom + " a comme numéro de maillot le n°  " + coureur4.Maillot);
                        queue.afficher();
                        queue.inserer("Negan", 2);
                        queue.afficher();
                        queue.rechercher("Negan");
                        queue.inserer(true, 2);
                        queue.afficher();
                        queue.rechercher(true);
                        queue.supprimer(true);
                        queue.rechercher(true);
                        queue.afficher();
                        queue.supprimerQueue();
                        queue.afficher();
                        break;

                    default: Console.WriteLine("Le numéro tapé ne correspond à rien.");
                        break;
                }
            }
        }
    }
}
