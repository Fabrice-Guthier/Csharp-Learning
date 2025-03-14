using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpConversionRomaine_0602
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<int, string> conversionEnUnitesRomains = new Dictionary<int, string>()
            {
                { 1, "I" }, { 2, "II" }, { 3, "III" }, { 4, "IV" }, { 5, "V" },
                { 6, "VI" }, { 7, "VII" }, { 8, "VIII" }, { 9, "IX" }
            };

            Dictionary<int, string> conversionEnDizainesRomains = new Dictionary<int, string>()
            {
                { 10, "X" }, { 20, "XX" }, { 30, "XXX" }, { 40, "XL" }, { 50, "L" },
                { 60, "LX" }, { 70, "LXX" }, { 80, "LXXX" }, { 90, "XC" }
            };

            Dictionary<int, string> conversionEnCentainesRomains = new Dictionary<int, string>()
            {
                { 100, "C" }, { 200, "CC" }, { 300, "CCC" }, { 400, "CD" }, { 500, "D" },
                { 600, "DC" }, { 700, "DCC" }, { 800, "DCCC" }, { 900, "CM" }
            };

            Dictionary<int, string> conversionEnMiliersRomains = new Dictionary<int, string>()
            {
                { 1000, "M" }
            };

            Console.Write("Entrez un nombre à convertir en chiffres romains : ");
            string saisieUtilisateur = Console.ReadLine();

            if (int.TryParse(saisieUtilisateur, out int donneeAConvertir))
            {
                string resultat = "";

                if (donneeAConvertir >= 1000)
                {
                    int milliers = donneeAConvertir / 1000;
                    resultat += conversionEnMiliersRomains[milliers * 1000];
                    donneeAConvertir %= 1000;
                }

                if (donneeAConvertir >= 100)
                {
                    int centaines = donneeAConvertir / 100;
                    resultat += conversionEnCentainesRomains[centaines * 100];
                    donneeAConvertir %= 100;
                }

                if (donneeAConvertir >= 10)
                {
                    int dizaines = donneeAConvertir / 10;
                    resultat += conversionEnDizainesRomains[dizaines * 10];
                    donneeAConvertir %= 10;
                }

                if (donneeAConvertir > 0)
                {
                    resultat += conversionEnUnitesRomains[donneeAConvertir];
                }

                Console.WriteLine("Le nombre en chiffres romains est : " + resultat);
            }
            else
            {
                Console.WriteLine("Saisie invalide. Veuillez entrer un nombre entier.");
            }
            Console.ReadLine();
        }
    }
}


