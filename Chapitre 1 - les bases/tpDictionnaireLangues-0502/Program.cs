using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpDictionnaireLangues_0502
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // je crée un dictionnaire avec un mot en français et son équivalent anglais
            Dictionary<string, string> francaisAnglais = new Dictionary<string, string>();
            francaisAnglais.Add("bonjour", "hello");
            francaisAnglais.Add("maison", "house");
            francaisAnglais.Add("livre", "book");

            // je demande la saisie d'un des mots du dictionnaire et j'affiche le mot associé
            Console.WriteLine("Veuillez saisir un des mots suivants : bonjour, maison, livre.");
            string motFrancais = Console.ReadLine();
            string motAnglais = francaisAnglais[motFrancais];
            Console.WriteLine(motFrancais + " en anglais est : " + motAnglais);


            // je fais le même dictionnaire aue plus haut ;ais cette fois dans l'autre sens, anglais vers français
            Dictionary<string, string> anglaisFrancais = new Dictionary<string, string>();
            anglaisFrancais.Add("hello", "bonjour");
            anglaisFrancais.Add("house", "maison");
            anglaisFrancais.Add("book", "livre");

            // et je fais l'affichage
            Console.WriteLine("Veuillez saisir un des mots suivants : hello, house, book.");
            string motAnglais2 = Console.ReadLine();
            string motFrancais2 = anglaisFrancais[motAnglais2];
            Console.WriteLine(motAnglais + " en anglais est : " + motFrancais);


            Console.ReadLine();
        }
    }
}
