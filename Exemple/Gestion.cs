using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    class Gestion
    {
        private LesMagasins _lm = new LesMagasins();

        public Gestion()
        {
            start();
        }

        private void initTest()
        {
            Magasin m = new Magasin(001, "E.Leclerc", 0380459752, "Dijon");
            m.AddProduit(new Produit(468, "Chocolat", (float)1.99, CategorieProduit.Consommable, "Epicerie Sucré"));
            m.AddProduit(new Produit(347, "Pâtes - Coquillettes", (float)0.99, CategorieProduit.Consommable, "Epicerie Salé"));
            _lm.ajouterMagasins(m);

            m = new Magasin(002, "Carrefour", 0380678911, "Dijon");
            m.AddProduit(new Produit(27, "Chocolat Noir", (float)2.91, CategorieProduit.Consommable, "Epicerie Sucré"));
            m.AddProduit(new Produit(621, "Riz", (float)0.98, CategorieProduit.Consommable, "Epicerie Salé"));
            _lm.ajouterMagasins(m);
            
        }

        /// <summary>
        /// Menu principal
        /// </summary>
        private void start()
        {

            initTest();

            string choix = "";
            bool quit = false;
            do
            {
                Console.WriteLine("1 - Ajouter un magasin");
                Console.WriteLine("2 - Liste des magasins");
                Console.WriteLine("3 - Quitter");
                Console.WriteLine("\nVotre choix ?");
                choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        addMagasin();
                        break;
                    case "2":
                        listerMagasin();
                        break;
                    case "3":
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Veuillez choisir parmis la liste proposée.\n\n");
                        break;
                }


            } while (!quit);
        }
        
        /// <summary>
        /// Ajoute un magasin au logiciel de gestion
        /// </summary>
        private void addMagasin()
        {
            bool ok = false;

            string idMag;
            string nom;
            string tel;
            string ville;

            Console.Clear();
            Console.WriteLine("Une série de question vous sera posées afin de créer le magasin.\n");

            do
            {
                Console.Write("Identifiant du magasin : ");
                idMag = Console.ReadLine();
                ok = _lm.verifId(Int32.Parse(idMag));
                if (!ok)
                    Console.WriteLine("Identifiant déjà existant.");
            } while (!ok);
            
            Console.Write("\nNom du magasin : ");
            nom = Console.ReadLine();
            
            Console.Write("\nNuméro de téléphone du magasin : ");
            tel = Console.ReadLine();
           
            Console.Write("\nVille du magasin : ");
            ville = Console.ReadLine();
            
            Magasin m = new Magasin(Int32.Parse(idMag), nom, Int32.Parse(tel), ville);
            _lm.ajouterMagasins(m);
        }

        /// <summary>
        /// Permet de lister les magasins
        /// </summary>
        private void listerMagasin()
        {
            Console.Clear();
            Console.WriteLine(_lm.ToString()+"\n\n");
            Console.WriteLine("---------------------------------------");
            Boolean ok = false;
            string choix;
            do
            {
                Console.WriteLine("\n\nVoulez-vous effectuer ou action sur l'un des magasins ? (O/N)");
                choix = Console.ReadLine();
                switch (choix.ToUpper())
                {
                    case "O":
                        listerActionMagasin();
                        ok = true;
                        break;
                    case "N":
                        ok = true;
                        break;
                    default:
                        Console.WriteLine("Merci de répondre par \"O\" ou par \"N\".");
                        break;
                }
            } while (!ok);
        }









        private void listerProduitTrie(Magasin m)
        {
            Console.Clear();
            List<Produit> p = m.TriProduits();
            string s = "";
            foreach (Produit pr in p)
            {
                s += pr.ToString();
                s += "\n\n";
            }
            Console.WriteLine(s);
        }


        private void trieListe()
        {
            Boolean ok = false;
            string choix = "";

            //Liste les magasins
            listerMagasinPourAction();

            do
            {
                try
                {
                    choix = Console.ReadLine();
                    if ((Int32.Parse(choix)) <= NombreMagasin())
                    {
                        Console.Clear();
                        listerProduitTrie(_lm.getMagasin(Int32.Parse(choix)));
                        Console.WriteLine("----------------------------\n\n");
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                }
            } while (!ok);
        }




        /// <summary>
        /// Liste des actions que l'utilisateur peut effectuer sur les magasins
        /// </summary>
        private void listerActionMagasin()
        {
            Console.Clear();
            Console.WriteLine("1 - Lister les produits d'un magasin"); //OK
            Console.WriteLine("9 - Lister produit trié");
            Console.WriteLine("2 - Ajouter un produit à un magasin");
            Console.WriteLine("3 - Supprimer un produit à un magasin");
            Console.WriteLine("4 - Modifier le numéro de téléphone du magasin"); //OK
            Console.WriteLine("5 - Modifier le nom du magasin"); //OK
            Console.WriteLine("6 - Détail d'un magasin"); //OK
            Console.WriteLine("7 - Retour"); //OK 

            Boolean ok = false;
            string choix;
            do
            {
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "9":
                        trieListe();
                        ok=true;
                        break;
                    case "1":
                        ChoisirMagasinPourListeProduits();
                        ok = true;
                        break;
                    case "2":
                        ChoisirMagasinPourAjouterProduit();
                        ok = true;
                        break;
                    case "3":
                        ChoisirMagasinPourSupprimerProduit();
                        ok = true;
                        break;
                    case "4":
                        ChoisirMagasinPourModifierTelephone();
                        ok = true;
                        break;
                    case "5":
                        ChoisirMagasinPourModifierNom();
                        ok = true;
                        break;
                    case "6":
                        ChoisirMagasinPourDetail();
                        ok = true;
                        break;
                    case "7":
                        ok = true;
                        break;
                    default:
                        break;
                }
            } while (!ok);
        }

        /// <summary>
        /// Choisie le magasin qui va changer de nom
        /// </summary>
        private void ChoisirMagasinPourModifierNom()
        {
            Console.Clear();
            Boolean ok = false;
            string choix = "";

            //Liste les magasins
            listerMagasinPourAction();

            do
            {
                try
                {
                    choix = Console.ReadLine();
                    if ((Int32.Parse(choix)) <= NombreMagasin())
                    {
                        Console.Clear();
                        modifierNom(_lm.getMagasin(Int32.Parse(choix)));
                        Console.WriteLine("----------------------------\n\n");
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                }
            } while (!ok);
        }

        /// <summary>
        /// Change le nom du magasin
        /// </summary>
        /// <param name="m"></param>
        private void modifierNom(Magasin m)
        {
            bool ok = false;
            Console.Clear();

            do
            {
                Console.WriteLine("Nouveau nom du magasin :");
                try
                {
                    m.Nom = Console.ReadLine();
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Merci de choisir un nom valide.");
                }
            } while (!ok);
        }

        /// <summary>
        /// Choisie le magasin qui va changer de numéro de téléphone
        /// </summary>
        private void ChoisirMagasinPourModifierTelephone()
        {
            Console.Clear();
            Boolean ok = false;
            string choix = "";

            //Liste les magasins
            listerMagasinPourAction();

            do
            {
                try
                {
                    choix = Console.ReadLine();
                    if ((Int32.Parse(choix)) <= NombreMagasin())
                    {
                        Console.Clear();
                        modifierNumTelephone(_lm.getMagasin(Int32.Parse(choix)));
                        Console.WriteLine("----------------------------\n\n");
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                }
            } while (!ok);
        }

        /// <summary>
        /// Modifie le numéro de téléphone d'un magasin
        /// </summary>
        /// <param name="m">Magasin qui va subir la modification du numéro de téléphone</param>
        private void modifierNumTelephone(Magasin m)
        {
            bool ok = false;
            int resTmp;
            string choix = "";
            Console.Clear();

            do
            {
                Console.WriteLine("Nouveau numéro du magasin :");
                try
                {
                    choix = Console.ReadLine();
                    if (Int32.TryParse(choix, out resTmp))
                    {
                        m.Numero = resTmp;
                        ok = true;
                    }
                    else
                        Console.WriteLine("Merci d'entrer un numéro de téléphone sous la forme suivante : \"0xxxxxxxxxx\"");
                }
                catch (Exception)
                {
                    Console.WriteLine("Merci de choisir un numéro valide.");
                }
            } while (!ok);
        }

        private void ChoisirMagasinPourSupprimerProduit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Choisie le magasin où l'utilisateur va ajouter un produit
        /// </summary>
        private void ChoisirMagasinPourAjouterProduit()
        {
            Console.Clear();
            Boolean ok = false;
            string choix = "";

            //Liste les magasins
            listerMagasinPourAction();

            do
            {
                try
                {
                    choix = Console.ReadLine();
                    if ((Int32.Parse(choix)) <= NombreMagasin())
                    {
                        Console.Clear();
                        AjouterProduit(_lm.getMagasin(Int32.Parse(choix)));
                        Console.WriteLine("----------------------------\n\n");
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                }
            } while (!ok);
        }

        /// <summary>
        /// Ajoute un produit au magasin choisie
        /// </summary>
        /// <param name="m">Magasin qui va recevoir un nouveau produit</param>
        private void AjouterProduit(Magasin m)
        {
            bool ok = false;

            int iCode;

            string nom;

            string prix;
            
            int i=1;

            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine("Code du produit : ");
                    if (Int32.TryParse(Console.ReadLine(), out iCode))

                    Console.WriteLine("Nom du produit : ");
                    nom = Console.ReadLine();

                    Console.WriteLine("Nom du prix : ");
                    prix = Console.ReadLine();

                    Console.WriteLine("Nom du Catégorie : ");
                    
                    foreach (CategorieProduit cp in Enum.GetValues(typeof(CategorieProduit)))
	                {
                        Console.WriteLine("\t"+i+" - "+cp.ToString());
                        i++;
	                }

                    Console.WriteLine("Nom du Sous-Catégorie : ");
                }
                catch (Exception)
                {
                    Console.WriteLine("Une chaine de caractère à besoin d'être rentrée.");
                }
            } while (!ok);
            
        }
        /// <summary>
        /// Choisie le magasin qui va voir son détail s'afficher à l'écran
        /// </summary>
        private void ChoisirMagasinPourDetail()
        {
            Console.Clear();
            Boolean ok = false;
            string choix = "";

            //Liste les magasins
            listerMagasinPourAction();

            do
            {
                try
                {
                    choix = Console.ReadLine();
                    if ((Int32.Parse(choix)) <= NombreMagasin())
                    {
                        Console.Clear();
                        detailMagasin(_lm.getMagasin(Int32.Parse(choix)));
                        Console.WriteLine("----------------------------\n\n");
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMerci de faire un choix parmis la liste proposé.\n");
                }
            } while (!ok);
        }

        /// <summary>
        /// Affiche le détail du magasin
        /// </summary>
        /// <param name="m">Magasin que l'on va afficher</param>
        private void detailMagasin(Magasin m)
        {
            Console.Clear();
            Console.WriteLine(m);
        }

        /// <summary>
        /// Liste les magasins
        /// </summary>
        private void listerMagasinPourAction()
        {
            Console.Clear();
            Console.WriteLine("Choisissez le magasin à modifier :\n\n");

            int i = 1;
            foreach (Magasin mag in _lm.lm)
            {
                Console.WriteLine(i + " - " + mag.Nom + "( id : " + mag.IdMag + " )");
                i++;
            }
        }

        /// <summary>
        /// Retourne le nombre de magasin
        /// </summary>
        /// <returns>Un entier</returns>
        private int NombreMagasin()
        {
            return _lm.Size();
        }

        /// <summary>
        /// Liste les magasins et enregistre le choix de l'utilisateur pour lister les produits du choix
        /// </summary>
        private void ChoisirMagasinPourListeProduits()
        {
            Boolean ok = false;
            string choix="";

            //Liste les magasins
            listerMagasinPourAction();

            do
            {
                try
                {
                    choix = Console.ReadLine();
                    if ((Int32.Parse(choix)) <= NombreMagasin())
                    {
                        Console.Clear();
                        listerProduit(_lm.getMagasin(Int32.Parse(choix)));
                        Console.WriteLine("----------------------------\n\n");
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("\nMerci de faire un choix parmi la liste proposée.\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMerci de faire un choix parmi la liste proposée.\n");
                }
            } while (!ok);
        }

        /// <summary>
        /// Liste les produits d'un magasin
        /// </summary>
        /// <param name="m"></param>
        private void listerProduit(Magasin m)
        {
            Console.Clear();
            Console.WriteLine(m.ListeProduits());
        }
    }
}
