using CDA.Gestionnaires;
using CDA.SystemeDeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Abstract
{
    abstract class AbstractGestionnaireJeu
    {
        public AbstractGestionnaireNombreAleatoire GestionnaireNombreAleatoire { get; set; }
        public AbstractGestionnaireSauvegarde GestionnaireSauvegarde { get; set; }
        public AbstractCalculDesCoups CalculDesCoups { get; set; }
        public AbstractJoueur Joueur { get; set; }


        public AbstractGestionnaireJeu(AbstractGestionnaireNombreAleatoire gestionnaireNombreAleatoire, AbstractCalculDesCoups calculDesCoups, AbstractJoueur joueur, AbstractGestionnaireSauvegarde gestionnaireSauvegarde)
        {
            GestionnaireNombreAleatoire = gestionnaireNombreAleatoire ?? throw new ArgumentNullException(nameof(gestionnaireNombreAleatoire));
            CalculDesCoups = calculDesCoups;
            Joueur = joueur;
            GestionnaireSauvegarde = gestionnaireSauvegarde;
        }

        public void DeroulementDuProgramme()
        {
            string entreeRejouer = "";

            do
            {
                Partie();

                AbstractGestionnaireAffichage.MessageRejouer();
                entreeRejouer = AbstractGestionnaireEntree.ObtenirChaineDeCaractere();

            } while (entreeRejouer == "oui");

            AbstractGestionnaireAffichage.MessageFinDeProgramme();
        }

        public void Partie()
        {
            int nombreEntre = -1;
            CalculDesCoups.NombreDeCoups = 0;
            GestionnaireNombreAleatoire.GenererNombreAleatoire();

            AbstractGestionnaireAffichage.MessageDeTriche(GestionnaireNombreAleatoire.NombreAleatoire);

            do
            {
                CalculDesCoups.NombreDeCoups++;

                AbstractGestionnaireAffichage.MessageIntroduction();

                nombreEntre = AbstractGestionnaireEntree.ObtenirNombre();

                VerifierSiCEstMoins(nombreEntre);
                VerifierSiCEstPlus(nombreEntre);
                VerifierSiCEstVictoire(nombreEntre);

            } while (nombreEntre != GestionnaireNombreAleatoire.NombreAleatoire);

            VerificationMeilleurScore();

            AbstractGestionnaireAffichage.MessageNombreDeCoupsFinal(CalculDesCoups.NombreDeCoups);
        }

        public void VerifierSiCEstMoins(int nombreEntre)
        {
            if (nombreEntre > GestionnaireNombreAleatoire.NombreAleatoire)
            {
                AbstractGestionnaireAffichage.MessageMoins();
            }
        }

        public void VerifierSiCEstPlus(int nombreEntre)
        {
            if (nombreEntre < GestionnaireNombreAleatoire.NombreAleatoire)
            {
                AbstractGestionnaireAffichage.MessagePlus();
            }
        }

        public void VerifierSiCEstVictoire(int nombreEntre)
        {
            if (nombreEntre == GestionnaireNombreAleatoire.NombreAleatoire)
            {
                AbstractGestionnaireAffichage.MessageVictoire();
            }
        }

        public void VerificationMeilleurScore()
        {
            //Vérification du meilleur score
            int nombresDeScores = GestionnaireSauvegarde.TableauDesScores.ScoresPersonnels.Count;
            AbstractScorePersonnel scoreLePlusBasDuTableauDesScores = GestionnaireSauvegarde.TableauDesScores.ScoresPersonnels[nombresDeScores - 1];
            int nombreDeCoups = CalculDesCoups.NombreDeCoups;

            if (nombreDeCoups < scoreLePlusBasDuTableauDesScores.Score)
            {
                Joueur.ScorePersonnel.Score = nombreDeCoups;

                Console.WriteLine("Nouveau meilleur score : " + Joueur.ScorePersonnel);

                GestionnaireSauvegarde.TableauDesScores.ScoresPersonnels.Add(Joueur.ScorePersonnel);

                GestionnaireSauvegarde.TableauDesScores.ScoresPersonnels = GestionnaireSauvegarde.TableauDesScores.ScoresPersonnels.OrderBy(scorePerso =>
                scorePerso.Score).ToList();

                GestionnaireSauvegarde.TableauDesScores.SupprimerScoresApresLaLimite();

                GestionnaireSauvegarde.SauvegardeTableauDesScores();
            }
        }
    }
}
