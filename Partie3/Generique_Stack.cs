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
        // LIFO : dernier entré premier sorti -> pile d'assiette

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
        /// <param name="res"></param>
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
        /// Permet d'afficher le stack entier
        /// </summary>
       public void afficherStack()
        {
            int res = 1;
            if (_stack.Count != 0)
            {
                foreach (Coureur entry in _stack)
                {
                    Console.WriteLine("---- " + res + " : " + entry.ToString() + "\n");
                    res++;
                }
            }
            else
                Console.WriteLine("---- Le stack est vide.\n");
        }

        /// <summary>
        /// Permet d'ajouter un objet au stack
        /// </summary>
        /// <param name="objet">L'objet qu'on veut ajouter</param>
        public void ajouter(Coureur objet)
        {
            _stack.Push(objet);
            Console.WriteLine(objet.ToString() + " a été ajouté.\n");
        }

        /// <summary>
        /// Permet d'insérer un objet à l'emplacement voulu
        /// </summary>
        /// <param name="objet">L'objet à insérer</param>
        /// <param name="numero">L'emplacementoù on veut insérer l'objet</param>
        public void inserer(Coureur objet, int numero)
        {
            Stack<Coureur> res = new Stack<Coureur>();
            int i = 1;
            foreach (Coureur entry in _stack)
            {
                if (i == numero)
                {
                    res.Push(objet);
                    i++;
                }
                res.Push(entry);
                i++;
            }
            if(numero > _stack.Count)
            {
                res.Push(objet);
            }
            _stack = res;
        }

        /// <summary>
        /// Permet d'appeler la fonction récursive qui va elle, trier le stack
        /// </summary>
        public void trierStack()
        {
            Stack<Coureur> res  = new Stack<Coureur>();
            _stack = trierRecursif(_stack,res,_stack.Count);
        }
 
        /// <summary>
        /// Permet de trier la pile de façon récursif
        /// </summary>
        /// <param name="rejet">Le stack des objets non triés</param>
        /// <param name="garde">Le stack déjà trié</param>
        /// <param name="nb">La taille du stack contenant tous les objets</param>
        /// <returns>Le stack trié</returns>
        public Stack<Coureur> trierRecursif(Stack<Coureur> rejet, Stack<Coureur> garde, int nb){
            
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
                    garde = trierRecursif(rejet, garde, nb);
            
            } while (garde.Count<(nb-1));

            return garde;
        }

        /// <summary>
        /// Supprime l'objet mis en paramètre
        /// </summary>
        /// <param name="objet">L'objet que l'on veut supprimer</param>
        public void supprimerC(Coureur objet){
            if (_stack.Contains(objet))
            {
                Stack<Coureur> res = new Stack<Coureur>();
                foreach (Coureur entry in _stack)
                {
                    if (!entry.Equals(objet))
                        res.Push(entry);
                }
                _stack = res;
            }
        }

        /// <summary>
        /// Supprime entièrement le stack
        /// </summary>
        public void supprimerStack()
        {
            _stack.Clear();
        }

        /// <summary>
        /// Permet de savoir si l'objet est dans la collection
        /// </summary>
        /// <param name="objet"></param>
        public void rechercher(Coureur objet)
        {
            if (_stack.Contains(objet))
            {
                Console.WriteLine("\n"+objet + " est bien dans le stack.\n");
            }
            else
                Console.WriteLine("\n"+objet + " n'est pas dans le stack.\n");
        }
    }
}
