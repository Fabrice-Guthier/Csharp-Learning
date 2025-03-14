using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpReferenceLV2_1002
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Niveau 1 : Faire une fonction qui parcourt une chaîne de caractère pour compter le nombre d'espaces à l'intérieur (n'oubliez pas que les string sont des tableaux de char)
            string phrase = "Tes yeux d'un bleu d'azur, tes cheveux en cascade, ton âme et coeur si pur, je vais prendre une petite salade.";

            
            Console.WriteLine("Dans cette phrase, il y a " + CompterEspaces(phrase, ' ') + " espaces.");

            Console.ReadLine();
        }

        public static int CompterEspaces( string texteAParcourir, char caractereATrouver)
        {
            int aRenvoyer = 0;

            foreach( char caractere in texteAParcourir)
            {
                if (caractere == caractereATrouver)
                    aRenvoyer++;
            }

            return aRenvoyer;
        }

    }
}
