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
        // Représente une collection de paires clé/valeur 
        // triées par les clés et accessible par clé et par index.

        public NonGenerique_SortedList()
        {
            _sortedList = new SortedList();
            // La capacité initiale par défaut
            // Triée suivant le IComparable
        }

        
        /// <summary>
        /// Accesseurs
        /// </summary>
        public SortedList SortedList
        {
            get { return _sortedList; }
            set { _sortedList = value; }
        }

        /// <summary>
        /// Affiche la collection entièrement.
        /// </summary>
        public void afficher()
        {
            if (_sortedList.Count != 0)
            {
                Console.WriteLine("\n      ---- Valeur / Clé ---- \n");

                for (int i = 0; i < _sortedList.Count; i++)
                    Console.WriteLine("n° " + (i + 1) + " : " + _sortedList.GetByIndex(i).ToString() + " / " + _sortedList.GetKey(i).ToString() + "\n");
            }
            else
                Console.WriteLine("La collection est vide.\n");
        }

        public void ajouter(Object key, Object value)
        {
            _sortedList.Add(key, value);
        }

        public int recupererIndexKey(Object key)
        {
            return _sortedList.IndexOfKey(key);
        }

        public int recupererIndexValue(Object value)
        {
            return _sortedList.IndexOfValue(value);
        }

        /// <summary>
        /// Suppression de l'objet en fonction de sa clé.
        /// </summary>
        /// <param name="key"></param>
        public void supprimerKey(Object key)
        {
            if (_sortedList.Contains(key))
            {
                _sortedList.Remove(key);
                Console.WriteLine("Le couple ayant la clé " + key + " a été supprimé.\n");
            }
            else
                Console.WriteLine("La collection ne contient pas cette clé.\n");
        }

        /// <summary>
        /// Suppression d'une entrée de la collection en fonction de son index
        /// </summary>
        /// <param name="i"></param>
        public void supprimerIndex(Int32 i)
        {
            if (i > _sortedList.Capacity)
                Console.WriteLine("Il n'y a rien à cet emplacement de la collection.\n");
            else
            {
                Console.WriteLine("Le couple " + _sortedList.GetByIndex(i) + " (" + _sortedList.GetKey(i) + ") a été enlevé.\n");
                _sortedList.RemoveAt(i);
                
            }
        }

        /// <summary>
        /// Suppression de la collection complète
        /// </summary>
        public void supprimerCollection()
        {
            _sortedList.Clear();
        }

        /// <summary>
        /// Recherche dans la collection en fonction de la clé du couple clé/valeur
        /// </summary>
        /// <param name="key"></param>
        public void rechercherKey(Object key)
        {
            if (_sortedList.ContainsKey(key))
                Console.WriteLine("La collection contient la clé : " + key.ToString() + "\n");
            else
                Console.WriteLine("La collection ne contient pas la clé demandée.\n");
        }
        /// <summary>
        /// Recherche dans la collection en fonction de l'objet en lui-même
        /// </summary>
        /// <param name="couple"></param>
        public void rechercher(Object objet)
        {
            if (_sortedList.Contains(objet))
            {
                for(int i=0 ; i < _sortedList.Count ; i++)
                    if(_sortedList.GetByIndex(i).Equals(objet))
                        Console.WriteLine("n°" + (i+1) + " : " +objet.ToString()+" est une valeur.\n");
                    else
                        if(_sortedList.GetKey(i).Equals(objet))
                            Console.WriteLine("n°" + (i+1) + " : " +objet.ToString()+" est une clé.\n");
            }
            else
                Console.WriteLine("La collection ne contient pas l'objet demandé.\n");
        }

        /// <summary>
        /// Recherche dans la collection en fonction de la valeur du couple.
        /// </summary>
        /// <param name="value"></param>
        public void rechercherValue(Object value)
        {
            if (!_sortedList.ContainsValue(value))
                Console.WriteLine("La collection ne contient pas la valeur " + value + ".\n");
            else
            {
                Console.WriteLine("La collection contient la valeur "+value+".\n");
                for (int i = 0; i < _sortedList.Count; i++)
                    if (_sortedList.GetByIndex(i).Equals(value))
                        Console.WriteLine(i + " : " + value + " / "+_sortedList.GetKey(i)+"\n");
            }


        }


    }
}
