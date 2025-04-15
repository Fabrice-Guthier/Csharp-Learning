using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Scores_In_Json
{
    internal class DifficultyManager
    {
        
        public static string InputDifficulty()
        {
            DisplayManager.DisplayWelcome();
            return Console.ReadLine();
        }

        public static void SwitchDifficulty(int difficulte)
        {
            int easyDifficultyLimit = 101;
            int mediumDifficultyLimit = 1001;
            int hardDifficultyLimit = 10001;
            int nombreMaximum = 101;

            switch (difficulte)
            {
                case 1:
                    nombreMaximum = easyDifficultyLimit;
                    break;
                case 2:
                    nombreMaximum = mediumDifficultyLimit;
                    break;
                case 3:
                    nombreMaximum = hardDifficultyLimit;
                    break;
                default:
                    nombreMaximum = easyDifficultyLimit;
                    break;
            }
            Randomizer();


        }
        public static int Randomizer()
        {
            Random aleatoire = new Random();
            int nombreDeDepartPourAleatoire = 1;
            int nombreMaximum = 101;
            int nombreAleatoire = aleatoire.Next(nombreDeDepartPourAleatoire, nombreMaximum);
            return nombreAleatoire;
        }
    }
}
