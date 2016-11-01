using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Partie3
{
    class NonGenerique_SortedList
    {
        private SortedList _sortedList;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public NonGenerique_SortedList()
        {
            _sortedList = new SortedList();
            // Collection triée suivant le IComparable
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="res">La collection qu'on copiera pour construire notre instance</param>
        public NonGenerique_SortedList(SortedList res)
        {
            this._sortedList = res;
        }
        
        /// <summary>
        /// Accesseurs
        /// </summary>
        public SortedList SortedList
        {
            get { return _sortedList; }
            set { _sortedList = value; }
        }

        // ----------------------------------------------- METHODES

        /// <summary>
        /// Affiche la collection entièrement.
        /// </summary>
        public void afficher()
        {
            Console.WriteLine("\n----- Affichage de la collection -----\n");
            if (_sortedList.Count > 0)
                foreach(DictionaryEntry entry in _sortedList)
                    Console.WriteLine("    clé : {0} / valeur : {1}\n", entry.Key, entry.Value);
            else
                Console.WriteLine("x-x La collection est vide.\n");
        }
        
        /// <summary>
        /// Ajout d'un objet dans la collection
        /// </summary>
        /// <param name="key">La clé du couple clé/valeur que l'on veut Ajouter</param>
        /// <param name="value">La valeur  du couple clé/valeur que l'on veut Ajouter</param>
        public void ajouter(Object key, Object value)
        {
            Console.WriteLine("\n------ Ajout ------ \n");
            try
            {
                _sortedList.Add(key, value);
                Console.WriteLine("{0} / {1} a été ajouté.\n", key, value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("x-x La clé a déjà été donnée.\n");
            }
        }

        /// <summary>
        /// Permet de récupérer l'index d'un objet dont la clé a été mise en paramètre
        /// </summary>
        /// <param name="key">La clé de l'objet pour lequel on aimerait connaître l'index</param>
        /// <returns>L'index de l'objet</returns>
        public int recupererIndexKey(Object key)
        {
            return _sortedList.IndexOfKey(key);
        }

        /// <summary>
        /// Suppression de l'objet en fonction de sa clé.
        /// </summary>
        /// <param name="key">La clé du couple clé/valeur qu'on aimerait Supprimer</param>
        public void supprimerKey(Object key)
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            if (_sortedList.Contains(key))
            {
                _sortedList.Remove(key);
                Console.WriteLine("Le couple comprenant la clé {0} a été supprimé.\n",key);
            }
            else
                Console.WriteLine("x-x La collection ne contient pas cette clé.\n");
        }

        /// <summary>
        /// Suppression d'une entrée de la collection en fonction de son index
        /// </summary>
        /// <param name="i">Index de l'objet qu'on aimerait Supprimer</param>
        public void supprimerIndex(int i)
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            if (i > _sortedList.Count)
                Console.WriteLine("x-x Il n'y a rien à cet emplacement de la collection.\n");
            else
            {
                Console.WriteLine("Le couple {0} / {1} a été supprimé.\n", _sortedList.GetByIndex(i), _sortedList.GetKey(i));
                _sortedList.RemoveAt(i);
            }
        }

        /// <summary>
        /// Suppression de la collection complète
        /// </summary>
        public void supprimerCollection()
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            _sortedList.Clear();
        }

        /// <summary>
        /// Recherche dans la collection en fonction de la clé du couple clé/valeur
        /// </summary>
        /// <param name="key">La clé du couple clé/valeur que l'on aimerait retrouver</param>
        public void rechercherKey(Object key)
        {
            Console.WriteLine("\n------ Recherche ------ \n"); 
            if (_sortedList.ContainsKey(key))
                Console.WriteLine("La collection contient la clé {0}.\n", key);
            else
                Console.WriteLine("x-x La collection ne contient pas la clé {0}.\n", key);
        }

        /// <summary>
        /// Recherche dans la collection en fonction de l'objet en lui-même
        /// </summary>
        /// <param name="couple">Le couple clé/valeur que l'on aimerait retrouver</param>
        public void rechercher(Object objet)
        {
            Console.WriteLine("\n------ Recherche ------ \n"); 
            if (_sortedList.Contains(objet))
            {
                int i = 1;
                foreach (DictionaryEntry entry in _sortedList)
                {
                    if (objet != null && entry.Value != null && (entry.Value.Equals(objet) || entry.Key.Equals(objet)))
                        Console.WriteLine("n° {0} = clé : {1} / valeur : {2}.\n", i, entry.Key, entry.Value);
                    else
                        if (objet == null && entry.Value == null)
                            Console.WriteLine("n° {0} : contient la valeur null, ayant comme clé {1}.\n", i, entry.Key);
                    i++;
                }    
            }
            else
                Console.WriteLine("La collection ne contient pas l'objet demandé.\n");
        }

        /// <summary>
        /// Recherche dans la collection en fonction de la valeur du couple clé/valeur
        /// </summary>
        /// <param name="value">La valeur du couple clé/valeur que l'ont aimerait retrouver</param>
        public void rechercherValue(Object value)
        {
            Console.WriteLine("\n------ Recherche ------ \n"); 
            if (!_sortedList.ContainsValue(value))
                Console.WriteLine("La collection ne contient pas la valeur {0}.\n", value);
            else
            {
                int i = 1 ;
                foreach (DictionaryEntry entry in _sortedList)
                {
                    if (entry.Value != null)
                    {
                        if(entry.Value.Equals(value))
                            Console.WriteLine("n° {0} : contient la valeur {1}, ayant comme clé {2}.\n", i, entry.Value, entry.Key);
                    }
                    else
                        if(value == null)
                            Console.WriteLine("n° {0} : contient la valeur null, ayant comme clé {1}.\n", i, entry.Key);
                    i++;
                }
            }

        }
    }
}
