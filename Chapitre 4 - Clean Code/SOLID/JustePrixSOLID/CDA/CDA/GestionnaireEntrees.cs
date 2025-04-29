using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class GestionnaireEntrees
    {
        public static int ObtenirNombre()
        {
            string entree = Console.ReadLine();
            return int.Parse(entree);
        }

        public static string ObtenirChaineDeCaractere()
        {
            return Console.ReadLine();
        }
    }
}
