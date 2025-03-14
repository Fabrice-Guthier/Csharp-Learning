using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpLinq_0602
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // requête LINQ pour savoir quels personnages sont encore en vie pour se prendre un ult de zone
            // 

            List<int> pointsDeViePersonnage = new List<int> { 2, 15, 44, 0, 9, 27 };

            IEnumerable<int> iNeedHealing = from pv in pointsDeViePersonnage
                                            where pv > 0
                                            select pv;
            int nombreHerosVivants = 0;
            foreach (int i in iNeedHealing)
            {
                nombreHerosVivants ++;
            }
            Console.WriteLine("Il reste " + nombreHerosVivants + " héros vivants");

            Console.WriteLine();
            Console.WriteLine("################################");
            Console.WriteLine();

            List<int> iNeedHealingAgain = pointsDeViePersonnage
                .Where(i => i > 0)
                .ToList();

            int nombreHerosToujoursDebout = 0;
            foreach (int i in iNeedHealingAgain)
            {
                nombreHerosToujoursDebout++;
            }
            Console.WriteLine("Il reste " + nombreHerosToujoursDebout + " héros vivants");


            Console.ReadLine();
        }
    }
}
