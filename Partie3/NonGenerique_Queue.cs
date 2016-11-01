using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie3
{
    class NonGenerique_Queue
    {
        private Queue _queue;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public NonGenerique_Queue()
        {
            this._queue = new Queue();
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="res">La collection qu'on copiera pour construire notre instance</param>
        public NonGenerique_Queue(Queue res)
        {
            this._queue = res;
        }

        /// <summary>
        /// Accesseurs
        /// </summary>
        public Queue Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        // ----------------------------------------------- METHODES

        /// <summary>
        /// Affichage de la collection
        /// </summary>
        public void afficher()
        {
            Console.WriteLine("\n----- Affichage de la collection -----\n");
            if (_queue.Count > 0)
                foreach (Object entry in _queue)
                    Console.WriteLine("     {0}\n", entry.ToString());
            else
                Console.WriteLine("x-x La queue est vide.\n");
        }

        /// <summary>
        /// Ajout d'un objet dans la collection
        /// </summary>
        /// <param name="objet">Objet à ajouter</param>
        public void ajouter(Object objet)
        {
            Console.WriteLine("\n------ Ajout ------ \n");
            _queue.Enqueue(objet);
            Console.WriteLine("{0} a été ajouté.\n", objet.ToString());
        }

        /// <summary>
        /// Insertion d'un objet à l'index donné
        /// </summary>
        /// <param name="objet">Objet à ajouter</param>
        /// <param name="index">Index où l'on aimerait insérer notre objet</param>
        public void inserer(Object objet, int index)
        {
            Console.WriteLine("\n------ Ajout ------ \n");
            Queue res = new Queue(); /// Queue temporaire
            if (index > _queue.Count) /// SI l'index donné est trop important, on ajoute l'objet à la fin de la collection
            {
                res = _queue;
                res.Enqueue(objet);
                Console.WriteLine("{0} a été ajouté à la fin de la collection.\n", objet.ToString());
            }
            else
            {
                int i = 1; /// Compteur
                foreach (Object entry in _queue)
                {
                    if (i == index)
                    {
                        res.Enqueue(objet);
                        Console.WriteLine("{0} a été ajouté à l'index {1}.\n", objet.ToString(), i);
                        i++;
                    }
                    res.Enqueue(entry);
                    i++;
                }
            }
            _queue = res;
        }

        /// <summary>
        /// Suppression d'un objet
        /// </summary>
        /// <param name="objet">L'objet à supprimer</param>
        public void supprimer(Object objet)
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            if (_queue.Contains(objet))
            {
                Queue res = new Queue();
                foreach (Object entry in _queue)
                    if (!entry.Equals(objet))
                        res.Enqueue(entry);
                _queue = res;
                Console.WriteLine("L'objet {0} a été supprimé.\n", objet.ToString()); 
            }
            else
                Console.WriteLine("x-x La collection ne contient pas cet objet.\n");
        }

        /// <summary>
        /// Suppression de la collection entière
        /// </summary>
        public void supprimerQueue()
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            _queue.Clear();
        }

        public void rechercher(Object objet)
        {
            Console.WriteLine("\n------ Recherche ------ \n");
            int i = 1 ;
            if (_queue.Contains(objet))
                foreach (Object entry in _queue)
                {
                    if (entry.Equals(objet))
                        Console.WriteLine("n°" + i + " : " + entry.ToString());
                    i++;
                }
            else
                Console.WriteLine("x-x La collection ne contient pas l'objet {0}.\n", objet.ToString());
        }
    }
}
