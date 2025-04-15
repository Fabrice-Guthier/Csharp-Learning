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
            string rejouer = "o";
            int nombreDeSecuritePourCommencer = -1;
            int difficulte = 1;
            int nombreAleatoire = 0; // Fix: Initialize the variable to avoid CS0165
            int nombreMaximum;
            int HighScore = 0;

            do
            {
                entreeDifficulte = DifficultyManager.InputDifficulty();
                difficulte = int.Parse(entreeDifficulte);

                DifficultyManager.SwitchDifficulty(difficulte);

                int nombreEntre = nombreDeSecuritePourCommencer;

                do
                {
                    DisplayManager.DisplayNextTurn();
                    nombreDeCoups++;

                    string entree = Console.ReadLine();
                    nombreEntre = int.Parse(entree);

                    CheckIfNumberIsTheOneToFind(nombreEntre, nombreAleatoire);
                } while (nombreEntre != nombreAleatoire);

                if (nombreDeCoups < HighScore)
                {
                    HighScore = nombreDeCoups;
                    DisplayManager.DisplayHighScore(HighScore);
                }
                DisplayManager.DisplayGameOver(nombreDeCoups);

                DisplayManager.DisplayContinueGame();
            } while (entreeRejouer == rejouer);

            DisplayManager.DisplayGameOverMessage();

        }

        public static void CheckIfNumberIsTheOneToFind(int nombreEntre, int nombreAleatoire)
        {
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
        }
    }
}
