using CDA.Abstract;
using CDA.SystemeDeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Gestionnaires
{
    class GestionnaireJeu : AbstractGestionnaireJeu
    {
        public GestionnaireJeu(AbstractGestionnaireNombreAleatoire gestionnaireNombreAleatoire, AbstractCalculDesCoups calculDesCoups, AbstractJoueur joueur, AbstractGestionnaireSauvegarde gestionnaireSauvegarde) : base(gestionnaireNombreAleatoire, calculDesCoups, joueur, gestionnaireSauvegarde)
        {
        }
    }
}
