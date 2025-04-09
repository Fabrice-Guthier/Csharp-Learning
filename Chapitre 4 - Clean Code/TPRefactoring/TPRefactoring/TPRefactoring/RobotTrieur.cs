using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class RobotTrieur
    {
        public List<Bac> Bacs { get; set; }

        public TapisRoulant TapisPrecedent { get; set; }

        public RobotTrieur(List<Bac> bacs, TapisRoulant tapisPrecedent)
        {
            Bacs = bacs ?? throw new ArgumentNullException(nameof(bacs));
            TapisPrecedent = tapisPrecedent ?? throw new ArgumentNullException(nameof(tapisPrecedent));
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
            Produit produitATrier = TapisPrecedent.ProduitsSurLeTapis[0];
            TapisPrecedent.ProduitsSurLeTapis.Remove(produitATrier);

            //on le place dans le bon bac
            foreach(Bac b in Bacs)
            {
                if(b.TypeBac.Type == produitATrier.Type)
                {
                    b.ProduitsStockes.Add(produitATrier);
                }
            }
        }

        /// <summary>
        /// Pour les besoins du TP, on peut utiliser cette fonction pour afficher la quantité de produits dans chaque bac
        /// </summary>
        public void AfficherBacs()
        {
            Console.WriteLine("\n\n");

            foreach(Bac b in Bacs)
            {
                Console.WriteLine("Ce bac contient : " + b.ProduitsStockes.Count + " " + b.TypeBac.Type);
            }
        }
    }
}
