using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class GestionnaireAffichage : AbstractGestionnaireAffichage
    {
        public override void MessageIntroduction()
        {
            Console.WriteLine("Quel est le nombre mystere ? ");
        }

        public override void MessagePlus()
        {
            Console.WriteLine("C'est plus !");
        }

        public override void MessageMoins()
        {
            Console.WriteLine("C'est moins !");
        }

        public override void MessageVictoire()
        {
            Console.WriteLine("C'est gagné !");
        }

        public override void MessageDeTriche(int nombreAleatoire)
        {
            Console.WriteLine(nombreAleatoire);
        }

        public override void MessageChoixDeLaDifficulte()
        {
            Console.WriteLine("Choisissez un mode de difficulté :\n" +
                    "1 : chiffre entre 1 et 100\n" +
                    "2 : chiffre entre 1 et 1000\n" +
                    "3 : chiffre entre 1 et 10000");
        }

        public override void MessageRejouer()
        {
            Console.WriteLine("Voulez-vous rejouer ? Dîtes oui si vous voulez rejouer : ");
        }

        public override void MessageFinDeProgramme()
        {
            Console.WriteLine("Ok dégage !");
        }

        public override void AffichageTableauDesScores(TableauDesScores tableauDesScores)
        {
            Console.WriteLine("Le tableau des scores actuel est : \n" + tableauDesScores);
        }

        public override void DemanderPseudonyme()
        {
            Console.WriteLine("Quel est ton pseudo ?");
        }
    }
}
