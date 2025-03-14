using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCours1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Veuillez saisir votre prénom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Bonjour " + prenom );
        
            Console.WriteLine("Veuillez saisir un nombre : ");
            int nombre1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un deuxième nombre :");
            int nombre2 = Convert.ToInt32(Console.ReadLine());
            int somme = nombre1 + nombre2;
            Console.WriteLine("La somme est : " + somme);

            Console.WriteLine("Veuillez saisir un prix :");
            int prixNormal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez saisir une remise :");
            int remise = Convert.ToInt32(Console.ReadLine());
            double prix = prixNormal - (prixNormal * remise / 100);
            Console.WriteLine("Le prix remisé est de : " + prix + " euros");


            Console.WriteLine("Maintenant voyons les variables :");

            int variableA = 5;
            int variableB = 7;
            int variableC = variableB;
            Console.WriteLine(variableA);
            Console.WriteLine(variableB);
            Console.WriteLine("Maintenant échangeaons les valeurs :");
            variableB = variableA;
            variableA = variableC;
            Console.WriteLine(variableA);
            Console.WriteLine(variableB);

            variableA = 12;
            variableB = 23;
            Console.WriteLine(variableA);
            Console.WriteLine(variableB);
            Console.WriteLine("Maintenant échangeaons les valeurs :");
            (variableA, variableB) = (variableB, variableA);
            Console.WriteLine(variableA);
            Console.WriteLine(variableB);



            //CORRIGE
            //niveau 1
            Console.WriteLine("c'est quoi ton prénom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Bonjour" + " " + prenom);

            //niveau 2 : faire une addition:
            Console.WriteLine("Entrez un nombre :");
            string entree1 = Console.ReadLine();

            Console.WriteLine("Entrez un autre nombre :");
            string entree2 = Console.ReadLine();

            int nombre1 = int.Parse(entree1);
            int nombre2 = int.Parse(entree2);

            int resultat = nombre1 + nombre2;

            Console.WriteLine(resultat);

            //niveau 3 : calcul d'une remise

            Console.WriteLine("Entrez un prix :");
            string entreePrix = Console.ReadLine();

            Console.WriteLine("Entrez une remise :");
            string entreeRemise = Console.ReadLine();

            float prix = float.Parse(entreePrix);
            int pourcentageRemise = int.Parse(entreeRemise);

            float valeurRemise = prix * pourcentageRemise / 100f;
            float prixFinal = prix - valeurRemise;

            Console.WriteLine("Le prix final est : " + prixFinal + " euros");

            //niveau 4 : kata échange de valeurs

            int variable1 = 10;
            int variable2 = 20;
            int variableTemporaire;

            variableTemporaire = variable1;
            variable1 = variable2;
            variable2 = variableTemporaire;

            //méthode ninja
            int variable3 = 10;
            int variable4 = 20;

            variable3 = +variable4;
            //variable3 = 30 / variable4 = 20
            variable4 = variable3 - variable4;
            //variable3 = 30 / variable4 = 10
            variable3 -= variable4;
            //variable3 = 20 / variable4 = 10



            Console.ReadLine();
        }
    }
}

