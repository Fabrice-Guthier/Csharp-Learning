using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class GestionnaireJeu : AbstractGestionnaireJeu
    {
        public GestionnaireJeu() : base()
        {
        }

        public override void DeroulementDuProgramme()
        {
            string entreeRejouer = "";

            do
            {
                Partie();

                GestionnaireAffichage.MessageRejouer();
                entreeRejouer = GestionnaireEntrees.ObtenirChaineDeCaractere()?.ToLower();

            } while (entreeRejouer == "oui");

            GestionnaireAffichage.MessageFinDeProgramme();
        }

        public override void Partie()
        {
            int nombreEntre = -1;
            CalculDesCoups.NombreDeCoups = 0;
            GestionnaireNombreAleatoire.GenererNombreAleatoire();

            AbstractGestionnaireAffichage.MessageDeTriche(GestionnaireNombreAleatoire.NombreAleatoire);

            do
            {
                CalculDesCoups.NombreDeCoups++;

                AbstractGestionnaireAffichage.MessageIntroduction();

                nombreEntre = AbstractGestionnaireEntrees.ObtenirNombre();

                VerifierSiCEstMoins(nombreEntre);
                VerifierSiCEstPlus(nombreEntre);
                VerifierSiCEstVictoire(nombreEntre);

            } while (nombreEntre != GestionnaireNombreAleatoire.NombreAleatoire);

            VerificationMeilleurScore();

            AbstractGestionnaireAffichage.MessageNombreDeCoupsFinal(CalculDesCoups.NombreDeCoups);
        }

        public override void VerifierSiCEstMoins(int nombreEntre)
        {
            if (nombreEntre > GestionnaireNombreAleatoire.NombreAleatoire)
            {
                AbstractGestionnaireAffichage.MessageMoins();
            }
        }

        public override void VerifierSiCEstPlus(int nombreEntre)
        {
            if (nombreEntre < GestionnaireNombreAleatoire.NombreAleatoire)
            {
                AbstractGestionnaireAffichage.MessagePlus();
            }
        }

        public override void VerifierSiCEstVictoire(int nombreEntre)
        {
            if (nombreEntre == GestionnaireNombreAleatoire.NombreAleatoire)
            {
                AbstractGestionnaireAffichage.MessageVictoire();
            }
        }

        public override void VerificationMeilleurScore()
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
