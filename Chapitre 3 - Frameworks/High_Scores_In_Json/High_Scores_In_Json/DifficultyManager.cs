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
            int easyDifficultyLimit = 101;
            int mediumDifficultyLimit = 1001;
            int hardDifficultyLimit = 10001;
            DisplayManager.DisplayWelcome();
            return Console.ReadLine();
        }

        public static void SwitchDifficulty(int difficulte)
        {
            Random aleatoire = new Random();
            int nombreAleatoire = 0;
            int nombreMaximum = 101;

            switch (difficulte)
            {
                case 1:
                    nombreMaximum = 101;
                    break;
                case 2:
                    nombreMaximum = 1001;
                    break;
                case 3:
                    nombreMaximum = 10001;
                    break;
                default:
                    nombreMaximum = 101;
                    break;
            }
            nombreAleatoire = aleatoire.Next(1, nombreMaximum);


        }
    }
}
