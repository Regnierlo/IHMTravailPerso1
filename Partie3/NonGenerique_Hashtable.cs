using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Partie3
{
    class NonGenerique_Hashtable
    {
        private Hashtable _hashtable ;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public NonGenerique_Hashtable()
        {
            this._hashtable = new Hashtable();
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="res">La collection qu'on copiera pour construire notre instance</param>
        public NonGenerique_Hashtable(Hashtable res)
        {
            this._hashtable = res;
        }

        /// <summary>
        /// Accesseurs
        /// </summary>
        public Hashtable Hashtable
        {
            get { return _hashtable; }
            set { _hashtable = value; }
        }

        // ----------------------------------------------- METHODES

        /// <summary>
        /// Affichage de la collection
        /// </summary>
        public void afficher()
        {
            Console.WriteLine("\n----- Affichage de la collection -----\n");
            if (_hashtable.Count > 0)
                foreach (DictionaryEntry entry in _hashtable)
                    Console.WriteLine("    clé : {0} / valeur : {1}\n", entry.Key, entry.Value);
            else
                Console.WriteLine("x-x Hashtable est vide.\n");
        }

        /// <summary>
        /// Ajout d'un objet dans la collection
        /// </summary>
        /// <param name="key">La clé du couple clé/valeur que l'on veut ajouter</param>
        /// <param name="value">La valeur  du couple clé/valeur que l'on veut ajouter</param>
        public void ajouter(Object key, Object value)
        {
            Console.WriteLine("\n------ Ajout ------ \n");
            try
            {
                _hashtable.Add(key, value);
                Console.WriteLine("{0} / {1} a été ajouté.\n", key, value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("x-x La clé a déjà été donnée.\n");
            }
        }

        /// <summary>
        /// Suppression de la collection complète
        /// </summary>
        public void supprimerHashtable()
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            _hashtable.Clear();
        }

        /// <summary>
        /// Suppression de l'objet en fonction de sa clé
        /// </summary>
        /// <param name="key">La clé du couple clé/valeur qu'on aimerait supprimer</param>
        public void supprimerKey(Object key)
        {
            Console.WriteLine("\n------ Suppression ------ \n");
            if (_hashtable.ContainsKey(key))
            {
                _hashtable.Remove(key);
                Console.WriteLine("Le couple comprenant la clé {0} a été supprimé.\n", key);
            }
            else
                Console.WriteLine("x-x La collection ne contient pas cette clé.\n");
        }

        /// <summary>
        /// Recherche dans la collection en fonction de la clé du couple clé/valeur
        /// </summary>
        /// <param name="key">La clé du couple clé/valeur que l'on aimerait retrouver</param>
        public void rechercherKey(Object key)
        {
            Console.WriteLine("\n------ Recherche ------ \n");
            if (_hashtable.ContainsKey(key))
                Console.WriteLine("La collection contient la clé {0}.\n", key);
            else
                Console.WriteLine("x-x La collection ne contient pas la clé {0}.\n", key);
        }

        /// <summary>
        /// Recherche dans la collection en fonction de la valeur du couple clé/valeur
        /// </summary>
        /// <param name="value">La valeur du couple clé/valeur que l'ont aimerait retrouver</param>
        public void rechercherValue(Object value)
        {
            int i = 1 ;
            Console.WriteLine("\n------ Recherche ------ \n");
                
            if (_hashtable.ContainsValue(value))
            {
                foreach (DictionaryEntry entry in _hashtable)
                {
                    if (entry.Value != null)
                    {
                        if (entry.Value.Equals(value))
                            Console.WriteLine("n° {0} : contient la valeur {1}, ayant comme clé {2}.\n", i, entry.Value, entry.Key);
                    }
                    else
                        if(value == null)
                            Console.WriteLine("n° {0} : contient la valeur null, ayant comme clé {1}.\n", i, entry.Key);
                    i++;
                }
            }
            else
                Console.WriteLine("x-x La collection ne contient pas la valeur {0}.\n", value);
        }

    }
}
