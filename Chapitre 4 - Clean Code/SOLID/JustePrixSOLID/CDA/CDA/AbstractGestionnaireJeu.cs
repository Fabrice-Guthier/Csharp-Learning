namespace CDA
{
    public abstract class AbstractGestionnaireJeu
    {
        public CalculDesCoups CalculDesCoups { get; set; }
        public GestionnaireNombreAleatoire GestionnaireNombreAleatoire { get; set; }
        public GestionnaireSauvegarde GestionnaireSauvegarde { get; set; }
        public Joueur Joueur { get; set; }

        public abstract void DeroulementDuProgramme();
        public abstract void Partie();
        public abstract void VerificationMeilleurScore();
        public abstract void VerifierSiCEstMoins(int nombreEntre);
        public abstract void VerifierSiCEstPlus(int nombreEntre);
        public abstract void VerifierSiCEstVictoire(int nombreEntre);
    }
}