using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    class LesMagasins
    {
        private List<Magasin> _lm;

        public List<Magasin> lm { get { return _lm; } }

        public LesMagasins()
        {
            _lm = new List<Magasin>();
        }

        /// <summary>
        /// Ajoute un magasin
        /// </summary>
        /// <param name="m">Magasin a ajouter</param>
        public void ajouterMagasins(Magasin m)
        {
            if (!verifierPresence(m))
                _lm.Add(m);
            else
                Console.WriteLine("\n\n\nMAGASIN DEJA PRESENT (VERIFICATION PAR L'ID) !");
        }

        /// <summary>
        /// Convertit en chaine de caractère les informations de l'objet
        /// </summary>
        /// <returns>Une chaine de caractère</returns>
        public override string ToString()
        {
            string res = "";
            res += "Liste des magasins : \n\n";

            foreach (Magasin m in _lm)
            {
                res += m.Nom;
                res += "\n";
            }

            return res;
        }

        /// <summary>
        /// Vérifie la présence du magasin par l'identifiant de celui-ci
        /// </summary>
        /// <param name="m">Magasin à vérifier</param>
        /// <returns>Un Boolean <value>true</value> si le magasin est présent et à <value>false</value> s'il ne l'ai pas.</returns>
        private Boolean verifierPresence(Magasin m)
        {
            Boolean res = false;

            foreach (Magasin mag in _lm)
            {
                if (mag.IdMag == m.IdMag)
                    res = true;
            }

            return res;
        }

        /// <summary>
        /// Retourne la taille de la liste
        /// </summary>
        /// <returns>Un entier</returns>
        public int Size()
        {
            return _lm.Count;
        }

        /// <summary>
        /// Récupère le magasin avec le numéro choisis
        /// </summary>
        /// <param name="num">Numéro du magasin choisie</param>
        /// <returns>Un Magasin</returns>
        public Magasin getMagasin(int num)
        {
            return _lm.ElementAt(num-1);
            // la liste commence à 0, donc pour avoir le premier magasin on doit prendre le 0
        }

        public Boolean verifId(int id)
        {
            Boolean res = false;

            foreach (Magasin l in _lm)
            {
                if (l.IdMag == id)
                    res = true;
            }

            return !res;
        }
    }
}
