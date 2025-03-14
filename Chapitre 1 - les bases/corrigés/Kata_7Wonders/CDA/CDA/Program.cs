using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Calcul7Wonders(4, 3, 2));
        }

        public static int Calcul7Wonders(int symboleA, int symboleB, int symboleC)
        {
            int aRenvoyer = 0;

            aRenvoyer += symboleA * symboleA;
            aRenvoyer += symboleB * symboleB;
            aRenvoyer += symboleC * symboleC;

            int nombreLePlusPetit = symboleA;

            if (symboleB < nombreLePlusPetit)
                nombreLePlusPetit = symboleB;
            if (symboleC < nombreLePlusPetit)
                nombreLePlusPetit = symboleC;

            aRenvoyer += nombreLePlusPetit * 7;

            return aRenvoyer;
        }
    }
}