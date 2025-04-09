using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class RobotEtiqueteur
    {
        public TapisRoulant TapisPrecedent { get; set; }
        public TapisRoulant TapisSuivant { get; set; }
        
        int productId;

        public RobotEtiqueteur(TapisRoulant tapisPrecedent, TapisRoulant tapisSuivant)
        {
            TapisPrecedent = tapisPrecedent ?? throw new ArgumentNullException(nameof(tapisPrecedent));
            TapisSuivant = tapisSuivant ?? throw new ArgumentNullException(nameof(tapisSuivant));
            productId = 0;
        }

        public bool PeutExecuterProcessus()
        {
            //tant qu'il y a au moins un produit sur le tapis précédent, on peut exécuter le processus
            if (TapisPrecedent.ProduitsSurLeTapis.Count > 0)
                return true;
            else
                return false;
        }

        public void ExecuterProcessus()
        {
            //on prends le premier produit à avoir été déposé sur le tapis
            Produit produitAEtiqueter = TapisPrecedent.ProduitsSurLeTapis[0];
            TapisPrecedent.ProduitsSurLeTapis.Remove(produitAEtiqueter);

            //on lui ajoute une étiquette
            switch (produitAEtiqueter.Type)
            {
                case "pyramide":
                    produitAEtiqueter.Etiquetage = "pyramide" + productId.ToString();
                    break;
                case "cube":
                    produitAEtiqueter.Etiquetage = "cube" + productId.ToString();
                    break;
                case "pavé":
                    produitAEtiqueter.Etiquetage = "pavé" + productId.ToString();
                    break;
                default:
                    break;
            }

            productId++; //l'id s'incrémente à chaque nouveau produit, quel que soit son type

            //pour les besoins du TP, on affiche cette ligne dans la console
            Console.WriteLine("Le robot étiqueteur vient d'ajouter l'étiquette : " + produitAEtiqueter.Etiquetage);

            //on le dépose sur le tapis suivant
            TapisSuivant.ProduitsSurLeTapis.Add(produitAEtiqueter);
        }
    }
}
