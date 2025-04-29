using CDA.Gestionnaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Abstract
{
    abstract class AbstractGestionnaireNombreAleatoire
    {
        public int NombreAleatoire { get; set; }

        public AbstractGestionnaireNombreAleatoire()
        {

        }

        public void GenererNombreAleatoire()
        {
            Random aleatoire = new Random();

            int nombreMaximum = DeterminerLeNombreMaximum();

            NombreAleatoire = aleatoire.Next(1, nombreMaximum);
        }

        public int DeterminerLeNombreMaximum()
        {
            AbstractGestionnaireAffichage.MessageChoixDeLaDifficulte();

            int difficulte = AbstractGestionnaireEntrees.ObtenirNombre();

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
