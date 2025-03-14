using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string entree = Console.ReadLine();
            int nombreDeLignes = int.Parse(entree);

            //Niveau 0
            for (int i = 0; i < nombreDeLignes; i++)
            {
                Console.WriteLine("*");
            }

            Console.WriteLine();

            //Niveau 1
            for (int i = 0; i < nombreDeLignes; i++)
            {
                //une ligne d'étoiles
                for (int j = 0; j < nombreDeLignes; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }

            Console.WriteLine();

            //Niveau 2
            for (int ligne = 0; ligne < nombreDeLignes; ligne++)
            {
                for (int colonne = 0; colonne < ligne + 1; colonne++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Niveau 3
            for (int ligne = 0; ligne < nombreDeLignes; ligne++)
            {
                for (int colonne = 0; colonne < nombreDeLignes - ligne - 1; colonne++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < (ligne + 1) * 2; i++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            //Niveau turbo-chaud
            for (int ligne = 0; ligne < nombreDeLignes; ligne++)
            {
                for (int colonne = 0; colonne < nombreDeLignes; colonne++)
                {
                    if (ligne % 2 != colonne % 2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}