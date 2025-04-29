namespace CDA
{
    public abstract class AbstractTableauDesScores
    {
        public const int LIMITE_DU_TABLEAU = 5;
        public List<ScorePersonnel> ScoresPersonnels { get; set; }

        public abstract void SupprimerScoresApresLaLimite();
        public abstract override string ToString();
    }
}