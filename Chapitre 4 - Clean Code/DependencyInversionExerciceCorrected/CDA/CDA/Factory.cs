using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Factory
    {
        public static AbstractGestionnaireNombreAleatoire CreerGestionnaireNombreAleatoire()
        {
            return new GestionnaireNombreAleatoire();
        }
        public static AbstractCalculDesCoups CreerCalculDesCoups()
        {
            return new CalculDesCoups();
        }
        public static AbstractGestionnaireJeu CreerGestionnaireJeu()
        {
            return new GestionnaireJeu();
        }
        public static AbstractGestionnaireAffichage CreerGestionnaireAffichage()
        {
            return new GestionnaireAffichage();
        }
        public static AbstractGestionnaireEntrees CreerGestionnaireEntrees()
        {
            return new GestionnaireEntrees();
        }
        public static AbstractGestionnaireSauvegarde CreerGestionnaireSauvegarde()
        {
            return new GestionnaireSauvegarde();
        }
        public static AbstractJoueur CreerJoueur()
        { 
            return new Joueur();
        }
        public static AbstractScorePersonnel CreerScorePersonnel(string pseudonyme)
        {
            return new ScorePersonnel(pseudonyme);
        }
        public static AbstractTableauDesScores CreerTableauDesScores()
        {
            return new TableauDesScores();
        }
    }
}
