using System;
using System.Collections.Generic;

namespace tpDictionnaireLangues_0502
{
    internal class Program
    {
        static string Traduire(string mot, Dictionary<string, string> dictionnaire)
        {
            if (dictionnaire.ContainsKey(mot))
            {
                return dictionnaire[mot];
            }
            else
            {
                return null;
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> francaisAnglais = new Dictionary<string, string>();
            francaisAnglais.Add("bonjour", "hello");
            francaisAnglais.Add("maison", "house");
            francaisAnglais.Add("livre", "book");

            while (true)
            {
                Console.WriteLine("Entrez le mot à traduire parmis les mots suivants :");
                Console.WriteLine("bonjour -- maison -- livre :");

                Dictionary<string, string> dictionnaireSource = null;
                dictionnaireSource = francaisAnglais;

                string motATraduire = Console.ReadLine().ToLower();

                string traduction = Traduire(motATraduire, dictionnaireSource);

                if (traduction != null)
                {
                    Console.WriteLine(motATraduire + " en français est : " + traduction);
                }
                else
                {
                    Console.WriteLine("Le mot " + motATraduire + " n'est pas dans le dictionnaire.");
                }
                Console.WriteLine("Merci d'avoir utilisé le traducteur !");
                Console.ReadKey();
            }
        }
    }
}