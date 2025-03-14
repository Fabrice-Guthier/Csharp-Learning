using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpTableauRogueLike_0602
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int largeur = 5;
            int hauteur = 5;

            char[,] grille = new char[hauteur, largeur];

            int joueurX = 0;
            int joueurY = 0;

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    grille[i, j] = '_';
                }

            }
            Console.Clear();

            AfficherGrille(grille, joueurX, joueurY);

            while (true)
            {
                Console.WriteLine("Par oú voulez vous vous aller ?");
                Console.WriteLine("Tapez les mots 'haut', 'bas', 'gauche' ou 'droite' pour vous diriger. Tapez 'quitter' pour stopper cette aventure.");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "haut":
                        if (joueurY > 0)
                        {
                            joueurY --;
                        }
                        AfficherGrille(grille, joueurX, joueurY);
                        break;

                    case "bas":
                        if (joueurY < hauteur-1)
                        {
                            joueurY ++;
                        }
                        AfficherGrille(grille, joueurX, joueurY);
                        break;

                    case "gauche":
                        if (joueurX > 0)
                        {
                            joueurX --;
                        }
                        AfficherGrille(grille, joueurX, joueurY);
                        break;

                    case "droite":
                        if (joueurX < largeur-1)
                        {
                            joueurX ++;
                        }
                        AfficherGrille(grille, joueurX, joueurY);
                        break;

                    case "quitter":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        //Fonction grille
        static void AfficherGrille(char[,] grille, int joueurX, int joueurY)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (i == joueurY && j == joueurX)
                    {
                        Console.Write('Y'); // Personnage qui est content d'être là
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
