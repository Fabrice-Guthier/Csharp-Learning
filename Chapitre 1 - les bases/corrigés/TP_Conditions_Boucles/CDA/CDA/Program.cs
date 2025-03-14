using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Conditions
            
            //Niveau 1 : Vérifier un âge
            Console.WriteLine("Veuillez entrer votre âge : ");
            string entreeAge = Console.ReadLine();
            int age = int.Parse(entreeAge);

            if (age < 10)
            {
                Console.WriteLine("Bonjour jeune enfant");
            }
            else if (age < 18)
            {
                Console.WriteLine("Bonjour brave adolescent");
            }
            else
            {
                Console.WriteLine("Bonjour vieil adulte");
            }

            //Niveau 2 : Nombres croissants
            Console.WriteLine("Veuillez entrer trois nombres : ");
            string entreeNombre1 = Console.ReadLine();
            int nombre1 = int.Parse(entreeNombre1);

            string entreeNombre2 = Console.ReadLine();
            int nombre2 = int.Parse(entreeNombre2);
            
            string entreeNombre3 = Console.ReadLine();
            int nombre3 = int.Parse(entreeNombre3);

            if (nombre1 < nombre2 && nombre2 < nombre3)
            {
                Console.WriteLine("Les nombres sont dans l'ordre croissant");
            }
            else
            {
                Console.WriteLine("Les nombres ne sont pas dans l'ordre croissant");
            }

            //Niveau 3 : Points de vie d'un boss
            Console.WriteLine("Quelle niveau de difficulté voulez-vous ? ");
            string entreeNiveauDeDifficulte = Console.ReadLine();
            int niveauDeDifficulte = int.Parse(entreeNiveauDeDifficulte);

            int pointsDeVie = 0;

            switch (niveauDeDifficulte)
            {
                case 1:
                    pointsDeVie = 100;
                    break;
                case 2:
                    pointsDeVie = 250;
                    break;
                case 3:
                    pointsDeVie = 1000;
                    break;
                default:
                    pointsDeVie = 100;
                    break;
            }
            
            Console.WriteLine("Les points de vie du boss sont de " + pointsDeVie);
            
            //Boucles
            //Niveau 1 : Afficher les chiffres de 0 à 1000

            for (int i = 0; i < 1001; i++)
            {
                Console.WriteLine(i);
            }

            //Niveau 2 : On demande la lettre a
            string entreeLettre = "a";

            do
            {
                Console.WriteLine("Entrez la lettre a : ");
                entreeLettre = Console.ReadLine();
            } while (entreeLettre != "a");

            //Niveau 3 : On demande une voyelle
            string entreeVoyelle = "a";

            do
            {
                Console.WriteLine("Entrez une voyelle : ");
                entreeVoyelle = Console.ReadLine();
            } while (!(entreeVoyelle == "a" 
            || entreeVoyelle == "e"
            || entreeVoyelle == "i"
            || entreeVoyelle == "o"
            || entreeVoyelle == "u"
            || entreeVoyelle == "y"
            ));

            //Autre méthode :
            /*
            string entreeVoyelle = "a";
            bool estUneVoyelle = entreeVoyelle == "a"
            || entreeVoyelle == "e"
            || entreeVoyelle == "i"
            || entreeVoyelle == "o"
            || entreeVoyelle == "u"
            || entreeVoyelle == "y";
            
            do
            {
                Console.WriteLine("Entrez une voyelle : ");
                entreeVoyelle = Console.ReadLine();
            } while (!estUneVoyelle);

            //Encore une autre méthode :
            string entreeVoyelle = "a";

            do
            {
                Console.WriteLine("Entrez une voyelle : ");
                entreeVoyelle = Console.ReadLine();
            } while (entreeVoyelle != "a"
            && entreeVoyelle != "e"
            && entreeVoyelle != "i"
            && entreeVoyelle != "o"
            && entreeVoyelle != "u"
            && entreeVoyelle != "y"
            );*/

            //FizzBuzz
            bool divisiblePar3, divisiblePar5;

            for (int i = 0; i < 1000; i++)
            {
                divisiblePar3 = i % 3 == 0;
                divisiblePar5 = i % 5 == 0;

                if (divisiblePar3 && divisiblePar5)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (divisiblePar3)
                {
                    Console.WriteLine("Fizz");
                }
                else if(divisiblePar5)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            //FizzBuzz : méthode 2

            for (int i = 0; i < 1000; i++)
            {
                string aAfficher = "";

                if (i % 3 == 0)
                {
                    aAfficher += "Fizz";
                }
                if (i % 5 == 0)
                {
                    aAfficher += "Buzz";
                }
                if(aAfficher == "")
                {
                    aAfficher += i;
                }

                Console.WriteLine(aAfficher);
            }
        }
    }
}