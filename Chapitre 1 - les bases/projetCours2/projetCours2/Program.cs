using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCours2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //exercice sur les condition:

            // 1 : AGE
            Console.WriteLine("Quel âge as tu?");
            string entreeAge = Console.ReadLine();
            int age = int.Parse(entreeAge);

            if (age < 10
            {
                Console.WriteLine("Vous avez moins de 10 ans.");
            }
            else if (age < 18)
            {
                Console.WriteLine("Vous avez moins de 18 ans");
            }
            else
            {
                Console.WriteLine("Vous êtez majeur.");
            }

            // 2 : TRI DE VALEURS
            Console.WriteLine("Saisis un premier nombre : ");
            string entree1 = Console.ReadLine();
            int premierNombre = int.Parse(entree1);

            Console.WriteLine("Saisis un deuxième nombre plus grand : ");
            string entree2 = Console.ReadLine();
            int deuxiemeNombre = int.Parse(entree2);

            Console.WriteLine("Saisis un troisième nombre encore plus grand : ");
            string entree3 = Console.ReadLine();
            int troisiemeNombre = int.Parse(entree3);

            if(premierNombre < deuxiemeNombre && deuxiemeNombre < troisiemeNombre)
            {
                Console.WriteLine("les nombres dans l'ordre sont : " + premierNombre + " , " + deuxiemeNombre + " , " + troisiemeNombre);
            }
            else
            {
                Console.WriteLine("Veuillez saisir des nombres dans le bon ordre.");
            }



            // 3 : PV DE BOSS SELON UNE DIFFICULTE
            int pointsDeVie = 0;
            Console.WriteLine("Choisis une difficulté entre 1, 2 et 3 : ");
            string entreeDifficulte = Console.ReadLine();
            int difficulte = int.Parse(entreeDifficulte);

            //CORRIGE
            switch(difficulte)
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
            Console.WriteLine("Les points de vie du Boss sont de " + pointsDeVie);

            //if(difficulte == 1)
            //{
            //    pointsDeVie = 100;
            //    Console.WriteLine("Le boss a 100pv, le combat devrait bien se passer !");
            //}
            //else if(difficulte == 2)
            //{
            //    pointsDeVie = 250;
            //    Console.WriteLine("Le boss a 250pv, le combat va être plus chaud, mais en faisant attention, ça devrait aller !");
            //}
            //else
            //{
            //    pointsDeVie = 1000;
            //    Console.WriteLine("Le boss a 1000pv, bon ben c'était une joie de te connaître !!!");
            //}



            // afficher les chiffres de 1 à 1000
            for(int i = 0; i < 1001; i++)
            {
                Console.WriteLine(i);
            }

            // 4 : ON NE SORT PAS DE LA BOUCLE TANT QU'ON NE TAPE PAS LA LETTRE "A":
            string lettreCible = "A";
            Console.WriteLine("Saisis une lettre de l'alphabet et essaies de trouver la bonne lettre : ");
            string lettreEntree = Console.ReadLine();

            while(lettreEntree != lettreCible)
            {
                Console.WriteLine("La lettre " + lettreEntree + " n'était pas la bonne, retente ta chance !! ");
                lettreEntree = Console.ReadLine();
            }
            Console.WriteLine("Bravo !! La lettre " + lettreEntree + " était la bonne !! ");

            /*CORRIGE
             * string entreeLettre = "a";
             * do
             * {
             *  Console.WriteLine("Entrez la lettre a : ");
             *  entreeLettre = Console.ReadLine();
             * } while (entreeLettre != "a");
             * 
             * 
             */

            // 5 :  ON NE SORT PAS DE LA BOUCLE TANT QU'ON NE TAPE PAS LA LETTRE "A" OU "I":
            string lettreCible1 = "A";
            string lettreCible2 = "E";
            string lettreCible3 = "I";
            string lettreCible4 = "O";
            string lettreCible5 = "U";
            string lettreCible6 = "Y";

            Console.WriteLine("Saisis une lettre de l'alphabet et essaies de trouver la bonne lettre : ");
            lettreEntree = Console.ReadLine();
            /*bool estUneVoyelle = lettreEntree == "a"  || 
             *                     lettreEntree == "e" || 
             *                     lettreEntree == "i" || 
             *                     lettreEntree == "o" || 
             *                     lettreEntree == "u" || 
             *                     lettreEntree == "y";
             * 
             * do
             * {
             *  Console.WriteLine("Ce n'est pas une voyelle");
             * }
             * while
             */
            while (lettreEntree != lettreCible1 &&
                   lettreEntree != lettreCible2 &&
                   lettreEntree != lettreCible3 &&
                   lettreEntree != lettreCible4 &&
                   lettreEntree != lettreCible5 &&
                   lettreEntree != lettreCible6 )
            {
                Console.WriteLine("La lettre " + lettreEntree + " n'était pas la bonne, retente ta chance !! ");
                lettreEntree = Console.ReadLine();
            }
            Console.WriteLine("Bravo !! La lettre " + lettreEntree + " était la bonne !! ");

            // 6 KATA : FIZZBUZZ : divisible par 3, on affiche FIZZ. divisible par 5, on affiche BUZZ. uand les 2 cas sont possibles, on affiche FIZZBUZZ
            Console.WriteLine("Saisis un nombre entre 1 et 16130 : ");
            string entreeNombre = Console.ReadLine();
            int nombreSaisit = int.Parse(entreeNombre);

            for (int i = 0; i <= nombreSaisit; i++)
            {
                // bool divisiblePar3 = i % 3 == 0;
                // bool divisiblePar5 = i % 5 == 0;
                if (i % 3 == 0 && i % 5 == 0) // if (i % 15 == 0)
                {
                    Console.WriteLine("FIZZBUZZ");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("FIZZ");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("BUZZ");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
         }
     }
 }