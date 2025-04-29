namespace CDA
{
    public abstract class AbstractGestionnaireJeu
    {
        protected AbstractGestionnaireJeu()
        {
        }

        public AbstractGestionnaireNombreAleatoire GestionnaireNombreAleatoire { get; set; }
        public GestionnaireSauvegarde GestionnaireSauvegarde { get; set; }
        public AbstractCalculDesCoups CalculDesCoups { get; set; }
        public Joueur Joueur { get; set; }


        public abstract void DeroulementDuProgramme();
        public abstract void Partie();
        public abstract void VerificationMeilleurScore();
        public abstract void VerifierSiCEstMoins(int nombreEntre);
        public abstract void VerifierSiCEstPlus(int nombreEntre);
        public abstract void VerifierSiCEstVictoire(int nombreEntre);
    }
}