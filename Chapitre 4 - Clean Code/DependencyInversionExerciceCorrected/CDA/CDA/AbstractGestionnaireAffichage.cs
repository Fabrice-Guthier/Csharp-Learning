namespace CDA
{
    public abstract class AbstractGestionnaireAffichage
    {
        public abstract void AffichageTableauDesScores(TableauDesScores tableauDesScores);
        public abstract void DemanderPseudonyme();
        public abstract void MessageChoixDeLaDifficulte();
        public abstract void MessageDeTriche(int nombreAleatoire);
        public abstract void MessageFinDeProgramme();
        public abstract void MessageIntroduction();
        public abstract void MessageMoins();

        public void MessageNombreDeCoupsFinal(int nombreDeCoups)
        {
            Console.WriteLine("Fin du jeu ! Vous avez trouvé en " + nombreDeCoups + " coups");
        }

        public abstract void MessagePlus();
        public abstract void MessageRejouer();
        public abstract void MessageVictoire();
    }
}