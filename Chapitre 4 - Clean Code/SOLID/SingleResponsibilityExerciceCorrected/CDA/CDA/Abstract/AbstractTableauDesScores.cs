using CDA.SystemeDeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Abstract
{
    abstract class AbstractTableauDesScores
    {
        public List<AbstractScorePersonnel> ScoresPersonnels { get; set; }
        const int LIMITE_DU_TABLEAU = 5;

        public AbstractTableauDesScores()
        {
            ScoresPersonnels = new List<AbstractScorePersonnel>();

            ScoresPersonnels.Add(new ScorePersonnel("AAA"));
            ScoresPersonnels.Add(new ScorePersonnel("BBB"));
            ScoresPersonnels.Add(new ScorePersonnel("CCC"));
            ScoresPersonnels.Add(new ScorePersonnel("DDD"));
            ScoresPersonnels.Add(new ScorePersonnel("EEE"));
        }

        public override string ToString()
        {
            string aRenvoyer = "";

            foreach (AbstractScorePersonnel scorePersonnel in ScoresPersonnels)
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
