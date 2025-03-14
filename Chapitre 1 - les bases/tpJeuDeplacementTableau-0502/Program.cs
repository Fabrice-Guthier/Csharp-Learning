using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpJeuDeplacementTableau_0502
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Taille de la grille
            int largeur = 10;
            int hauteur = 10;

            // Création de la grille
            char[,] grille = new char[hauteur, largeur];

            // Position initiale du personnage
            int joueurX = 0;
            int joueurY = 0;

            // Initialisation de la grille (vide)
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    grille[i, j] = '.';
                }
            }

            // Boucle de jeu
            while (true)
            {
                // Affichage de la grille
                Console.Clear();
                AfficherGrille(grille, joueurX, joueurY);

                // Lecture de l'entrée du joueur
                ConsoleKeyInfo touche = Console.ReadKey();

                // Déplacement du personnage
                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        joueurY = Math.Max(0, joueurY - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        joueurY = Math.Min(hauteur - 1, joueurY + 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        joueurX = Math.Max(0, joueurX - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        joueurX = Math.Min(largeur - 1, joueurX + 1);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Fonction pour afficher la grille
        static void AfficherGrille(char[,] grille, int joueurX, int joueurY)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (i == joueurY && j == joueurX)
                    {
                        Console.Write('P'); // Personnage
                    }
                    else
                    {
                        Console.Write(grille[i, j]);
                    }
                }
                Console.WriteLine();

            }
        }
    }
}
