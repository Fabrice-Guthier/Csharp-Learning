using System;
using System.Collections.Generic;
using System.Linq;

namespace tpPenduKata_1002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> listeLettresTentatives = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ç', 'é', 'è', 'ê', 'î' };

            List<string> listeMotsPendu = new List<string>()
            {
                "balançoire", "chocolaterie","émerveillement", "fantasmagorie", "hypnotisant", "incroyable", "jonglerie", "kaléidoscope",
                "ludothèque", "métamorphose", "onirique", "pétillant", "quotidiennement", "rêverie", "spontanément", "tourbillon",
                "universellement", "volontairement", "waggon", "zéphyre"
            };

            string lettre;
            int longueurMot;
            string[] masque;
            string joueur1;
            string joueur2;
            string joueurEnCours;
            int nombreEssaisMax = 10;
            int nombreEssais = 0;
            string[] lettreTrouvee;
            bool motTrouve;

            Random aleatoire = new Random(); // Une seule instance de Random

            Console.WriteLine("C'est parti pour un petit jeu du pendu.");

            Console.WriteLine("Entrez le nom du joueur 1 :");
            joueur1 = Console.ReadLine();

            Console.WriteLine("Entrez le nom du joueur 2:");
            joueur2 = Console.ReadLine();

            while (true)
            {
                int indexMotAleatoire = aleatoire.Next(0, listeMotsPendu.Count);
                string motAleatoire = listeMotsPendu[indexMotAleatoire];

                Console.Clear();
                longueurMot = motAleatoire.Length;
                masque = new string[longueurMot];
                lettreTrouvee = new string[longueurMot];
                nombreEssais = 0;
                motTrouve = false;
                joueurEnCours = joueur1;

                Console.WriteLine(motAleatoire); // Pour tricher ;)

                // Initialisation du masque
                for (int i = 0; i < longueurMot; i++)
                {
                    masque[i] = "*";
                }

                while (!motTrouve && nombreEssais < nombreEssaisMax)
                {
                    Console.Clear();
                    Console.WriteLine("Joueur en cours : " + joueurEnCours);
                    Console.WriteLine("Nombre d'essais restants : " + (nombreEssaisMax - nombreEssais));
                    AfficherMasque(masque);

                    Console.WriteLine("Proposez une lettre :");
                    lettre = Console.ReadLine();

                    if (listeLettresTentatives.Contains(char.Parse(lettre)))
                    {
                        bool lettreDejaDevinee = false;
                        for (int i = 0; i < longueurMot; i++)
                        {
                            if (lettreTrouvee[i] == lettre)
                            {
                                lettreDejaDevinee = true;
                                break;
                            }
                        }
                        if (lettreDejaDevinee)
                        {
                            Console.WriteLine("Lettre déjà devinée !");
                        }
                        else
                        {
                            bool lettreTrouveeCeTour = false;
                            for (int i = 0; i < longueurMot; i++)
                            {
                                if (motAleatoire[i].ToString() == lettre)
                                {
                                    lettreTrouvee[i] = lettre;
                                    masque[i] = lettre;
                                    lettreTrouveeCeTour = true;
                                }
                            }
                            if (!lettreTrouveeCeTour)
                            {
                                nombreEssais++;
                                Console.WriteLine("Mauvaise lettre !");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Veuillez entrer une lettre valide.");
                    }

                    // Vérification si le mot est trouvé
                    if (masque.All(x => x != "*"))
                    {
                        motTrouve = true;
                        Console.WriteLine("Bravo " + joueurEnCours + " ! Vous avez trouvé le mot : " + motAleatoire);
                    }
                    else
                    {
                        // Changement de joueur
                        joueurEnCours = (joueurEnCours == joueur1) ? joueur2 : joueur1;
                    }
                }

                if (!motTrouve)
                {
                    Console.WriteLine("Dommage " + joueurEnCours + " ! Vous n'avez pas trouvé le mot : " + motAleatoire);
                }

                Console.WriteLine("Voulez-vous rejouer ? (o/n)");
                string reponse = Console.ReadLine();
                if (reponse.ToLower() != "o")
                {
                    break;
                }
            }
        }

        static void AfficherMasque(string[] masque)
        {
            foreach (string c in masque)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}