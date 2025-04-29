using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    internal class Factory
    {
        public static AbstractGestionnaireNombreAleatoire CreateGestionnaireNombreAleatoire()
        {
            return new GestionnaireNombreAleatoire();
        }

        public static AbstractGestionnaireJeu CreateGestionnaireJeu(AbstractGestionnaireNombreAleatoire gestionnaireNombreAleatoire, CalculDesCoups calculDesCoups, Joueur joueur, GestionnaireSauvegarde gestionnaireSauvegarde)
        {
            return new GestionnaireJeu(gestionnaireNombreAleatoire, calculDesCoups, joueur, gestionnaireSauvegarde);
        }
    }
}
