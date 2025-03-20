using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace TP_Json_Xml_Csv
{
    class Program
    {
        static void Main(string[] args)
        {
            // Jeu de Tri :
            // Calculer la moyenne des scores et des successRates (puis, dans un second temps, en ignorant les scores de 0)

            // Nom du fichier CSV contenant les scores
            string fileName = "ScoresGOT.csv";
            // Chemin d'accès au fichier CSV
            string path = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\" + fileName;

            // Lire toutes les lignes du fichier CSV
            string[] lines = File.ReadAllLines(path);
            // Initialiser la somme des successRates
            int sumSuccessRate = 0;
            // Initialiser la somme des scores
            int sumScore = 0;

            // Ignorer la première ligne (en-tête)
            foreach (string line in lines)
            {
                // Diviser la ligne en cellules
                string[] cells = line.Split(';');

                // Initialiser la variable de succès
                int success = 0;
                // Vérifier si la cellule contient un succès valide
                if (cells.Length >= 4 && int.TryParse(cells[2], out success))
                {
                    // Ajouter le succès à la somme des successRates
                    sumSuccessRate += success;
                }
            }
            // Afficher le total des succès
            Console.WriteLine($"Le total des succès est : {sumSuccessRate}");

            // Calculer et afficher la moyenne des scores si la taille du tableau est supérieure à 0
            if (lines.Length > 0)
            {
                // on passe temporairement par un float avec un cast pour éviter les divisions entières
                float averageSuccess = (float)sumSuccessRate / lines.Length;
                Console.WriteLine($"La moyenne des successRates est : {averageSuccess}");
            }

            Console.WriteLine();

            // Parcourir à nouveau les lignes pour calculer les scores
            foreach (string line in lines)
            {
                // Diviser la ligne en cellules
                string[] cells = line.Split(';');

                // Initialiser la variable de score
                int score = 0;
                // Vérifier si la cellule contient un score valide
                if (cells.Length >= 4 && int.TryParse(cells[3], out score))
                {
                    // Ajouter le score à la somme des scores
                    sumScore += score;
                }
            }
            // Afficher le total des scores
            Console.WriteLine($"Le total des scores est : {sumScore}");

            // Calculer et afficher la moyenne des scores si la taille du tableau est supérieure à 0
            if (lines.Length > 0)
            {
                // on passe temporairement par un float avec un cast pour éviter les divisions entières
                float averageScore = (float)sumScore / lines.Length;
                Console.WriteLine($"La moyenne des scores est : {averageScore}");
            }

            // Faire une classe statique LanguageManager qui convertit une clé de Mat en son nom dans le langage actuel

            // Et si vous voulez, vous pouvez commencer à essayer de trifouiller le fichier XML que je vous ai mis sur le Drive et/ou les fichiers JSON du site Json Example
        }
    }
}
