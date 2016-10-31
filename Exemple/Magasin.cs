using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    public class Magasin : IEquatable<Magasin>, IComparable<Magasin>
    {
        private int _idMag;
        private string _nom;
        private int _tel;
        private string _ville;
        private List<Produit> _listeProd;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int Numero
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public List<Produit> ListeProd
        {
            get { return _listeProd; }
        }

        public int IdMag { get { return _idMag; } }

        /// <summary>
        /// Constructeur par défaut. Identifiant du magasin "Inconnu". Le reste à : ""
        /// </summary>
        public Magasin(){
            this._idMag=000;
            this._nom = "";
            this._tel = 0;
            this._ville = "";
            _listeProd = new List<Produit>();
        }

        /// <summary>
        /// Constructeur par paramètre 1. Permet d'instancier un objet Magasin avec tous son contenu
        /// </summary>
        /// <param name="idMag">Identifiant du magasin</param>
        /// <param name="nom">Nom du magasin</param>
        /// <param name="tel">Numéro de téléphone du magasin</param>
        /// <param name="ville">Ville où se situe le magasin</param>
        /// <param name="listProduit">Liste de tous les produits</param>
        public Magasin(int idMag, string nom, int tel, string ville, List<Produit> listProduit)
        {
            this._idMag = idMag;
            this._nom = nom;
            this._tel = tel;
            this._ville = ville;
            _listeProd = listProduit;
        }

        /// <summary>
        /// Constructeur par paramètre 2. Permet d'instancier un objet Magasin sans la liste
        /// </summary>
        /// <param name="idMag">Identifiant du magasin</param>
        /// <param name="nom">Nom du magasin</param>
        /// <param name="tel">Numéro de téléphone du magasin</param>
        /// <param name="ville">Ville où se situe le magasin</param>
        public Magasin(int idMag, string nom, int tel, string ville)
        {
            this._idMag = idMag;
            this._nom = nom;
            this._tel = tel;
            this._ville = ville;
            _listeProd = new List<Produit>();
        }

        /// <summary>
        /// Convertit en chaine de caractère les informations de l'objet
        /// </summary>
        /// <returns>Une chaine de caractère</returns>
        public override string ToString()
        {
            string s = "";

            s += "Identifiant : " + _idMag;
            s += "\nNom : "+_nom;
            s += "\nNuméro de téléphone : 0"+_tel;
            s += "\nVille : " + _ville;

            return s;
        }

        /// <summary>
        /// Surcharge de la méthode Equals de la classe Object
        /// </summary>
        /// <param name="obj">Objet qui va être comparé à l'objet courant</param>
        /// <returns>Retourne un booléen : vrai si ce sont les mêmes, faux sinon</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Magasin mag = obj as Magasin;
            if (mag == null)
                return false;
            else
                return Equals(mag);
        }

        /// <summary>
        /// Implémentation de la méthode de l'interface IEquatable<Produit>
        /// </summary>
        /// <param name="other">Produit qui va être comparé grâce au code à un autre objet</param>
        /// <returns>Retourne un booléen, indiquant si le magasin mis en paramètre est égal au code</returns>
        public bool Equals(Magasin other)
        {
            if (other == null)
                return false;
            return (this.IdMag.Equals(other.IdMag)); // comparaison sur des entiers (ici l'id du magasin)
        }

        /// <summary>
        /// Retourne le code sous forme de String
        /// </summary>
        /// <returns>Retourne un entier</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        /// <summary>
        /// Surchage de l'opérateur ==
        /// </summary>
        /// <param name="m1">Premier magasin à comparer</param>
        /// <param name="m2">Second magasin à comparer</param>
        /// <returns>Retourne un booléen, indiquant si les deux magasins mis en paramètre sont égaux ou non</returns>
        public static bool operator==(Magasin m1, Magasin m2)
        {
            if ((Object)m1 == null)
                return ((Object)m2 == null);
            return m1.Equals(m2);
        }

        /// <summary>
        /// Surchage de l'opérateur !=
        /// </summary>
        /// <param name="m1">Premier produit à comparer</param>
        /// <param name="m2">Second produit à compaer</param>
        /// <returns>Retourne un booléan, indiquant si les deux produits sont différents ou non</returns>
        public static bool operator!=(Magasin m1, Magasin m2)
        {
            if ((Object)m1 == null)
                return ((Object)m2 == null);
            return !m1.Equals(m2);
        }

        /// <summary>
        /// Retourne la liste des produits du magasin sous forme le chaine de caractere
        /// </summary>
        /// <returns>Une chaine de caractère</returns>
        public string ListeProduits()
        {
            string s = "";

            foreach (Produit pr in _listeProd)
            {
                s += pr.ToString();
                s += "\n\n";
            }

            return s;
        }

        /// <summary>
        /// Ajoute un produit au magasin.
        /// </summary>
        /// <param name="p">Produit à ajouter</param>
        public void AddProduit(Produit p)
        {
            if (!verifProduit(p))
                _listeProd.Add(p);
            else
                Console.WriteLine("Le produit existe déjà.");
        }

        /// <summary>
        /// Vérifie la présence du produit dans le magasin
        /// </summary>
        /// <param name="p">Produit à vérifier</param>
        /// <returns>Un Boolean <value>true</value> si le produit est présent et à <value>false</value> s'il ne l'ai pas.</returns>
        private Boolean verifProduit(Produit p)
        {
            Boolean res = false;

            foreach (Produit pr in _listeProd)
            {
                if (pr.Code == p.Code)
                    res = true;
            }

            return res;
        }
        
        /// <summary>
        /// Compare l'identifiant de deux magasins et indique lequel à un identifiant plus petit
        /// </summary>
        /// <param name="other">Autre magasin qui sera comparé à l'objet/magasin courant</param>
        /// <returns>Un entier : -1 => la magasin courant à un identifiant plus petit. 0 => L'identifiant des magasins sont identique. 1 => L'identifiant du magasin "other" est plus grand</returns>
        public int CompareTo(Magasin other)
        {
            int res;

            if (this.IdMag < other.IdMag)
                res = -1;
            else if (this.IdMag > other.IdMag)
                res = 1;
            else // this.IdMag == other.IdMa
                res = 0;

            return res;
        }

        /// <summary>
        /// Compare le code de deux magasins grâce à la surcharge de l'opérateur : <
        /// </summary>
        /// <param name="m1">Magasin courant</param>
        /// <param name="m2">Magasin qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si m1 est inférieur à m2, <value>false</value> sinon.</returns>
        public static bool operator <(Magasin m1, Magasin m2)
        {
            bool res = false;

            if (m1.CompareTo(m2) < 0)
                res = true;

            return res;
        }

        /// <summary>
        /// Compare le code de deux magasins grâce à la surcharge de l'opérateur : >
        /// </summary>
        /// <param name="m1">Magasin courant</param>
        /// <param name="m2">Magasin qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si m1 est supérieur à m2, <value>false</value> sinon.</returns>
        public static bool operator >(Magasin m1, Magasin m2)
        {
            bool res = false;

            if (m1.CompareTo(m2) > 0)
                res = true;

            return res;
        }

        /// <summary>
        /// Compare le code de deux magasins grâce à la surcharge de l'opérateur : >=
        /// </summary>
        /// <param name="m1">Magasin courant</param>
        /// <param name="m2">Magasin qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si m1 est supérieur ou égale à m2, <value>false</value> sinon.</returns>
        public static bool operator >=(Magasin m1, Magasin m2)
        {
            bool res = false;

            if (m1.CompareTo(m2) > 0 || m1.CompareTo(m2) == 0)
                res = true;

            return res;
        }

        /// <summary>
        /// Compare le code de deux magasins grâce à la surcharge de l'opérateur : <=
        /// </summary>
        /// <param name="m1">Magasin courant</param>
        /// <param name="m2">Magasin qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si m1 est inférieur ou égale à m2, <value>false</value> sinon.</returns>
        public static bool operator <=(Magasin m1, Magasin m2)
        {
            bool res = false;

            if (m1.CompareTo(m2) < 0 || m1.CompareTo(m2) == 0)
                res = true;

            return res;
        }

        public List<Produit> triProduits(){
            List<Produit> listeTriee = new List<Produit>();
            int min=Int32.MaxValue;
            int max =Int32.MinValue;
            for (int i = 0; i < _listeProd.Count; i++)
            {
                foreach (Produit l in _listeProd)
                {
                    if (l.Code < min && l.Code>max)
                        min = l.Code;
                }
                listeTriee.Add(_listeProd.Find(x => x.Code == min));
                max = min;
                min = Int32.MaxValue;
            }    
            return listeTriee;
        }
    }
}
