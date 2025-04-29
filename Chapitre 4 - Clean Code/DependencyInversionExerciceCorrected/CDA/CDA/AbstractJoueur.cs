namespace CDA
{
    public abstract class AbstractJoueur
    {
        public ScorePersonnel ScorePersonnel { get; set; }

        public abstract string InitialiserPseudonyme();
    }
}