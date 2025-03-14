using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tpVendredi31_01_25
{
    internal class Program
    {

        // fonction de jeu



        static void Main(string[] args)
        {
            var randomNumber = new Random();
            string continueGame = "o";
            int winGames = 0;
            int loseGames = 0;
                    
            Console.WriteLine("Allez c'est parti on essaie de trouver le bon numéro let's goooooo !!!!");

            while (continueGame == "o")
            {
                bool targetNumber = false;
                string inputNumber = "";
                int difficulty = 0;
                int number = 0;
                int tryCount = 0;
                int maxTry = 10;
                int limitMax = 101;
                Console.WriteLine("Saisissez une difficulté entre 1, 2 et 3: ");
                string inputDifficulty = Console.ReadLine();
                difficulty = int.Parse(inputDifficulty);

                if (difficulty == 1)
                {

                    int easyModeNumber = randomNumber.Next(1, limitMax);
                    while (tryCount <= maxTry && !targetNumber)
                    {
                        Console.WriteLine("Vous avez " + (maxTry - tryCount) + " essais pour trouver le juste prix, dans une tranche de 1 à : " + limitMax);
                        inputNumber = Console.ReadLine();
                        number = int.Parse(inputNumber);
                        tryCount++;
                        if (number < easyModeNumber)
                        {
                            Console.WriteLine("C'est plus !");
                        }
                        else if (number > easyModeNumber)
                        {
                            Console.WriteLine("C'est moins !");
                        }
                        else if (tryCount == maxTry)
                        {
                            Console.WriteLine("Vous n'avez pas trouvé le juste prix, dommage :(");
                            loseGames++;
                        }
                        else
                        {
                            targetNumber = true;
                            Console.WriteLine("Vous avez trouvé le juste prix !!");
                        }
                    }
                }
                else if (difficulty == 2)
                {
                    maxTry = 15;
                    int mediumModeNumber = randomNumber.Next(1, limitMax*10);
                    while (tryCount <= maxTry && !targetNumber)
                    {
                        Console.WriteLine("Vous avez " + (maxTry - tryCount) + " essais pour trouver le juste prix, dans une tramche de 1 à : " + limitMax);
                        inputNumber = Console.ReadLine();
                        number = int.Parse(inputNumber);
                        tryCount++;
                        if (number < mediumModeNumber)
                        {
                            Console.WriteLine("C'est plus !");
                        }
                        else if (number > mediumModeNumber)
                        {
                            Console.WriteLine("C'est moins !");
                        }
                        else if (tryCount == maxTry)
                        {
                            Console.WriteLine("Vous n'avez pas trouvé le juste prix, dommage :(");
                            loseGames++;
                        }
                        else
                        {
                            targetNumber = true;
                            Console.WriteLine("Vous avez trouvé le juste prix !!");
                        }
                    }
                }
                else if (difficulty == 3)
                {
                    maxTry = 20;
                    int hardModeNumber = randomNumber.Next(1, limitMax*100);
                    while (tryCount <= maxTry && !targetNumber)
                    {
                        Console.WriteLine("Vous avez " + (maxTry - tryCount) + " essais pour trouver le juste prix, dans une tranche de 1 à : " + limitMax);
                        inputNumber = Console.ReadLine();
                        number = int.Parse(inputNumber);
                        tryCount++;
                        if (number < hardModeNumber)
                        {
                            Console.WriteLine("C'est plus !");
                        }
                        else if (number > hardModeNumber)
                        {
                            Console.WriteLine("C'est moins !");
                        }
                        else
                        {
                            targetNumber = true;
                            Console.WriteLine("Vous avez trouvé le juste prix !!");
                        }
                    }
                }
                if (!targetNumber)
                {
                    Console.WriteLine("Vous n'avez pas trouvé le juste prix, dommage :(");
                    loseGames++;
                }
                else
                {
                    winGames++;
                }
                Console.WriteLine("Nombre de parties gagnées : " + winGames);
                Console.WriteLine("Nombre de parties perdues : " + loseGames);
                Console.WriteLine("Voulez vous refaire une partie ? o / n");
                continueGame = Console.ReadLine();
                maxTry = 10;
            }
            Console.WriteLine("Merci d'avoir joué :)");
        }
    }
}
