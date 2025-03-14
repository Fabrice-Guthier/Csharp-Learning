using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int bougiesDeDepart = 11;
            int bougiesEntieres = bougiesDeDepart;
            int bougiesTotal = 0;
            int morceauxDeBougies = 0;

            while (bougiesEntieres > 0)
            {
                //on compte les bougies
                bougiesTotal += bougiesEntieres;

                //on brûle des bougies
                morceauxDeBougies += bougiesEntieres;

                //on refabrique des bougies
                bougiesEntieres = morceauxDeBougies / 3;
                morceauxDeBougies %= 3;
            }

            Console.WriteLine(bougiesTotal);
        }
    }
}