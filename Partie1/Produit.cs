using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    public enum CategorieProduit { Consommable, NonConsommable }

    public class Produit:IEquatable<Produit>, IComparable<Produit>
    {
        // attributs
        private int _code;
        private string _nom;
        private float _prix;
        private CategorieProduit _cat;
        private string _sousCat;

        // constructeur par défaut
        public Produit(){
            this._code = -1;
            this._nom = "Inconnu";
            this._prix = 0;
            this._cat = CategorieProduit.Consommable;
            this._sousCat = "";
        }

        // constructeur avec paramètres
        public Produit(int c, string n, float p, CategorieProduit ct, string sct)
        {
            this._code = c;
            this._nom = n;
            this._prix = p;
            this._cat = ct;
            this._sousCat = sct;
        }

        // accesseurs sous forme de propriétés
        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public float Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }
        public string SousCat
        {
            get { return _sousCat; }
            set { _sousCat = value; }
        }

        public CategorieProduit Cat
        {
            get { return _cat; }
            set { _cat = value; }
        }

        public string CatS
        {
            get  {return Enum.Format(typeof(CategorieProduit),_cat,"g");}
            set { _cat = (CategorieProduit)Enum.Parse(typeof(CategorieProduit),value,false);} 
        }

        public override string ToString()
        {
            string s = "";
            s += "\nCode : " + _code;
            s += "\nNom : " + _nom;
            s += "\nPrix : " + _prix +" eu.";
            s += "\nCatégorie : " + _cat;
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
            Produit prod = obj as Produit;
            if (prod == null)
                return false;
            else
                return Equals(prod);
        }

        /// <summary>
        /// Implémentation de la méthode de l'interface IEquatable<Produit>
        /// </summary>
        /// <param name="other">Produit qui va être comparé grâce au code à un autre objet</param>
        /// <returns>Retourne un booléen, indiquant si le produit mis en paramètre est égal au code</returns>
        public bool Equals(Produit other)
        {
            if (other == null) 
                return false;
            return (this.Code.Equals(other.Code)); // comparaison sur des entiers (ici le code)
        }

        /// <summary>
        /// Retourne le code sous forme de String
        /// </summary>
        /// <returns>Retourne un entier</returns>
        public override int GetHashCode(){
            return this.ToString().GetHashCode();
        }


        /// <summary>
        /// Surchage de l'opérateur ==
        /// </summary>
        /// <param name="p1">Premier produit à comparer</param>
        /// <param name="p2">Second produit à comparer</param>
        /// <returns>Retourne un booléen, indiquant si les deux produits mis en paramètre sont égaux ou non</returns>
        public static bool operator==(Produit p1, Produit p2)
        {
            if ((Object)p1 == null) 
                return ((Object)p2 == null);
            return p1.Equals(p2);
        }

        /// <summary>
        /// Surchage de l'opérateur !=
        /// </summary>
        /// <param name="p1">Premier produit à comparer</param>
        /// <param name="p2">Second produit à compaer</param>
        /// <returns>Retourne un booléan, indiquant si les deux produits sont différents ou non</returns>
        public static bool operator!=(Produit p1, Produit p2)
        {
            if ((Object)p1 == null) 
                return ((Object)p2 == null);
            return !p1.Equals(p2);
        }

        /// <summary>
        /// Compare l'identifiant de deux produits et indique lequel à un code plus petit
        /// </summary>
        /// <param name="other">Autre produit qui sera comparé à l'objet/produit courant</param>
        /// <returns>Un entier : -1 => le produit courant à un identifiant plus petit. 0 => L'identifiant des produits sont identique. 1 => L'identifiant du produit "other" est plus grand</returns>
        public int CompareTo(Produit other)
        {
            int res=-1;

            if ((Object)other!=null)
            {
                if ((Object)this == null)
                    res = 0;
                else if (this.Code < other.Code)
                    res = -1;
                else if (this.Code > other.Code)
                    res = 1;
                else // this.Code == other.Coe
                    res = 0;
            }

            return res;
        }

        /// <summary>
        /// Compare le code de deux produits grâce à la surcharge de l'opérateur : <
        /// </summary>
        /// <param name="m1">Produit courant</param>
        /// <param name="m2">Produit qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si p1 est inférieur à p2, <value>false</value> sinon.</returns>
        public static bool operator<(Produit p1, Produit p2)
        {
            bool res = false;
            if (p1.CompareTo(p2) < 0)
                res = true;
            return res;
        }

        /// <summary>
        /// Compare le code de deux produits grâce à la surcharge de l'opérateur : >
        /// </summary>
        /// <param name="p1">Produit courant</param>
        /// <param name="p2">Produit qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si p1 est supérieur à p2, <value>false</value> sinon.</returns>
        public static bool operator >(Produit p1, Produit p2)
        {
            bool res = false;
            if (p1.CompareTo(p2) > 0)
                res = true;
            return res;
        }

        /// <summary>
        /// Compare le code de deux produits grâce à la surcharge de l'opérateur : >=
        /// </summary>
        /// <param name="p1">Produit courant</param>
        /// <param name="p2">Produit qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si p1 est supérieur ou égale à p2, <value>false</value> sinon.</returns>
        public static bool operator >=(Produit p1, Produit p2)
        {
            bool res = false;
            if (p1.CompareTo(p2) > 0 || p1.CompareTo(p2) == 0)
                res = true;
            return res;
        }

        /// <summary>
        /// Compare le code de deux produits grâce à la surcharge de l'opérateur : <=
        /// </summary>
        /// <param name="p1">Produit courant</param>
        /// <param name="p2">Produit qui va être comparé</param>
        /// <returns>Un booléen : <value>true</value> si p1 est inférieur ou égale à p2, <value>false</value> sinon.</returns>
        public static bool operator <=(Produit p1, Produit p2)
        {
            bool res = false;
            if (p1.CompareTo(p2) < 0 || p1.CompareTo(p2) == 0)
                res = true;
            return res;
        }

        public void saisie()
        {
            string s;
            Console.WriteLine("Code ?");
            s = Console.ReadLine();
            _code = Int32.Parse(s);
            Console.WriteLine("Cat(Consommable...)?");
            CatS = Console.ReadLine();
        }

        public void affiche()
        {
            Console.WriteLine("Code:{0}\nNom:{1}\n", _code, _nom);
        }
    }
}
