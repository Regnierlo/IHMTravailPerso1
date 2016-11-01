using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie2
{
    class Panier<T> where T : IComparable<T>
    {
        #region déclaration de variables
        private readonly int _MAX; //Maximum d'objet que la liste peut contenir
        private T[] _tab; //Tableau où est stocké les items
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Panier()
        {
            _MAX = 10;
            _tab = new T[_MAX];
        }

        /// <summary>
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="m">Quantité maximale que l'objet prendra</param>
        public Panier(int m)
        {
            _MAX = m;
            _tab = new T[_MAX];
        }

        /// <summary>
        /// Constructeur avec la liste d'énumération
        /// </summary>
        /// <param name="t">Enumération à intégrer à l'objet</param>
        public Panier(IEnumerable<T> t)
        {
            _MAX = 10;
            _tab = new T[_MAX];
            if (t.Count() > _MAX)
                throw new System.ArgumentException("Le nombre d'item dans le paramètre est supérieur à la taille maximale autorisé.");
            else
            {
                for(int i=0;i<t.Count();i++)
                    _tab[i] = t.ElementAt(i);
            }
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="m">Quantité maximale d'items dans le panier</param>
        /// <param name="t">Enumération à intégrer à l'objet</param>
        public Panier(int m, IEnumerable<T> t)
        {
            if (t.Count() > m)
                throw new System.ArgumentException("Le paramètre \"m\" est trop petit par rapport à aux nombre d'items dans l'énumération passé en paramètre.");
            else
            {
                _MAX = m;
                _tab = new T[_MAX];
                for(int i=0; i<t.Count(); i++)
                    _tab[i] = t.ElementAt(i);

            }
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Ajoute une objet dans la liste et vérifie son intégrité
        /// </summary>
        /// <param name="t">Objet à ajouter</param>
        public void Add(T t)
        {
            if (t != null)
            {
                if (!this.Exist(t))
                {
                    int i = 0;
                    while (_tab[i] != null)
                        i++;
                    _tab[i] = t;
                }
            }
            else
                throw new System.ArgumentException("Objet passé en paramètre est null.");
        }

        /// <summary>
        /// Supprime un objet T du panier
        /// </summary>
        /// <param name="t">Objet à supprimer</param>
        public void Remove(T t)
        {
            if (this.Exist(t))
            {
                for (int i = 0; i < _tab.Count(); i++)
                {
                    if(_tab[i] != null)
                        if (_tab[i].Equals(t))
                            _tab[i] = default(T);
                }
                Sort();
            }
            else
                throw new SystemException("L'objet que vous souhaitez supprimer n'existe pas.");
        }

        public void Sort()
        {
            Array.Sort(_tab);
        }
        
        /// <summary>
        /// Retourne l'objet à l'emplacement i
        /// </summary>
        /// <param name="i">Emplacement de l'objet à récupérer</param>
        /// <returns>Retourne un objet T</returns>
        public T ElementAt(int i)
        {
            try
            {
                return _tab[i-1];
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Problème de dépassement.");
            }
            
        }

        /// <summary>
        /// Retoune l'élément t
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public T FindElement(T t)
        {
            try
            {
                T res=default(T);

                foreach (T obj in _tab)
                {
                    if(obj != null)
                        if (obj.Equals(t))
                            res = obj;
                }

                return res;
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Objet passé en paramètre n'existe pas dans la liste.");
            }
        }
        #endregion

        /// <summary>
        /// Vérifie si l'objet passé en paramètre existe dans le tableau
        /// </summary>
        /// <param name="t">Objet à vérifier l'existance</param>
        /// <returns>Retourne un Boolean <value>true</value> s'il existe, <value>false</value> s'il n'existe pas.</returns>
        private Boolean Exist(T t)
        {
            Boolean res = false;

            if(t != null)
                foreach (T tab in _tab)
                {
                    if(tab != null)
                        if (tab.Equals(t))
                            res = true;
                }

            return res;
        }

        /// <summary>
        /// Retourne la liste sous forme de chaine de caractères
        /// </summary>
        /// <returns>Retourne une chaine de caractère</returns>
        public override String ToString()
        {
            String s = "";

            foreach (T tab in _tab)
            {
                if (tab != null)
                {
                    s += tab.ToString();
                    s += "\n\n";
                }
            }

            return s;
        }
    }
}
