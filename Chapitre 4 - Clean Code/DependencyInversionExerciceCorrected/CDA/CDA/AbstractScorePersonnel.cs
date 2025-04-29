namespace CDA
{
    public abstract class AbstractScorePersonnel
    {
        public string Pseudonyme { get; set; }
        public int Score { get; set; }

        public abstract override string ToString();
    }
}