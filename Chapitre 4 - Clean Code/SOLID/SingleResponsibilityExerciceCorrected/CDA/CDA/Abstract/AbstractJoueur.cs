using CDA.Gestionnaires;
using CDA.SystemeDeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Abstract
{
    abstract class AbstractJoueur
    {
        public ScorePersonnel ScorePersonnel { get; set; }

        public AbstractJoueur()
        {
            string pseudonyme = InitialiserPseudonyme();

            ScorePersonnel = new ScorePersonnel(pseudonyme);
        }

        public string InitialiserPseudonyme()
        {
            AbstractGestionnaireAffichage.DemanderPseudonyme();

            return AbstractGestionnaireEntree.ObtenirChaineDeCaractere();
        }
    }
}
