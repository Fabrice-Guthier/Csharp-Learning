using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int secondes = 3723;
            int minutes = 0;
            int heures = 0;
            int secondesRestantes = 0;

            //ConvertirSecondesV2(ref secondes, ref minutes, ref heures);

            secondesRestantes = ConvertirSecondes(secondes, ref minutes, ref heures);
            Console.WriteLine(secondesRestantes + " " + minutes + " " + heures);
            Console.WriteLine($"{secondesRestantes} {minutes} {heures}");

            string texte = "Metz Numeric School eee";
            Console.WriteLine(CompterCaracteres(texte, 'e'));
        }
        
        //Manipulation de chaînes de caractère, niveau 1
        public static int CompterCaracteres(string texteAParcourir, char caractereATrouver)
        {
            int aRenvoyer = 0;

            foreach (char caractere in texteAParcourir)
            {
                if (caractere == caractereATrouver)
                    aRenvoyer++;
            }

            return aRenvoyer;
        }

        //Niveau 2 : Cryptage
        public static string Cryptage(string texteACrypter)
        {
            string texteARenvoyer = "";

            Dictionary<char, char> cryptageLettre = new Dictionary<char, char>();
            cryptageLettre.Add('a', 'e');
            cryptageLettre.Add('e', 'o');
            cryptageLettre.Add('o', 'a');

            foreach (char caractere in texteACrypter)
            {
                if (cryptageLettre.ContainsKey(caractere))
                {
                    texteARenvoyer += cryptageLettre[caractere];
                }
                else
                {
                    texteARenvoyer += caractere;
                }
            }

            return texteARenvoyer;
        }

        public static int ConvertirSecondes(int secondes, ref int minutes, ref int heures)
        {
            heures = secondes / 3600;

            secondes %= 3600;
            minutes = secondes / 60;

            secondes %= 60;
            return secondes;
        }

        public static void ConvertirSecondesV2(ref int secondes, ref int minutes, ref int heures)
        {
            heures = secondes / 3600;

            secondes %= 3600;
            minutes = secondes / 60;

            secondes %= 60;
        }
    }
}