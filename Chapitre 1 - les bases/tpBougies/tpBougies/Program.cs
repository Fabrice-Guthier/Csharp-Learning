using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBougies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kata bougies
            //Imaginons des bougies.
            //Si on en a 3, on peut en utiliser 3.
            //Mais à partir de la cire de 3 bougies, on peut fabriquer une 4ème bougie.
            //Si maintenant on commence avec 9 bougies, on pourra en fabriquer 3 et avoir 12 bougies...
            //Trouver l'algorithme correspondant.

            Console.WriteLine("Saisissez une quantité de bougies : ");
            int candleQuantity = int.Parse(Console.ReadLine());

            int totalCandlesUsed = 0;
            int candleRest = 0;

            while (candleQuantity > 0)
            {
                // on compte
                totalCandlesUsed += candleQuantity;
                // on brule
                candleRest += candleQuantity;
                // on refabrique
                candleQuantity = candleRest / 3;
                candleRest %= 3;
            }

            Console.WriteLine("On peut avoir un total de " + totalCandlesUsed);
            Console.ReadLine();
        }
    }
}
