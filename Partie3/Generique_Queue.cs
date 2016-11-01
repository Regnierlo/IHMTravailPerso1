using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie3
{
    class Generique_Queue
    {
        private Queue<Coureur> _queue;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Generique_Queue(){
            this._queue = new Queue<Coureur>();
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="res">La collection qu'on copiera pour construire notre instance</param>
        public Generique_Queue(Queue<Coureur> res){
            this._queue = res;
        }

        /// <summary>
        /// Accesseurs
        /// </summary>
        public Queue<Coureur> Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        // ----------------------------------------------- METHODES

        /// <summary>
        /// Affichage de la collection
        /// </summary>
        public void Afficher()
        {
            Console.WriteLine("\n----- Affichage de la collection -----\n");
            int i = 1;
            if (_queue.Count > 0)
                foreach (Coureur entry in _queue)
                {
                    Console.WriteLine("     {0} : {1}\n", i, entry.ToString());
                    i++;
                }
            else
                Console.WriteLine("x-x La queue est vide.\n");
        }

        /// <summary>
        /// Ajout d'un objet dans la collection
        /// </summary>
        /// <param name="objet">L'objet que l'on souhaite Ajouter</param>
        public void Ajouter(Coureur objet)
        {
            Console.WriteLine("\n------ Ajout ------ \n");
            _queue.Enqueue(objet);
            Console.WriteLine("{0} a été ajouté.\n", objet.ToString());
        }

        /// <summary>
        /// Permet d'insérer un objet dans une queue à l'emplacement voulu.
        /// </summary>
        /// <param name="objet">L'objet que l'on souhaite Ajouter dans la queue</param>
        /// <param name="numero">L'emplacement dans la queue où l'on souhaite Ajouter l'objet</param>
        /// <returns>la queue avec l'objet inséré</returns>
        public void Inserer(Coureur objet, int index)
        {
            Console.WriteLine("\n------ Insertion ------ \n");
            Queue<Coureur> res = new Queue<Coureur>();
            if (index > _queue.Count) 
            {
                res = _queue;
                res.Enqueue(objet);
                Console.WriteLine("{0} a été ajouté à la fin de la collection.\n", objet.ToString());
            }
            else
            {
                int i = 1;
                foreach (Coureur entry in _queue)
                {
                    if (i == index)
                    {
                        Console.WriteLine("{0} a été ajouté à l'index {1}.\n", objet.ToString(), i);
                        res.Enqueue(objet);
                        i++;
                    }
                    res.Enqueue(entry);
                    i++;
                }
            }
            _queue = res;
        }

        /// <summary>
        /// Permet de trier la queue dans l'ordre alphabétique
        /// </summary>
        public void Tri()
        {
            Console.WriteLine("\n------ Tri ------ \n");
            Queue<Coureur> res = new Queue<Coureur>();
            _queue = TriRecursif(_queue, res, _queue.Count);
        }

        /// <summary>
        /// Fonction récursive qui permet de trier la queue
        /// </summary>
        /// <param name="rejet"></param>
        /// <param name="garde"></param>
        /// <param name="nb"></param>
        /// <returns></returns>
        public Queue<Coureur> TriRecursif(Queue<Coureur> rejet, Queue<Coureur> garde, int nb)
        {
            Coureur coureurT = rejet.Peek();
            rejet.Dequeue();
            Queue<Coureur> temp = new Queue<Coureur>(rejet);
            rejet.Clear();
            do
            {
                foreach (Coureur entry in temp)
                {
                    if (coureurT.CompareTo(entry) == 1)
                    {
                        rejet.Enqueue(coureurT);
                        coureurT = entry;
                    }
                    else if (coureurT.CompareTo(entry) == -1)
                        rejet.Enqueue(entry);
                }
                garde.Enqueue(coureurT);
                if (rejet.Count > 0)
                    garde = TriRecursif(rejet, garde, nb);

            } while ( garde.Count < (nb - 1) );
            return garde;
        }

        /// <summary>
        /// Permet de Supprimer un des objets en fonction de lui-même (ici son nom)
        /// </summary>
        /// <param name="objet">L'objet que l'on souhaiterait Supprimer</param>
        public void Supprimer(Coureur objet)
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            if (_queue.Contains(objet))
            {   
                Queue<Coureur> res = new Queue<Coureur>();
                foreach (Coureur entry in _queue)
                    if (!entry.Equals(objet))
                        res.Enqueue(entry);
                _queue = res;
                Console.WriteLine("L'objet {0} a été supprimé.\n", objet.ToString());
            }
            else
                Console.WriteLine("x-x La collection ne contient pas cet objet {0}.\n", objet.ToString());
        }

        /// <summary>
        /// Permet de Supprimer un des objets en fonction de son emplacement dans la queue
        /// </summary>
        /// <param name="numero">L'emplacement correspondant à l'objet que l'on souhaiterait Supprimer</param>
        public void SupprimerIndex(int index)
        {
            Console.WriteLine("\n------ Suppression par l'index ------ \n");
            if (index > _queue.Count)
                Console.WriteLine("Il n'y a rien à cet emplacement.\n");
            else
            {
                int temp = 1;
                Queue<Coureur> res = new Queue<Coureur>();
                foreach (Coureur entry in _queue)
                {
                    if (temp != index)
                        res.Enqueue(entry);
                    else
                        Console.WriteLine("L'objet {0} a été supprimé.\n", entry.ToString()); 
                    temp++;
                }
                _queue = res;
            }
        }

        /// <summary>
        /// Permet de Supprimer la queue entièrement
        /// </summary>
         public void SupprimerQueue()
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            _queue.Clear();
        }

        /// <summary>
        /// Permet de RechercherKey un objet en fonction de sa valeur
        /// </summary>
        /// <param name="objet">L'objet que l'on aimerait retrouver</param>
        public void Rechercher(Coureur objet)
        {
            Console.WriteLine("\n------ Recherche ------ \n");
            if (_queue.Contains(objet))
            {
                for (int i = 0; i < _queue.Count; i++)
                    if (_queue.ElementAt(i).Equals(objet))
                        Console.WriteLine("n°{0} : {1}\n", i, _queue.ElementAt(i));
            }
            else
                Console.WriteLine("\n {0} n'est pas dans la queue.\n", objet.ToString());
        }
    }
}
