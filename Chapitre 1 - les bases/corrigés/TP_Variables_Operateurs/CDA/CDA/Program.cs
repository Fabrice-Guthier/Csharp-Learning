using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Niveau 1 : Dire bonjour
            Console.WriteLine("C'est quoi ton prénom ?");
            string entree = Console.ReadLine();

            Console.WriteLine("Bonjour " + entree);

            //Niveau 2 : Faire une addition
            Console.WriteLine("Entrez un nombre : ");
            string entree1 = Console.ReadLine();

            Console.WriteLine("Entrez un autre nombre : ");
            string entree2 = Console.ReadLine();

            int nombre1 = int.Parse(entree1);
            int nombre2 = int.Parse(entree2);

            int resultat = nombre1 + nombre2;

            Console.WriteLine("La somme fait : " + resultat);

            //Niveau 3 : Calcul d'une remise
            Console.WriteLine("Entrez un prix : ");
            string entreePrix = Console.ReadLine();

            Console.WriteLine("Entrez un pourcentage de remise : ");
            string entreePourcentageRemise = Console.ReadLine();

            float prix = float.Parse(entreePrix);
            float pourcentageRemise = float.Parse(entreePourcentageRemise);

            float valeurRemise = prix * pourcentageRemise / 100f;
            float prixFinal = prix - valeurRemise;

            Console.WriteLine("Le prix final est : " + prixFinal);
            
            //KATA : échanger deux valeurs
            int variable1 = 10;
            int variable2 = 20;
            int variableTemporaire;

            variableTemporaire = variable1;
            variable1 = variable2;
            variable2 = variableTemporaire;

            Console.WriteLine(variable1 + " " + variable2);

            //méthode de ninja
            int variable3 = 10;
            int variable4 = 20;

            variable3 += variable4;
            //variable3 = 30 / variable4 = 20
            variable4 = variable3 - variable4;
            //variable3 = 30 / variable4 = 10
            variable3 -= variable4;
            //variable3 = 20 / variable4 = 10

        }
    }
}