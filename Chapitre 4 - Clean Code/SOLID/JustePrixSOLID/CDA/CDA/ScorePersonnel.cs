using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class ScorePersonnel
    {
        public int Score { get; set; }
        public string Pseudonyme { get; set; }

        public ScorePersonnel(int score, string pseudonyme)
        {
            Score = score;
            Pseudonyme = pseudonyme ?? throw new ArgumentNullException(nameof(pseudonyme));
        }

        public ScorePersonnel()
        {

        }

        public ScorePersonnel(string pseudonyme)
        {
            Score = 20000;
            Pseudonyme = pseudonyme ?? throw new ArgumentNullException(nameof(pseudonyme));
        }

        public override string ToString()
        {
            return Pseudonyme + " : " + Score;
        }
    }
}
