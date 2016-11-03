using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie3
{
    
    class Generique_Dictionnaire
    {
        
        private Dictionary<Int32, Coureur> _dictionary;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Generique_Dictionnaire()
        {
            this._dictionary = new Dictionary<Int32, Coureur>();
        }

        /// <summary>
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="res">La collection qu'on copiera pour construire notre instance</param>
        public Generique_Dictionnaire(Dictionary<Int32, Coureur> res){
            this._dictionary = res;
        }

        /// <summary>
        /// Accesseurs
        /// </summary>
        public Dictionary<Int32, Coureur> Dictionary
        {
            get { return _dictionary; }
            set { _dictionary = value; }
        }

        // ----------------------------------------------- METHODES

        /// <summary>
        /// Permet d'Afficher la collection en entière
        /// </summary>
        public void Afficher()
        {
            Console.WriteLine("\n----- Affichage de la collection -----\n");
            if (_dictionary.Count > 0)
                foreach (KeyValuePair<Int32, Coureur> entry in _dictionary)
                    Console.WriteLine("{0} : {1}\n", entry.Value, entry.Key);
            else
                Console.WriteLine("x-x La collection est vide.\n");
        }
        
        /// <summary>
        /// Permet d'Ajouter un couple clé/valeur dans la collection
        /// </summary>
        /// <param name="nom">La chaîne de caractère correspondant à la valeur dans le couple clé/valeur</param>
        /// <param name="numero">Le int correspondant à la clé dans le couple clé/valeur</param>
        public void Ajouter(Int32 key, Coureur value)
        {
            Console.WriteLine("\n------ Ajout ------ \n");
            try
            {
                _dictionary.Add(key, value);
                Console.WriteLine("Le couple {0} / {1} a bien été ajouté.\n", key, value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("x-x Le numéro a déjà été donné.\n");
            }
        }

        /// <summary>
        /// Permet d'insérer un objet dans une queue à l'emplacement voulu.
        /// </summary>
        /// <param name="key">La clé du couple clé/valeur que l'on veut insérer</param>
        /// <param name="value">La valeur du couple clé/valeur que l'on veut insérer</param>
        /// <param name="index">L'endroit de la collection où l'on veut insérer notre objet</param>
        public void Inserer(Int32 key, Coureur value, int index)
        {
            Console.WriteLine("\n------ Insertion ------ \n");
            Dictionary<Int32, Coureur> res = new Dictionary<Int32, Coureur>();
            if (index > _dictionary.Count)
            {
                res = _dictionary;
                res.Add(key, value);
                Console.WriteLine("{0} / {1} a été ajouté à la fin de la collection.\n", key, value);
            }
            else
            {
                int i = 1;
                foreach (KeyValuePair<Int32, Coureur> entry in _dictionary)
                {
                    if (i == index)
                    {
                        Console.WriteLine("{0} / {1} a été ajouté à l'index {1}.\n", key, value, i);
                        res.Add(key, value);
                        i++;
                    }
                    res.Add(entry.Key, entry.Value);
                    i++;
                }
            }
            _dictionary = res;
        }

        /// <summary>
        /// Permet de Supprimer un couple clé/valeur en fonction de la clé
        /// </summary>
        /// <param name="numero">Le int correspondant à la clé du couple clé/valeur que l'on souhaite enlever de la collection</param>
        public void Supprimer(Int32 key)
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            if (_dictionary.ContainsKey(key))
            /// On vérifie dans un premier temps si la collection contient la clé.
            {
                _dictionary.Remove(key);
                Console.WriteLine("Le couple ayant la clé {0} a été supprimé.\n",key);
            }
            else
                Console.WriteLine("x-x La collection ne comporte aucun couple ayant comme clé {0}.\n", key);
        }

        /// <summary>
        /// Permet de Supprimer la collection entière.
        /// </summary>
        public void SupprimerDictionary()
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            _dictionary.Clear();
        }
        
        /// <summary>
        /// Permet de RechercherKey dans une collection un couple clé/valeur en fonction de la clé
        /// </summary>
        /// <param name="numero">Le paramètre correspondant à la clé que l'on souhaite retrouver.</param>
        public void RechercherKey(int key)
        {
            Console.WriteLine("\n------ Recherche ------ \n");  
            Coureur value = new Coureur();
            if (_dictionary.TryGetValue(key, out value))
            {
                Console.WriteLine("Le coureur correspondant au maillot {0} est {1}.\n", key, value);
            }
            else
                Console.WriteLine("x-x Il n'y a aucune clé correspondante à {0}.\n",key);
        }

        /// <summary>
        /// Recherche d'un couple clé/valeur grâce à la valeur
        /// </summary>
        /// <param name="value">La valeur des couples clé/valeur que l'on veut récupérer</param>
        public void RechercherValue(Coureur value)
        {
            Console.WriteLine("\n------ Recherche ------ \n");
            if (_dictionary.ContainsValue(value))
            {
                int i = 1 ;
                foreach(KeyValuePair<int, Coureur> entry in _dictionary)
                {
                    if (entry.Value.Equals(value))
                        Console.WriteLine("n°{0} : {1}\n", i, entry.ToString());
                    i++;
                }
            }
            else
                Console.WriteLine("x-x Il n'y a aucune valeur correspondante à {0}.\n", value);
        }

        /// <summary>
        /// Trier une collection dans l'ordre croissant des clés
        /// </summary>
        public void TriKey()
        {
            Dictionary<Int32, Coureur> res = new Dictionary<Int32, Coureur>();
            Coureur valeurRes = new Coureur();
            int min = Int32.MaxValue;
            int max = Int32.MinValue;

            for (int i = 0; i < _dictionary.Count; i++)
            {
                foreach (KeyValuePair<Int32, Coureur> entry in _dictionary)
                {
                    if (entry.Key < min && entry.Key > max){
                        min = entry.Key;
                        valeurRes = entry.Value;
                    }
                }
                res.Add(min, valeurRes);
                max = min;
                min = Int32.MaxValue;
            }
            _dictionary = res;
        }


    }
}
