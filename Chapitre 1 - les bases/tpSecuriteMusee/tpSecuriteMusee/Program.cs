using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpSecuriteMusee
{
    internal class Program
    {
        internal static int PeriodeRonde(int debutRondeA, int finRondeA, int debutRondeB, int finRondeB)
        {
            int periodeCommune = 0;

            if ((debutRondeB >= debutRondeA && debutRondeB <= finRondeA) && (finRondeB >= debutRondeA && finRondeB <= finRondeA))
            {
                periodeCommune = finRondeA - debutRondeB;
            }
            else if ((debutRondeB >= debutRondeA && debutRondeB <= finRondeA) && (finRondeB >= debutRondeA && finRondeB >= finRondeA))
            {
                periodeCommune = finRondeA - debutRondeB;
            }
            else if ((debutRondeB <= debutRondeA && debutRondeB <= finRondeA) && (finRondeB >= debutRondeA && finRondeB >= finRondeA))
            {
                periodeCommune = finRondeB - debutRondeA;
            }
            else if ((debutRondeB <= debutRondeA && debutRondeB <= finRondeA) && (finRondeB >= debutRondeA && finRondeB <= finRondeA))
            {
                periodeCommune = finRondeB - debutRondeA;
            }
            return periodeCommune;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Saisissez le début de la période de ronde du premier garde :");
            int saisieDebutRondeGarde1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Saisissez la fin de la période de ronde du premier garde :");
            int saisieFinRondeGarde1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Saisissez le début de la période de ronde du deuxième garde :");
            int saisieDebutRondeGarde2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Saisissez la fin de la période de ronde du deuxième garde :");
            int saisieFinRondeGarde2 = Convert.ToInt32(Console.ReadLine());

            int rondesCommunes = PeriodeRonde(saisieDebutRondeGarde1, saisieFinRondeGarde1, saisieDebutRondeGarde2, saisieFinRondeGarde2);

            Console.WriteLine("Les deux gardes travillent " + rondesCommunes + " jours en communs.");


            Console.ReadLine();
        }
    }
}
