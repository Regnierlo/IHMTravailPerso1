using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Partie3
{
    class Coureur : IComparable
    {
        // attributs
        private int _maillot;
        private string _nom;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Coureur(){
            this._maillot = -1;
            this._nom = "";
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="m">Le numéro de maillot du coureur</param>
        /// <param name="n">Le nom du coureur</param>
        public Coureur(int m, string n)
        {
            this._maillot = m;
            this._nom = n;
        }

        /// <summary>
        /// Clonage du coureur mis en paramètre
        /// </summary>
        /// <param name="objet">Le coureur que l'on veut copier</param>
        public void Copie(Coureur objet)
        {
            this._maillot = objet.Maillot;
            this._nom = objet.Nom;
        }

        /// <summary>
        /// Accesseurs de _maillot
        /// </summary>
        public int Maillot
        {
            get { return _maillot; }
            set { _maillot = value; }
        }

        /// <summary>
        /// Accesseurs de _nom
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Surcharge de la méthode ToString()
        /// </summary>
        /// <returns>La chaîne de caractères</returns>
        public override string ToString()
        {
            string s = "";
            s = _nom + " (" +_maillot + ")";
            return s;
        }

        /// <summary>
        /// Surcharge de l'opérateur <, on choisi de comparer les int correspondant aux maillots des coureurs
        /// </summary>
        /// <param name="c1">Le coureur 1 que l'on souhaite comparer</param>
        /// <param name="c2">Le coureur 2 que l'on souhaite comparer</param>
        /// <returns>Le booléen indiquant si oui ou non le numéro du maillot du coureur 1 est plus petit que celui du coureur 2</returns>
        public static bool operator <(Coureur c1, Coureur c2)
        {
            bool res = false;
            if (c1.Maillot < c2.Maillot)
                res = true;
            return res;
        }

        /// <summary>
        /// Surcharge de l'opérateur <=, on choisi de comparer les int correspondant aux maillots des coureurs
        /// </summary>
        /// <param name="c1">Le coureur 1 que l'on souhaite comparer</param>
        /// <param name="c2">Le coureur 2 que l'on souhaite comparer</param>
        /// <returns>Le booléen indiquant si oui ou non le numéro du maillot du coureur 1 est plus petit ou égal que celui du coureur 2</returns>
        public static bool operator <=(Coureur c1, Coureur c2)
        {
            bool res = false;
            if (c1.Maillot <= c2.Maillot)
                res = true;
            return res;
        }

        /// <summary>
        /// Surcharge de l'opérateur >, on choisi de comparer les int correspondant aux maillots des coureurs
        /// </summary>
        /// <param name="c1">Le coureur 1 que l'on souhaite comparer</param>
        /// <param name="c2">Le coureur 2 que l'on souhaite comparer</param>
        /// <returns>Le booléen indiquant si oui ou non le numéro du maillot du coureur 1 est plus grand que celui du coureur 2</returns>
        public static bool operator >(Coureur c1, Coureur c2)
        {
            bool res = false;
            if (c1.Maillot > c2.Maillot)
                res = true;
            return res;
        }

        /// <summary>
        /// Surcharge de l'opérateur >=, on choisi de comparer les int correspondant aux maillots des coureurs
        /// </summary>
        /// <param name="c1">Le coureur 1 que l'on souhaite comparer</param>
        /// <param name="c2">Le coureur 2 que l'on souhaite comparer</param>
        /// <returns>Le booléen indiquant si oui ou non le numéro du maillot du coureur 1 est plus grand ou égal que celui du coureur 2</returns>
        public static bool operator >=(Coureur c1, Coureur c2)
        {
            bool res = false;
            if (c1.Maillot >= c2.Maillot)
                res = true;
            return res;
        }

        /// <summary>
        /// Surcharge de la méthode CompareTo, obligatoire pour IComparable
        /// On choisit de faire la comparaison des noms des coureurs : ce sera suivant l'ordre alphabétique
        /// </summary>
        /// <param name="other">L'objet que l'on compare à l'instance de cette classe</param>
        /// <returns>Un int correspondant au résultat de la comparaison (-1 si instance plus petit, 0 si égaux, 1 sinon)</returns>
        public int CompareTo(Object other)
        {
            int res = -1;
            if (other == null)
                res = 1;
            else { 
                Coureur otherCoureur = other as Coureur;
                if (otherCoureur != null)
                    res = this.Nom.CompareTo(otherCoureur.Nom);
                else
                    throw new ArgumentException("Pas un coureur !");
            }
            return res;
        }
    }
}
