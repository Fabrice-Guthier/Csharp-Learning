using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpCryptageCaracteres_1002
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // Niveau 2 : Faire une fonction de cryptage. Elle possède un dictionnaire à l'intérieur d'elle qu'on va utiliser pour modifier chaque lettre en une autre
            string phrase = "Tes yeux d'un bleu d'azur, tes cheveux en cascade, ton âme et coeur si pur, je vais prendre une petite salade.";

            Console.WriteLine(CryptagePhrase(phrase));

            Console.ReadLine();
        }

        public static string CryptagePhrase(string phraseACrypter)
        {
            Dictionary<char, char> cryptageLettre = new Dictionary<char, char>()
            {
                {'a', 'f' },
                {'b', 'g' },
                {'c', 'h' },
                {'d', 'i' },
                {'e', 'j' },
                {'f', 'k' },
                {'g', 'l' },
                {'h', 'm' },
                {'i', 'n' },
                {'j', 'o' },
                {'k', 'p' },
                {'l', 'q' },
                {'m', 'r' },
                {'n', 's' },
                {'o', 't' },
                {'p', 'u' },
                {'q', 'v' },
                {'r', 'w' },
                {'s', 'x' },
                {'t', 'y' },
                {'u', 'z' },
                {'v', 'a' },
                {'w', 'b' },
                {'x', 'c' },
                {'y', 'd' },
                {'z', 'e' },
            };

            foreach (char lettre in phraseACrypter)
            {
                if (cryptageLettre.ContainsKey(char.ToLower(lettre)))
                {
                    phraseACrypter += cryptageLettre[char.ToLower(lettre)];
                }
                else
                {
                    phraseACrypter += lettre;
                }
            }
            return phraseACrypter;

        }
    }
}
