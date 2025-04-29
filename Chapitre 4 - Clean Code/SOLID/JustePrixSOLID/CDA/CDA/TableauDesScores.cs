using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class TableauDesScores
    {
        public List<ScorePersonnel> ScoresPersonnels { get; set; }
        const int LIMITE_DU_TABLEAU = 5;

        public TableauDesScores()
        {
            ScoresPersonnels = new List<ScorePersonnel>();

            ScoresPersonnels.Add(new ScorePersonnel("AAA"));
            ScoresPersonnels.Add(new ScorePersonnel("BBB"));
            ScoresPersonnels.Add(new ScorePersonnel("CCC"));
            ScoresPersonnels.Add(new ScorePersonnel("DDD"));
            ScoresPersonnels.Add(new ScorePersonnel("EEE"));
        }

        public override string ToString()
        {
            string aRenvoyer = "";

            foreach (ScorePersonnel scorePersonnel in ScoresPersonnels)
            {
                aRenvoyer += scorePersonnel + "\n";
            }

            return aRenvoyer;
        }

        public void SupprimerScoresApresLaLimite()
        {
            //On supprime tous les scores au delà du 5ème
            for (int i = ScoresPersonnels.Count - 1; i >= 0; i--)
            {
                if (i > LIMITE_DU_TABLEAU - 1)
                {
                    ScoresPersonnels.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
