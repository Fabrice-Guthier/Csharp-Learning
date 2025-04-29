using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Joueur
    {
        public ScorePersonnel ScorePersonnel { get; set; }

        public Joueur()
        {
            string pseudonyme = InitialiserPseudonyme();

            ScorePersonnel = new ScorePersonnel(pseudonyme);
        }

        public string InitialiserPseudonyme()
        {
            GestionnaireAffichage.DemanderPseudonyme();

            return GestionnaireEntrees.ObtenirChaineDeCaractere();
        }
    }
}
