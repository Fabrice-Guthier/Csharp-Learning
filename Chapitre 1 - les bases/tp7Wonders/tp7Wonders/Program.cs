using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp7Wonders
{
    internal class Program
    {
        public static int multiSymbols(int firstValue)
        {
            return firstValue * firstValue;
        }

        static void Main(string[] args)
        {
            int bonusPoints = 0;

            Console.WriteLine("Il est temps de compter les points !!");

            Console.WriteLine("Combien de fois avez vous le premier symbole ?");
            string inputSymbolACount = Console.ReadLine();
            int countSymbolA = int.TryParse(inputSymbolACount);
            int totalCountSymbolA = multiSymbols(countSymbolA);

            Console.WriteLine("Combien de fois avez vous le deuxième symbole ?");
            string inputSymbolBCount = Console.ReadLine();
            int countSymbolB = int.TryParse(inputSymbolBCount);
            int totalCountSymbolB = multiSymbols(countSymbolB);

            Console.WriteLine("Combien de fois avez vous le troisième symbole ?");
            string inputSymbolCCount = Console.ReadLine();
            int countSymbolC = int.TryParse(inputSymbolCCount);
            int totalCountSymbolC = multiSymbols(countSymbolC);

            int totalResult = totalCountSymbolA + totalCountSymbolB + totalCountSymbolC;

            Console.WriteLine("Vous avez un total de " + totalCountSymbolA + " carrés, " + totalCountSymbolB + " croix et " + totalCountSymbolC + " ronds." );

            while (countSymbolA >= 1 && countSymbolB >= 1 && countSymbolC >= 1)
            {
                int minCount = Math.Min(countSymbolA, Math.Min(countSymbolB, countSymbolC));

                bonusPoints += 7 * minCount;
                countSymbolA -= minCount;
                countSymbolB -= minCount;
                countSymbolC -= minCount;
            }
            totalResult += bonusPoints;

            Console.WriteLine("Ce qui fait un total de " + totalResult + " points, dont " + bonusPoints + " points bonus.");

            
            Console.ReadLine();
        }
    }
}
