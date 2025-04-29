using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class GestionnaireNombreAleatoire : AbstractGestionnaireNombreAleatoire
    {
        public GestionnaireNombreAleatoire()
        {
            
        }

        public override void GenererNombreAleatoire()
        {
            Random aleatoire = new Random();

            int nombreMaximum = DeterminerLeNombreMaximum();

            NombreAleatoire = aleatoire.Next(1, nombreMaximum);
        }

        public override int DeterminerLeNombreMaximum()
        {
            GestionnaireAffichage.MessageChoixDeLaDifficulte();

            int difficulte = GestionnaireEntrees.ObtenirNombre();

            int nombreMaximum = 101;

            switch (difficulte)
            {
                case 1:
                    nombreMaximum = 101;
                    break;
                case 2:
                    nombreMaximum = 1001;
                    break;
                case 3:
                    nombreMaximum = 10001;
                    break;
                default:
                    nombreMaximum = 101;
                    break;
            }

            return nombreMaximum;
        }
    }
}
