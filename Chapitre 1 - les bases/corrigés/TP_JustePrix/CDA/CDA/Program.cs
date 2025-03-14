using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random aleatoire = new Random();
            string entreeRejouer = "";

            do
            {
                Console.WriteLine("Choisissez un mode de difficulté :\n" +
                    "1 : chiffre entre 1 et 100\n" +
                    "2 : chiffre entre 1 et 1000\n" +
                    "3 : chiffre entre 1 et 10000");
                string entreeDifficulte = Console.ReadLine();
                int difficulte = int.Parse(entreeDifficulte);

                int nombreAleatoire = 0;
                int nombreMaximum = 101;
                int nombreDeCoups = 0;

                switch (difficulte)
                {
                    case 1:
                        nombreMaximum = 101;
                        break;
                    case 2:
                        nombreMaximum = 1001;
                        break;
                    case 3:
                        nombreMaximum = 10001;
                        break;
                    default:
                        nombreMaximum = 101;
                        break;
                }

                nombreAleatoire = aleatoire.Next(1, nombreMaximum);

                int nombreEntre = -1;

                Console.WriteLine(nombreAleatoire);

                do
                {
                    nombreDeCoups++;

                    Console.WriteLine("Quel est le nombre mystere ? ");
                    string entree = Console.ReadLine();
                    nombreEntre = int.Parse(entree);

                    if (nombreEntre > nombreAleatoire)
                    {
                        Console.WriteLine("C'est moins !");
                    }
                    else if (nombreEntre < nombreAleatoire)
                    {
                        Console.WriteLine("C'est plus !");
                    }
                    else
                    {
                        Console.WriteLine("C'est gagné !");
                    }
                } while (nombreEntre != nombreAleatoire);

                Console.WriteLine("Fin du jeu ! Vous avez trouvé en " + nombreDeCoups + " coups");

                Console.WriteLine("Voulez-vous rejouer ? Dîtes oui si vous voulez rejouer : ");
                entreeRejouer = Console.ReadLine();
            } while (entreeRejouer == "oui");

            Console.WriteLine("Ok dégage !");
        }
    }
}