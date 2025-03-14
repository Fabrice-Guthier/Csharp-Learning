using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpPenduKata_1002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // choisir un mot au hasard dans une liste, avec la fonction random \/
            // lister toutes les lettres de l'alphabet \/
            // faire la fonction qui va comparer les lettres du mot avec celles de la liste
            // faire un comptage du nombre de lettres à faire afficher\/
            // afficher un charactère spécial à la place\/
            // afficher le nombre de coups ratés
            // lister les variables nécessaires pour le programme \/
            // faire la boucle while pour que les 2 joueurs jouent à tour de rôle \/


            List<char> listeLettresTentatives = new List<char>() {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ç', 'é', 'è', 'ê', 'î'};

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
            int nombreEssais = 0;
            string[] lettreTrouvee;

            Console.WriteLine("C'est parti pour un petit jeu du pendu.");

            Console.WriteLine("Entres le nom du joueur 1 :");
            joueur1 = Console.ReadLine();

            Console.WriteLine("Entres le nom du joueur 2:");
            joueur2 = Console.ReadLine();

            Random aleatoire = new Random();
            int indexMotAleatoire = aleatoire.Next(0, listeMotsPendu.Count);

            string motAleatoire = listeMotsPendu[indexMotAleatoire];

            Console.Clear();
            int tailleMot = motAleatoire.Length;

            //foreach (char c in motAleatoire)
            //{
            //    Console.Write('*');
            //}
            Console.WriteLine(motAleatoire);
            lettreTrouvee = new string[tailleMot];

            Console.WriteLine();

            do
            {
                Console.WriteLine(joueur2 + " , proposer une et une seule lettre :");
                lettre = Console.ReadLine();
            }
            while (lettre.Count() == 1 && lettre[0] >= 'a' && lettre[0] <= 'z');
            {
                for (int i = 0; i < tailleMot; i++)
                {
                    if (lettreTrouvee[i] == lettre)
                    {
                        Console.WriteLine(lettre);
                    }
                    else
                    {
                        Console.Write("*");
                    }

                }
                Console.WriteLine(joueur2 + "Proposer une et une seule lettre");
                nombreEssais++;
                Console.WriteLine(nombreEssais);
                Console.ReadLine();
            }
            
            Console.ReadLine();
        }


    }
}
