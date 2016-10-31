using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie3
{
    class Coureur
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

        public int CompareTo(Coureur other)
        {
            int res = -1;
            if ((Object)other != null)
            {
                if ((Object)this == null)
                    res = 0;
                else
                    res = this.Nom.CompareTo(other.Nom);
            }
            return res;
        }
    }
}
