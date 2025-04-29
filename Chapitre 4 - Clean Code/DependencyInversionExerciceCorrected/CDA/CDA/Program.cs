using System;
using System.Text.Json;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AbstractGestionnaireNombreAleatoire gestionnaireNombreAleatoire = Factory.CreerGestionnaireNombreAleatoire();

            AbstractCalculDesCoups calculDesCoups = Factory.CreerCalculDesCoups();
            Joueur joueur = new Joueur();
            AbstractGestionnaireSauvegarde gestionnaireSauvegarde = Factory.CreerGestionnaireSauvegarde();

            AbstractGestionnaireJeu gestionnaireJeu = Factory.CreerGestionnaireJeu(gestionnaireNombreAleatoire, calculDesCoups, joueur, gestionnaireSauvegarde);

            gestionnaireJeu.DeroulementDuProgramme();
        }
    }
}