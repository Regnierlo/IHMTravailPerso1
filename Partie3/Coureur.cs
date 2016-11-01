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

        public Coureur(){
            this._maillot=-1;
            this._nom="";
        }

        public Coureur(int m, string n)
        {
            this._maillot = m;
            this._nom = n;
        }

        public void NCoureur(Coureur objet)
        {
            this._maillot = objet.Maillot;
            this._nom = objet.Nom;
        }

        
        public int Maillot
        {
            get { return _maillot; }
            set { _maillot = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        public override string ToString()
        {
            string s = "";
            s= _nom +" ("+_maillot+")";
            return s;
        }

        public static bool operator <(Coureur c1, Coureur c2)
        {
            bool res = false;
            if (c1.Maillot < c2.Maillot)
                res = true;
            return res;
        }


        public static bool operator >(Coureur c1, Coureur c2)
        {
            bool res = false;
            if (c1.Maillot > c2.Maillot)
                res = true;
            return res;
        }

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
