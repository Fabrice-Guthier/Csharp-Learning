using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpLinqTriPairSup10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> listeDeNombres = new List<int> { 3, 42, 20, 63, 5, 8, 7, 9, 11, 34, 54, 65 };

            IEnumerable<int> triNombresPair2 = from n in listeDeNombres
                                            where n > 10 && n % 2 == 0
                                            select n;

            foreach (int i in triNombresPair2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine("################################");
            Console.WriteLine();

            List<int> triNombresPair = listeDeNombres
                .Where(i => i > 10 && i % 2 == 0)
                .ToList();

            foreach (int i in triNombresPair)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();

        }
    }
}
