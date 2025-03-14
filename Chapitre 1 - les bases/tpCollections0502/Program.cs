using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpCollections0502
{
    internal class Program
    {
        //lv1
        static void AfficherUtilisateurs(List<string> utilisateurs)
        {
            foreach (string u in utilisateurs)
            {
                Console.WriteLine(u);
            }
        }
        //

        static void Main(string[] args)
        {

            //lv1
            List<string> utilisateurs = new List<string>();

            utilisateurs.Add("Fabrice");
            utilisateurs.Add("Émilie");
            utilisateurs.Add("Christopher");
            utilisateurs.Add("Michel");

            Console.WriteLine("Utilisateurs initiaux:");
            AfficherUtilisateurs(utilisateurs); // Méthode pour afficher la liste

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("\nQue voulez-vous faire ? (1-- connecter/2-- deconnecter/3-- quitter)");
                string action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "1":
                        Console.WriteLine("Nom de l'utilisateur à connecter :");
                        string utilisateurAConnecter = Console.ReadLine();
                        if (!utilisateurs.Contains(utilisateurAConnecter))
                        {
                            utilisateurs.Add(utilisateurAConnecter);
                            Console.WriteLine(utilisateurAConnecter + " est maintenant connecté.");
                        }
                        else
                        {
                            Console.WriteLine(utilisateurAConnecter + " est déjà connecté.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Nom de l'utilisateur à déconnecter :");
                        string utilisateurADeconnecter = Console.ReadLine();
                        if (utilisateurs.Contains(utilisateurADeconnecter))
                        {
                            utilisateurs.Remove(utilisateurADeconnecter);
                            Console.WriteLine(utilisateurADeconnecter + " a été déconnecté.");
                        }
                        else
                        {
                            Console.WriteLine(utilisateurADeconnecter + " n'est pas connecté.");
                        }
                        break;

                    case "3":
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Action invalide.");
                        break;
                }

                Console.WriteLine("\nListe des utilisateurs :");
                AfficherUtilisateurs(utilisateurs);
            }
            Console.WriteLine("Fin du programme.");
            //



            Console.ReadLine();
        }
    }
}
