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

                        dictionnaire.AjoutDico(coureur1.Nom, coureur1.Maillot);
                        dictionnaire.AjoutDico(coureur2.Nom, coureur2.Maillot);
                        dictionnaire.AjoutDico(coureur3.Nom, coureur3.Maillot);
                        dictionnaire.AjoutDico(coureur4.Nom, coureur4.Maillot);
                        dictionnaire.AjoutDico(coureur5.Nom, coureur5.Maillot);
                        dictionnaire.AjoutDico(coureur6.Nom, coureur6.Maillot);
                        dictionnaire.AjoutDico(coureur7.Nom, coureur7.Maillot);
                        dictionnaire.AjoutDico(coureur8.Nom, coureur8.Maillot);
                        dictionnaire.AjoutDico(coureur9.Nom, coureur9.Maillot);

                        Console.WriteLine("-------------------------------------------------\n--On recherche la clé 5 dans la collection.\n");
                        dictionnaire.RechercheNumero(5);

                        Console.WriteLine("-------------------------------------------------\n--On trie la collection.\n");
                        dictionnaire.TrierDico();
                        dictionnaire.affichageDico();

                        Console.WriteLine("-------------------------------------------------\n--On supprime les coureurs ayant les numéros 5 et 1 dans la collection.\n");
                        dictionnaire.SupprimerDico(5);
                        dictionnaire.SupprimerDico(1);

                        Console.WriteLine("-------------------------------------------------\n--On recherche le coureur avec le maillot 5 dans la collection.\n");
                        dictionnaire.RechercheNumero(5);

                        Console.WriteLine("-------------------------------------------------\n--On affiche la collection.");
                        dictionnaire.affichageDico();

                        Console.WriteLine("-------------------------------------------------\n--On supprime la collection.");
                        dictionnaire.SupprimerDicoEntier();
                        dictionnaire.affichageDico();

                        break;

                    case 2:
                        Generique_Queue queue = new Generique_Queue();
                        Console.WriteLine("\nDans cet exemple illustrant la collection Queue<T>, nous utiliserons les noms des coureurs.\n");
                        Console.WriteLine("\n------ Ajout des coureurs \n");
                        queue.ajouter(coureur1);
                        queue.ajouter(coureur2);
                        queue.ajouter(coureur3);
                        queue.ajouter(coureur4);
                        queue.ajouter(coureur5);
                        queue.ajouter(coureur6);
                        queue.ajouter(coureur7);
                        queue.ajouter(coureur8);
                        queue.ajouter(coureur9);

                        Console.WriteLine("\n------- Affichage de la queue------ \n");
                        queue.afficherQueue();

                        Console.WriteLine("\n------ Recherche du coureur Maggie ------\n");
                        queue.rechercher(coureur1);

                        Console.WriteLine("\n------ Suppression de Glenn ------\n");
                        queue.supprimerS(coureur5);

                        Console.WriteLine("\n------ Suppression d'Abraham en fonction de son emplacement ------ \n");
                        queue.supprimerI(7);

                        Console.WriteLine("\n------ Recherche de Glenn  ------ \n");
                        queue.rechercher(coureur5);

                        Console.WriteLine("\n------ Insertion de Glenn à l'emplacement 2  ------ \n");
                        queue.inserer(coureur5, 2);

                        Console.WriteLine("\n------ Affichage de la queue ------ \n");
                        queue.afficherQueue();

                        Console.WriteLine("\n------ Tri de la queue ------ \n");
                        queue.trierQueue();

                        Console.WriteLine("\n------ Affichage de la queue ------ \n");
                        queue.afficherQueue();

                        queue.supprimerQueue();
                        Console.WriteLine("\n------ Affichage de la queue ------ \n");
                        queue.afficherQueue();

                        break;
                    case 3:
                        Generique_Stack stack = new Generique_Stack();
                        Console.WriteLine("\n------ Ajout des coureurs \n");
                        stack.ajouter(coureur1);
                        stack.ajouter(coureur2);
                        stack.ajouter(coureur3);
                        stack.ajouter(coureur4);
                        stack.ajouter(coureur5);
                        stack.ajouter(coureur6);
                        stack.ajouter(coureur7);
                        stack.ajouter(coureur8);
                        stack.ajouter(coureur9);

                        Console.WriteLine("\n------- Suppression de Abraham------\n");
                        stack.supprimerC(coureur7);
                        stack.afficherStack();


                        Console.WriteLine("\n------- Ajout de Abraham en bas de la collection------\n");
                        stack.inserer(coureur7, 1);
                        stack.afficherStack();

                        Console.WriteLine("\n------- Recherche de Daryl------\n");
                        stack.rechercher(coureur9);
                        stack.afficherStack();

                        Console.WriteLine("\n------- Tri des coureurs------\n");
                        stack.trierStack();
                        stack.afficherStack();

                        Console.WriteLine("\n------- Suppression de la collection------\n");
                        stack.supprimerStack();
                        stack.afficherStack();

                        break;

                    default:
                        Console.WriteLine("Le numéro tapé ne correspond à rien.");
                        break;
                }

            }
            else if (nombre == 2)
            {
                Console.WriteLine("--- 1 = Utilisation de Hashtable\n");
                Console.WriteLine("--- 2 = x\n");
                Console.WriteLine("--- 3 = x\n");
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
                        hashtable.ajouter(coureur1.Maillot, coureur1.Nom);
                        hashtable.ajouter(coureur2.Maillot, coureur2.Nom);
                        hashtable.ajouter(coureur3.Maillot, coureur3.Nom);
                        hashtable.ajouter(coureur4.Maillot, coureur4.Nom);
                        hashtable.ajouter(coureur5.Maillot, coureur5.Nom);
                        hashtable.ajouter(coureur6.Maillot, coureur6.Nom);
                        hashtable.ajouter(coureur7.Maillot, coureur7.Nom);
                        hashtable.ajouter(coureur8.Maillot, coureur8.Nom);
                        hashtable.ajouter(coureur9.Maillot, coureur9.Nom);
                        hashtable.afficher();
                        hashtable.rechercher();
                        hashtable.afficher();
                        break;

                    case 2:
                        NonGenerique_SortedList sortedList = new NonGenerique_SortedList();
                        sortedList.ajouter(coureur2, coureur1);
                        sortedList.ajouter(coureur3, coureur4);
                        sortedList.ajouter(coureur9, coureur8.Maillot);
                        sortedList.ajouter(coureur8, coureur7.Nom);
                        sortedList.afficher();
                        sortedList.supprimerIndex(sortedList.recupererIndexKey(coureur9));
                        sortedList.afficher();
                        sortedList.supprimerKey(coureur8);
                        sortedList.afficher();

                        sortedList.ajouter(coureur1, coureur8);
                        sortedList.ajouter(coureur7, coureur4);
                        sortedList.rechercherKey(coureur8);
                        sortedList.rechercherValue(coureur4);
                        sortedList.rechercher(coureur1);

                        break;
                    case 3:
                        break;

                    default: Console.WriteLine("Le numéro tapé ne correspond à rien.");
                        break;
                }
            }
        }
    }
}
