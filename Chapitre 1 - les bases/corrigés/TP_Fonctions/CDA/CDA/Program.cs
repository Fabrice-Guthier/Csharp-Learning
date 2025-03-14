using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            float aire = CalculAireRectangle(CalculAireRectangle(5f, 3f), 7f);
            Console.WriteLine(aire);

            Console.WriteLine(VerifierEntiersPositifs(5, 1));

            Console.WriteLine(Puissance(2, 10));
        }

        //Niveau 1 : calculer l'aire d'un rectangle
        public static float CalculAireRectangle(float largeur, float longueur)
        {
            return largeur * longueur;
        }

        //Niveau 2 : Vérifier que deux entiers sont positifs
        public static bool VerifierEntiersPositifs(int nombre1, int nombre2)
        {
            bool aRenvoyer = false;

            if (nombre1 >= 0 && nombre2 >= 0)
            {
                aRenvoyer = true;
            }
            else
            {
                aRenvoyer = false;
            }

            return aRenvoyer;
        }

        //Niveau 3 : Fonction puissance
        public static int Puissance(int nombre, int exposant)
        {
            int aRenvoyer = 1;

            if (exposant >= 0)
            {
                for (int i = 0; i < exposant; i++)
                {
                    aRenvoyer *= nombre;
                }
            }

            return aRenvoyer;
        }
    }
}