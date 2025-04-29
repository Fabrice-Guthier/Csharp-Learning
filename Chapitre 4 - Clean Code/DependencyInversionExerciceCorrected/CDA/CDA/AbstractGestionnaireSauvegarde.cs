namespace CDA
{
    public abstract class AbstractGestionnaireSauvegarde
    {
        string chemin;
        public TableauDesScores TableauDesScores { get; set; }

        public abstract void ChargementTableauDesScores();
        public abstract void InitialisationChemin();
        public abstract void SauvegardeTableauDesScores();
    }
}