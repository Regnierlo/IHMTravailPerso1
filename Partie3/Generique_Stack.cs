using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie3
{
    class Generique_Stack
    {
        private Stack<Coureur> _stack;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Generique_Stack()
        {
            _stack = new Stack<Coureur>();
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="res">La collection qu'on copiera pour construire notre instance</param>
        public Generique_Stack(Stack<Coureur> res)
        {
            _stack = res;
        }

        /// <summary>
        /// Accesseurs
        /// </summary>
        public Stack<Coureur> Stack
        {
            get { return _stack; }
            set { _stack = value; }
        }

        /// <summary>
        /// Permet d'Afficher le stack entier
        /// </summary>
       public void Afficher()
        {
            Console.WriteLine("\n----- Affichage de la collection -----\n");
            int i = 1;
            if (_stack.Count > 0)
                foreach (Coureur entry in _stack)
                {
                    Console.WriteLine("     {0} : {1}\n", i, entry.ToString());
                    i++;
                }
            else
                Console.WriteLine("x-x Le stack est vide.\n");
        }

        /// <summary>
        /// Permet d'Ajouter un objet au stack
        /// </summary>
        /// <param name="objet">L'objet qu'on veut Ajouter</param>
        public void Ajouter(Coureur objet)
        {
            Console.WriteLine("\n------ Ajout ------ \n");
            _stack.Push(objet);
            Console.WriteLine("{0} a été ajouté.\n", objet.ToString());
        }

        /// <summary>
        /// Permet d'insérer un objet à l'emplacement voulu
        /// </summary>
        /// <param name="objet">L'objet à insérer</param>
        /// <param name="numero">L'emplacementoù on veut insérer l'objet</param>
        public void Inserer(Coureur objet, int index)
        {
            Console.WriteLine("\n------ Insertion ------ \n");
            Stack<Coureur> res = new Stack<Coureur>();
            if (index > _stack.Count)
            {
                res.Push(objet);
                Console.WriteLine("{0} a été ajouté à la fin de la collection.\n", objet.ToString());
                index = -1;
            }
            else
                index--;
            for (int i = _stack.Count-1 ; i >= 0; i--)
            {
                res.Push(_stack.ElementAt(i));
                if (i == index)
                {
                    Console.WriteLine("{0} a été ajouté à l'index {1}.\n", objet.ToString(), (index+1));
                    res.Push(objet);
                }  
            }
            _stack = res;
        }

        /// <summary>
        /// Permet d'appeler la fonction récursive qui va elle, trier le stack
        /// </summary>
        public void Tri()
        {
            Console.WriteLine("\n------ Tri ------ \n");
            Stack<Coureur> res  = new Stack<Coureur>();
            _stack = TriRecursif(_stack, res, _stack.Count);
        }
 
        /// <summary>
        /// Permet de trier la pile de façon récursif
        /// </summary>
        /// <param name="rejet">Le stack des objets non triés</param>
        /// <param name="garde">Le stack déjà trié</param>
        /// <param name="nb">La taille du stack contenant tous les objets</param>
        /// <returns>Le stack trié</returns>
        public Stack<Coureur> TriRecursif(Stack<Coureur> rejet, Stack<Coureur> garde, int nb){
            
            Coureur coureurT = rejet.Peek();
            rejet.Pop();
            Stack<Coureur> temp = new Stack<Coureur>(rejet);
            rejet.Clear();
            do
            {
                foreach (Coureur entry in temp)
                {
                    if (coureurT.CompareTo(entry)==-1)
                    {
                        rejet.Push(coureurT);
                        coureurT = entry;
                    }
                    else
                        if (coureurT.CompareTo(entry) == 1)
                        {
                            rejet.Push(entry);
                        }
                }
                garde.Push(coureurT);
                if (rejet.Count>0)
                    garde = TriRecursif(rejet, garde, nb);
            } while (garde.Count<(nb-1));
            return garde;
        }

        /// <summary>
        /// Supprime l'objet mis en paramètre
        /// </summary>
        /// <param name="objet">L'objet que l'on veut Supprimer</param>
        public void Supprimer(Coureur objet)
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            if (_stack.Contains(objet))
            {
                Stack<Coureur> res = new Stack<Coureur>();
                foreach (Coureur entry in _stack)
                    if (!entry.Equals(objet))
                        res.Push(entry);
                    else
                        Console.WriteLine("L'objet {0} a été supprimé.\n", entry.ToString()); 
                _stack = res;
            }
            Console.WriteLine("x-x La collection ne contient pas cet objet {0}.\n", objet.ToString());
        }

        /// <summary>
        /// Supprime entièrement le stack
        /// </summary>
        public void SupprimerStack()
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            _stack.Clear();
        }

        /// <summary>
        /// Permet de savoir si l'objet est dans la collection
        /// </summary>
        /// <param name="objet"></param>
        public void Rechercher(Coureur objet)
        {
            Console.WriteLine("\n------ Recherche ------ \n");
            if (_stack.Contains(objet))
            {
                for (int i = 0; i < _stack.Count; i++)
                    if (_stack.ElementAt(i).Equals(objet))
                        Console.WriteLine("n°{0} : {1}\n", i, _stack.ElementAt(i));
            }
            else
                Console.WriteLine("\n {0} n'est pas dans la queue.\n", objet.ToString());
        }
    }
}
