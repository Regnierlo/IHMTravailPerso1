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
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="res"></param>
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

   
        /// <summary>
        /// Permet d'afficher les objets de la queue en fonction de leur place dans celle-ci.
        /// </summary>
        public void afficherQueue()
        {
            int res = 1;
            if (_queue.Count != 0)
            {
                foreach (Coureur entry in _queue)
                {
                    if (res == 1)
                        Console.WriteLine("---- Premier (1) de la queue : " + entry.ToString()+"\n");
                    else
                        if (res == _queue.Count)
                            Console.WriteLine("---- Dernier (" + res + ") de la queue : " + entry.ToString()+"\n");
                        else
                            Console.WriteLine("---- " + res + " : " + entry.ToString()+"\n");
                    res++;
                }
            }
            else
                Console.WriteLine("---- La queue est vide.\n");
        }

        /// <summary>
        /// Permet d'ajouter un objet dans une queue.
        /// </summary>
        /// <param name="objet">L'objet que l'on souhaite ajouter</param>
        public void ajouter(Coureur objet)
        {
            _queue.Enqueue(objet);
            Console.WriteLine(objet.ToString() + " a été ajouté.\n");
        }

        /// <summary>
        /// Permet d'insérer un objet dans une queue à l'emplacement voulu.
        /// </summary>
        /// <param name="objet">L'objet que l'on souhaite ajouter dans la queue</param>
        /// <param name="numero">L'emplacement dans la queue où l'on souhaite ajouter l'objet</param>
        /// <returns>la queue avec l'objet inséré</returns>
        public void inserer(Coureur objet, int numero)
        {
            Queue<Coureur> res = new Queue<Coureur>();
            int i = 1;
            foreach (Coureur entry in _queue)
            {
                if (i == numero)
                {
                    res.Enqueue(objet);
                    i++;
                }
                res.Enqueue(entry);
                i++;
            }

            if (numero > _queue.Count)
            {
                Console.WriteLine("Le numéro indiqué est supérieur au nombre d'éléments présents dans la collection. L'objet sera ajouté à la fin de la queue\n.");
                res.Enqueue(objet);
            }

            _queue = res;
        }

        /// <summary>
        /// Permet de trier la queue dans l'ordre alphabétique
        /// </summary>
        public void trierQueue()
        {
            Queue<Coureur> res = new Queue<Coureur>();
            _queue = triRecursif(_queue, res, _queue.Count);
        }

        /// <summary>
        /// Fonction récursive qui permet de trier la queue
        /// </summary>
        /// <param name="rejet"></param>
        /// <param name="garde"></param>
        /// <param name="nb"></param>
        /// <returns></returns>
        public Queue<Coureur> triRecursif(Queue<Coureur> rejet, Queue<Coureur> garde, int nb)
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
                    garde = triRecursif(rejet, garde, nb);

            } while (garde.Count < (nb - 1));
            return garde;
        }

        /// <summary>
        /// Récupérer un objet en fonction de son emplacement dans la queue
        /// </summary>
        /// <param name="qs">La queue que l'on souhaite regarder</param>
        /// <param name="numero">Le numéro correspondant à l'objet que l'on souhaiterait récupérer</param>
        /// <returns>L'objet (ici un string) que l'on souhaitaitrécupérer.</returns>
        private Coureur recuperer(Queue<Coureur> qs, int numero)
        {
            int i = 1;
            Coureur res = new Coureur();
            if (numero > qs.Count)
                Console.WriteLine("Pas d'objet à cet emplacement.");
            else
                foreach (Coureur entry in qs)
                {
                    if (i == numero)
                        res = entry;
                    i++;
                }
            return res;
        }

        /// <summary>
        /// Permet de supprimer un des objets en fonction de lui-même (ici son nom)
        /// </summary>
        /// <param name="objet">L'objet que l'on souhaiterait supprimer</param>
        ///
        public void supprimerS(Coureur objet)
        {
            if (_queue.Contains(objet))
            {   
                Queue<Coureur> res = new Queue<Coureur>();
                foreach (Coureur entry in _queue)
                    if (!entry.Equals(objet))
                        res.Enqueue(entry);
                _queue = res;
            }
        }

        /// <summary>
        /// Permet de supprimer un des objets en fonction de son emplacement dans la queue
        /// </summary>
        /// <param name="numero">L'emplacement correspondant à l'objet que l'on souhaiterait supprimer</param>
        public void supprimerI(int numero)
        {
            int temp = 1;
            Queue<Coureur> res = new Queue<Coureur>();
            foreach (Coureur entry in _queue)
            {
                if (temp != numero)
                    res.Enqueue(entry);
                temp++;
            }
            _queue = res;
        }

        /// <summary>
        /// Permet de supprimer la queue entièrement
        /// </summary>
         public void supprimerQueue()
        {
            _queue.Clear();
        }

        /// <summary>
        /// Permet de rechercher un objet en fonction de sa valeur
        /// </summary>
        /// <param name="objet">L'objet que l'on aimerait retrouver</param>
        public void rechercher(Coureur objet)
        {
            if (_queue.Contains(objet))
            {
                for (int i = 0; i < _queue.Count; i++)
                    if (_queue.ElementAt(i).Equals(objet))
                        Console.WriteLine("n°" + i + " : " + objet.ToString() + "\n");
            }
            else
                Console.WriteLine("\n" + objet + " n'est pas dans la queue.\n");
        }

    }
}
