using CDA.Gestionnaires;
using CDA.SystemeDeJeu;
using System;
using System.Text.Json;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GestionnaireNombreAleatoire gestionnaireNombreAleatoire = new GestionnaireNombreAleatoire();

            CalculDesCoups calculDesCoups = new CalculDesCoups();
            Joueur joueur = new Joueur();
            GestionnaireSauvegarde gestionnaireSauvegarde = new GestionnaireSauvegarde();

            GestionnaireJeu gestionnaireJeu = new GestionnaireJeu(gestionnaireNombreAleatoire, calculDesCoups, joueur, gestionnaireSauvegarde);

            gestionnaireJeu.DeroulementDuProgramme();
        }
    }
}