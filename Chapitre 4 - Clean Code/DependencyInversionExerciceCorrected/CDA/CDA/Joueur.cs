using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Joueur : AbstractJoueur
    {
        public Joueur()
        {
            string pseudonyme = InitialiserPseudonyme();

            ScorePersonnel = Factory.CreerScorePersonnel(pseudonyme);
        }

        public override string InitialiserPseudonyme()
        {
            AbstractGestionnaireAffichage.DemanderPseudonyme();

            return AbstractGestionnaireEntrees.ObtenirChaineDeCaractere();
        }
    }
}
