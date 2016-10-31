using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie3
{
    // Un dictionnaire est une collection de paires clé/valeur, chaque clé étant unique

    public class Generique_Dictionnaire
    {
        // Exemple : numéro de maillots de coureurs
        // Dictionary <TKey, TValue>
        private Dictionary<Int32, string> _listeCoureurs;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Generique_Dictionnaire()
        {
            this._listeCoureurs = new Dictionary<Int32, string>();
        }

        /// <summary>
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="res">Si on a déjà crée un dictionnaire</param>
        public Generique_Dictionnaire(Dictionary<Int32, string> res){
            this._listeCoureurs = res;
        }

        /// <summary>
        /// Accesseurs
        /// </summary>
        public Dictionary<Int32, string> ListeCoureurs
        {
            get { return _listeCoureurs; }
            set { _listeCoureurs = value; }
        }

        /// <summary>
        /// Permet d'afficher la collection en entière
        /// </summary>
        public void affichageDico()
        {
            if (_listeCoureurs.Count > 0)
                foreach (KeyValuePair<int, string> entry in _listeCoureurs)
                {
                    Console.WriteLine("\n{0} : {1} \n", entry.Value, entry.Key);
                }
            else
                Console.WriteLine("\nLa collection est vide.\n");
        }
        
        /// <summary>
        /// Permet d'ajouter un couple clé/valeur dans la collection
        /// </summary>
        /// <param name="nom">La chaîne de caractère correspondant à la valeur dans le couple clé/valeur</param>
        /// <param name="numero">Le int correspondant à la clé dans le couple clé/valeur</param>
        public void AjoutDico(string nom, int numero){
            try
            {
                _listeCoureurs.Add(numero, nom);
                Console.WriteLine("--> "+nom + " : " + numero + " a été ajouté(e).\n");
            }
            catch (ArgumentException)
            {
                // La clé qui doit être unique est déjà utilisée dans la collection
                Console.WriteLine("--x Le numéro a déjà été donné.\n");
            }
        }

        /// <summary>
        /// Permet de supprimer un couple clé/valeur en fonction de la clé
        /// </summary>
        /// <param name="numero">Le int correspondant à la clé du couple clé/valeur que l'on souhaite enlever de la collection</param>
        public void SupprimerDico(int numero)
        {
            if (_listeCoureurs.ContainsKey(numero))
            /// On vérifie dans un premier temps si la collection contient la clé.
            {
                _listeCoureurs.Remove(numero);
                Console.WriteLine("Le coureur avec le maillot n° " + numero + " est disqualifié.\n");
            }
            else
                Console.WriteLine("La collection ne comporte aucune valeur ayant comme clé le numéro indiqué.\n");
        }

        /// <summary>
        /// Permet de supprimer la collection entière.
        /// </summary>
        public void SupprimerDicoEntier()
        {
            _listeCoureurs.Clear();
        }
        
        // --------------------------- Rechercher
        /// <summary>
        /// Permet de rechercher dans une collection un couple clé/valeur en fonction de la clé
        /// </summary>
        /// <param name="numero">Le paramètre correspondant à la clé que l'on souhaite retrouver.</param>
        public void RechercheNumero(int numero)
        {
            string value="";

            if (_listeCoureurs.TryGetValue(numero, out value))
            {
                Console.WriteLine("Le coureur correspondant au maillot " + numero + " est " + value + "\n");
            }
            else
                Console.WriteLine("Le coureur correspondant au maillot " + numero + " est indisponible pour le moment\n");
        }

        /// <summary>
        /// Trier une collection dans l'ordre croissant des clés
        /// </summary>
        public void TrierDico()
        {
            Dictionary<Int32, string> res = new Dictionary<int, string>();
            string valeurRes = "";
            int min = Int32.MaxValue;
            int max = Int32.MinValue;

            for (int i = 0; i < _listeCoureurs.Count; i++)
            {
                foreach (KeyValuePair<int, string> entry in _listeCoureurs)
                {
                    if (entry.Key < min && entry.Key > max){
                        min = entry.Key;
                        valeurRes=entry.Value;
                    }
                }
                res.Add(min, valeurRes);
                max = min;
                min = Int32.MaxValue;
            }
            _listeCoureurs = res;
        }
    }
}
