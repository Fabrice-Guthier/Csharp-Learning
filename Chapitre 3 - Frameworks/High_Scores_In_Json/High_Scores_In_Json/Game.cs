using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;



namespace High_Scores_In_Json
{
    public class Game
    {
        internal int nombreDeCoups;

        public void Play()
        {
            Random aleatoire = new Random();
            string entreeRejouer = "";
            string entreeDifficulte = "";
            int difficulte = 1;
            int nombreAleatoire;
            int nombreMaximum;
            int HighScore;

            do
            {
                entreeDifficulte = DifficultyManager.InputDifficulty();
                difficulte = int.Parse(entreeDifficulte);

                nombreAleatoire = 0;
                nombreMaximum = 101;
                nombreDeCoups = 0;
                HighScore = 0;

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

                int nombreEntre = -1;

                //Console.WriteLine(nombreAleatoire);

                do
                {
                    DisplayManager.DisplayNextTurn();
                    nombreDeCoups++;

                    string entree = Console.ReadLine();
                    nombreEntre = int.Parse(entree);

                    if (nombreEntre > nombreAleatoire)
                    {
                        DisplayManager.DisplayItsLess();
                    }
                    else if (nombreEntre < nombreAleatoire)
                    {
                        DisplayManager.DisplayItsMore();
                    }
                    else
                    {
                        DisplayManager.DisplayItsWin();
                    }
                } while (nombreEntre != nombreAleatoire);

                if (nombreDeCoups < HighScore)
                {
                    HighScore = nombreDeCoups;
                    Console.WriteLine($"Nouveau meilleur score : {HighScore}");
                }
                DisplayManager.DisplayGameOver(nombreDeCoups);

                DisplayManager.DisplayContinueGame();
            } while (entreeRejouer == "O");

            Console.WriteLine("Ok dégage !");
        }
    }
}
