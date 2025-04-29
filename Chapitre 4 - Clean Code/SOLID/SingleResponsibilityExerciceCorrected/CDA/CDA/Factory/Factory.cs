using CDA.Abstract;
using CDA.SystemeDeJeu;
using CDA.Gestionnaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Factory
{
    class Factory
    {
        public static AbstractCalculDesCoups CreateCalculDesCoups()
        {
            return new CalculDesCoups();
        }

        public static AbstractGestionnaireJeu CreateGestionnaireJeu(AbstractGestionnaireNombreAleatoire gestionnaireNombreAleatoire, AbstractCalculDesCoups calculDesCoups, AbstractJoueur joueur, AbstractGestionnaireSauvegarde gestionnaireSauvegarde)
        {
            return new GestionnaireJeu(gestionnaireNombreAleatoire, calculDesCoups, joueur, gestionnaireSauvegarde);
        }

        public static AbstractGestionnaireNombreAleatoire CreateGestionnaireNombreAleatoire()
        {
            return new GestionnaireNombreAleatoire();
        }

        public static AbstractGestionnaireSauvegarde CreateGestionnaireSauvegarde()
        {
            return new GestionnaireSauvegarde();
        }

        public static AbstractJoueur CreateJoueur()
        {
            return new Joueur();
        }


    }
}
