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

        public NonGenerique_Hashtable()
        {
            this._hashtable = new Hashtable();
        }

        public NonGenerique_Hashtable(Hashtable res)
        {
            this._hashtable = res;
        }

        public Hashtable Hashtable
        {
            get { return _hashtable; }
            set { _hashtable = value; }
        }

        public void afficher()
        {
            int temp = 1 ;
            foreach (DictionaryEntry entry in _hashtable)
            {
                Console.WriteLine(temp + " - " + entry.Key + " / " + entry.Value+"\n");
                temp++;
            }
        }

        /// <summary>
        /// Ajout d'une paire clé/valeur dans la table de hachage
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="valeur"></param>
        public void ajouter(int cle, string valeur)
        {
            try
            {
                _hashtable.Add(cle, valeur);
                Console.WriteLine("--> " + cle + " : " + valeur + " a été ajouté(e).\n");
            }
            catch (ArgumentException)
            {
                // La clé qui doit être unique est déjà utilisée dans la collection
                Console.WriteLine("--x La clé a déjà été donnée.\n");
            }
        }

        public void inserer(int cle, string valeur, int nb)
        {
            Hashtable res = new Hashtable();
            int temp = 1;
            foreach (DictionaryEntry entry in _hashtable)
            {
                if(nb == temp)
                {
                    res.Add(cle,valeur);
                    temp++;
                }
                res.Add(entry.Key, entry.Value);
                temp++;
            }
            if (nb > _hashtable.Count)
            {
                res.Add(cle, valeur);
            }
            _hashtable = res;
        }

        public void trier()
        {

        }

        public void supprimer()
        {

        }

        public void rechercher()
        {
            Console.WriteLine(Hashtable.GetHashCode());
        }




    }
}
