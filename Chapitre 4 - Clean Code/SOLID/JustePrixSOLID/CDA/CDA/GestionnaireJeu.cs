using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class GestionnaireJeu : AbstractGestionnaireJeu
    {
        public GestionnaireJeu(GestionnaireNombreAleatoire gestionnaireNombreAleatoire, CalculDesCoups calculDesCoups, Joueur joueur, GestionnaireSauvegarde gestionnaireSauvegarde)
        {
            GestionnaireNombreAleatoire = gestionnaireNombreAleatoire ?? throw new ArgumentNullException(nameof(gestionnaireNombreAleatoire));
            CalculDesCoups = calculDesCoups;
            Joueur = joueur;
            GestionnaireSauvegarde = gestionnaireSauvegarde;
        }

        public override void DeroulementDuProgramme()
        {
            string entreeRejouer = "";

            do
            {
                Partie();

                GestionnaireAffichage.MessageRejouer();
                entreeRejouer = GestionnaireEntrees.ObtenirChaineDeCaractere();

            } while (entreeRejouer == "oui");

            GestionnaireAffichage.MessageFinDeProgramme();
        }

        public override void Partie()
        {
            int nombreEntre = -1;
            CalculDesCoups.NombreDeCoups = 0;
            GestionnaireNombreAleatoire.GenererNombreAleatoire();

            GestionnaireAffichage.MessageDeTriche(GestionnaireNombreAleatoire.NombreAleatoire);

            do
            {
                CalculDesCoups.NombreDeCoups++;

                GestionnaireAffichage.MessageIntroduction();

                nombreEntre = GestionnaireEntrees.ObtenirNombre();

                VerifierSiCEstMoins(nombreEntre);
                VerifierSiCEstPlus(nombreEntre);
                VerifierSiCEstVictoire(nombreEntre);

            } while (nombreEntre != GestionnaireNombreAleatoire.NombreAleatoire);

            VerificationMeilleurScore();

            GestionnaireAffichage.MessageNombreDeCoupsFinal(CalculDesCoups.NombreDeCoups);
        }

        public override void VerifierSiCEstMoins(int nombreEntre)
        {
            if (nombreEntre > GestionnaireNombreAleatoire.NombreAleatoire)
            {
                GestionnaireAffichage.MessageMoins();
            }
        }

        public override void VerifierSiCEstPlus(int nombreEntre)
        {
            if (nombreEntre < GestionnaireNombreAleatoire.NombreAleatoire)
            {
                GestionnaireAffichage.MessagePlus();
            }
        }

        public override void VerifierSiCEstVictoire(int nombreEntre)
        {
            if (nombreEntre == GestionnaireNombreAleatoire.NombreAleatoire)
            {
                GestionnaireAffichage.MessageVictoire();
            }
        }

        public override void VerificationMeilleurScore()
        {
            //Vérification du meilleur score
            int nombresDeScores = GestionnaireSauvegarde.TableauDesScores.ScoresPersonnels.Count;
            ScorePersonnel scoreLePlusBasDuTableauDesScores = GestionnaireSauvegarde.TableauDesScores.ScoresPersonnels[nombresDeScores - 1];
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
