using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class RobotAssembleur
    {
        public List<Reserve> Reserves { get; set; }
        public List<Produit> ProduitsRealisables { get; set; } //ensemble des produits que le robot sait fabriquer
        public TapisRoulant TapisRoulantSuivant { get; set; }

        Random random; //permettra de gérer l'aléatoire

        public RobotAssembleur(List<Reserve> reserves, List<Produit> produitsRealisables, TapisRoulant tapisRoulantSuivant)
        {
            Reserves = reserves ?? throw new ArgumentNullException(nameof(reserves));
            ProduitsRealisables = produitsRealisables ?? throw new ArgumentNullException(nameof(produitsRealisables));
            TapisRoulantSuivant = tapisRoulantSuivant ?? throw new ArgumentNullException(nameof(tapisRoulantSuivant));
            random = new Random();
        }


        /// <summary>
        /// Renvoie vrai si le processus du robot peut être exécuté
        /// </summary>
        public bool PeutExecuterProcessus()
        {
            bool ARenvoyer = false;

            foreach(Produit p in ProduitsRealisables)
            {
                //à partir du moment où le robot peut réaliser au moins un produit, il peut exécuter son processus
                if (PeutRealiserProduit(p))
                    ARenvoyer = true;
            }

            return ARenvoyer;
        }

        /// <summary>
        /// Renvoie vrai si le robot peut réaliser le produit
        /// </summary>
        public bool PeutRealiserProduit(Produit p)
        {
            Dictionary<string, int> composantsNecessaires = p.ComposantsNecessaires;
            bool ARenvoyer = true;

            //pour chaque composant, on vérifie qu'on en a la quantité suffisante dans nos réserves
            for (int i = 0; i < composantsNecessaires.Count; i++)
            {
                bool quantiteSuffisante = false;

                foreach(Reserve r in Reserves)
                {
                    if(r.ComposantsStockes.Type == composantsNecessaires.ElementAt(i).Key) //on cherche la réserve correspondante au composant
                    {
                        if(r.Quantite >= composantsNecessaires.ElementAt(i).Value)
                            quantiteSuffisante = true;
                    }
                }

                //si un seul composant n'est pas en quantité suffisante, alors on renvoie faux (car le robot ne peut alors pas réaliser le produit)
                if(!quantiteSuffisante)
                {
                    ARenvoyer = false;
                    break;
                }
            }

            return ARenvoyer;
        }

        public void ExecuterProcessus()
        {
            //détermine quel objet le robot doit construire
            List<Produit> produitsRealisables = new List<Produit>(); //on ajoute dans cette liste les produits que l'on peut réaliser actuellement
            foreach(Produit p in ProduitsRealisables)
            {
                if (PeutRealiserProduit(p))
                    produitsRealisables.Add(p);
            }

            //on tire au sort parmi les produit réalisables actuellement
            Produit produitARealiser = produitsRealisables[random.Next(0, produitsRealisables.Count)];

            //on retire les composants aux réserves
            Dictionary<string, int> composantsNecessaires = produitARealiser.ComposantsNecessaires;

            for (int i = 0; i < composantsNecessaires.Count; i++)
            {
                foreach (Reserve r in Reserves)
                {
                    if (r.ComposantsStockes.Type == composantsNecessaires.ElementAt(i).Key) //on cherche la réserve correspondante au composant
                    {
                        for (int j = 0; j < composantsNecessaires.ElementAt(i).Value; j++) //on retire autant d'éléments que nécessaire
                        {
                            r.Quantite--;
                        }
                    }
                }
            }

            //pour les besoins du TP, on affiche ces textes
            Console.WriteLine("\nLe robot assembleur vient de réaliser le produit : " + produitARealiser.Type);
            Console.WriteLine("Les réserves contiennent désormais : ");
            foreach(Reserve r in Reserves)
            {
                Console.WriteLine(r.ComposantsStockes.Type + " : " + r.Quantite);
            }

            //on dépose le produit réaliser sur le tapis roulant pour le robot suivant
            TapisRoulantSuivant.ProduitsSurLeTapis.Add(produitARealiser);
        }
    }
}
