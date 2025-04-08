using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;



namespace High_Scores_In_Json
{
    public class Scores
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Scores(string name = "", int score = 0)
        {
            Name = name;
            Score = score;
        }
        /// <summary>
        /// Méthode pour sauvegarder les scores dans un fichier JSON
        /// </summary>
        /// <param name="newScore">appel de la classe score</param>
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

        // Méthode pour charger, trier et afficher les scores depuis un fichier JSON
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

                    // Trier la liste des scores par ordre croissant
                    scoresList = scoresList.OrderBy(score => score.Score).ToList();

                    // Afficher chaque score dans la console
                    foreach (var score in scoresList)
                    {
                        Console.WriteLine("Name: " + score.Name + "  Score: " + score.Score);
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
