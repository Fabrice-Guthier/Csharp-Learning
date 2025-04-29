using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class GestionnaireEntrees : AbstractGestionnaireEntrees
    {
        public override int ObtenirNombre()
        {
            string entree = Console.ReadLine();
            return int.Parse(entree);
        }

        public override string ObtenirChaineDeCaractere()
        {
            return Console.ReadLine();
        }
    }
}
