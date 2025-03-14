using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesBouclesInmriquees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LV0 étoiles verticales
            Console.WriteLine("Saisis un nombre pour afficher des étoiles verticalement : ");
            string input = Console.ReadLine();
            int userInput = int.Parse(input);
            
            for (int i = 0; i < userInput; i++)
            {
                Console.WriteLine("*");
            }


            // LV 1 étoiles verticales et horizontales
            Console.WriteLine("Saisis un nombre pour afficher des étoiles en carré : ");
            input = Console.ReadLine();
            userInput = int.Parse(input);

            for (int i = 0; i < userInput; i++)
            {
                for (int j = 0; j < userInput; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // LV2 étoiles progressives
            Console.WriteLine("Saisis un nombre pour afficher des étoiles en triangle : ");
            input = Console.ReadLine();
            userInput = int.Parse(input);

            for (int i = 0; i < userInput; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // LV3 étoiles pyramide
            Console.WriteLine("Saisis un nombre pour afficher des étoiles en pyramide : ");
            input = Console.ReadLine();
            userInput = int.Parse(input);

            for (int i = 1; i <= userInput; i++)
            {
                for (int j = i; j <= userInput; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++) // for (int k = 0; k <= (i + 1) *2; k++)
                {
                    Console.Write("**");
                }
                Console.WriteLine();
            }

        

            // LV4 étoiles paires et impaires
            Console.WriteLine("Saisis un nombre pour afficher des étoiles 1 sur 2 : ");
            input = Console.ReadLine();
            userInput = int.Parse(input);

            for (int i = 0; i <= userInput; i++)
            {
                for (int j = i; j < userInput + i; j++)
                {
                    if (j % 2 == 0) // if (i%2 == 0 && j %2 == 1 || i%2 == 1 && j%2 == 0) OU if (i%2 != j%2)
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
        Console.ReadLine();
        }
    }
}