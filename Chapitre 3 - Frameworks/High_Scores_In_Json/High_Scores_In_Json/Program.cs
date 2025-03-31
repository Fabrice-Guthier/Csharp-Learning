using CefSharp.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace High_Scores_In_Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Charger les scores existants depuis le fichier JSON
            LoadScores();

            // Demander le nom du joueur
            Console.WriteLine("Saisissez votre nom :");
            string playerName = Console.ReadLine();

            // Créer une nouvelle instance de jeu et démarrer le jeu
            Game game = new Game();
            game.Play();

            // Créer une nouvelle instance de Scores pour enregistrer le score du joueur
            Scores score = new Scores();
            score.Name = playerName; // Lire le nom du joueur entré dans la console précédemment
            score.Score = game.nombreDeCoups; // Assigner le score du jeu au score du joueur

            // Sauvegarder le nouveau score dans le fichier JSON
            SaveScores(score);
        }

        // Méthode pour sauvegarder les scores dans un fichier JSON
        internal static void SaveScores(Scores newScore)
        {
            string jsonFileName = "scores.json";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\" + jsonFileName;

            List<Scores> scoresList = new List<Scores>();

            // Vérifier si le fichier JSON existe
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    // Désérialiser le contenu du fichier JSON en une liste de scores
                    scoresList = JsonSerializer.Deserialize<List<Scores>>(jsonString);
                }
            }

            // Ajouter le nouveau score à la liste des scores
            scoresList.Add(newScore);

            // Sérialiser la liste mise à jour des scores en une chaîne JSON
            string updatedJsonString = JsonSerializer.Serialize(scoresList);

            // Écrire la chaîne JSON mise à jour dans le fichier
            File.WriteAllText(path, updatedJsonString);
        }

        // Méthode pour charger et afficher les scores depuis un fichier JSON
        internal static void LoadScores()
        {
            string jsonFileName = "scores.json";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\" + jsonFileName;

            // Vérifier si le fichier JSON existe
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    // Désérialiser le contenu du fichier JSON en une liste de scores
                    List<Scores> scoresList = JsonSerializer.Deserialize<List<Scores>>(jsonString);

                    // Afficher chaque score dans la console
                    foreach (var score in scoresList)
                    {
                        Console.WriteLine("Name: " + score.Name);
                        Console.WriteLine("Score: " + score.Score);
                    }
                }
            }
            else
            {
                // Afficher un message si aucun score n'est trouvé
                Console.WriteLine("No scores found.");
            }
        }
    }
}