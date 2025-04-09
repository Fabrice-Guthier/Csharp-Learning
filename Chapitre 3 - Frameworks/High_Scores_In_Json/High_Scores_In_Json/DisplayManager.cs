using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Scores_In_Json
{
    internal class DisplayManager
    {
        public static void DisplayWelcome()
        {
            Console.WriteLine("Bienvenue dans le jeu du nombre mystère !");
            Console.WriteLine("Vous devez deviner un nombre entre 1 et 100");
            Console.WriteLine("Vous pouvez choisir la difficulté :");
            Console.WriteLine("1 : facile (1-100)");
            Console.WriteLine("2 : moyen (1-1000)");
            Console.WriteLine("3 : difficile (1-10000)");
        }

        public static void DisplayNextTurn()
        {
            Console.Write("=> ");
        }
        public static void DisplayHighScore (int highScore)
        {
            Console.WriteLine("Nouveau meilleur score : " + highScore);
        }

        public static void DisplayItsMore()
        {
            Console.WriteLine("C'est plus !");
        }

        public static void DisplayItsLess()
        {
            Console.WriteLine("C'est moins !");
        }

        public static void DisplayItsWin()
        {
            Console.WriteLine("C'est gagné !");
        }

        public static void DisplayGameOver(int nombreDeCoups)
        {
            Console.WriteLine("Fin du jeu ! Vous avez trouvé en " + nombreDeCoups + " coups");
        }

        public static void DisplayContinueGame()
        {
            Console.WriteLine("Voulez-vous continuer à jouer ? (O/N)");
            string entree = Console.ReadLine();
        }

    }
}
