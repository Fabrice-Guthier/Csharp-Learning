using CDA.SystemeDeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Abstract
{
    abstract class AbstractGestionnaireAffichage
    {
        public static void MessageIntroduction()
        {
            Console.WriteLine("Quel est le nombre mystere ? ");
        }

        public static void MessagePlus()
        {
            Console.WriteLine("C'est plus !");
        }

        public static void MessageMoins()
        {
            Console.WriteLine("C'est moins !");
        }

        public static void MessageVictoire()
        {
            Console.WriteLine("C'est gagné !");
        }

        public static void MessageDeTriche(int nombreAleatoire)
        {
            Console.WriteLine(nombreAleatoire);
        }

        public static void MessageNombreDeCoupsFinal(int nombreDeCoups)
        {
            Console.WriteLine("Fin du jeu ! Vous avez trouvé en " + nombreDeCoups + " coups");
        }

        public static void MessageChoixDeLaDifficulte()
        {
            Console.WriteLine("Choisissez un mode de difficulté :\n" +
                    "1 : chiffre entre 1 et 100\n" +
                    "2 : chiffre entre 1 et 1000\n" +
                    "3 : chiffre entre 1 et 10000");
        }

        public static void MessageRejouer()
        {
            Console.WriteLine("Voulez-vous rejouer ? Dîtes oui si vous voulez rejouer : ");
        }

        public static void MessageFinDeProgramme()
        {
            Console.WriteLine("Ok dégage !");
        }

        public static void AffichageTableauDesScores(TableauDesScores tableauDesScores)
        {
            Console.WriteLine("Le tableau des scores actuel est : \n" + tableauDesScores);
        }

        public static void DemanderPseudonyme()
        {
            Console.WriteLine("Quel est ton pseudo ?");
        }
    }
}
