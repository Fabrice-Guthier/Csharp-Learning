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
            TpCsv();
            TpCsvLanguageManager();

            // Et si vous voulez, vous pouvez commencer à essayer de trifouiller le fichier XML que je vous ai mis sur le Drive et/ou les fichiers JSON du site Json Example

        }

        public static void TpCsv()
        {
            // Jeu de Tri :
            // Calculer la moyenne des scores et des successRates (puis, dans un second temps, en ignorant les scores de 0)

            // Constantes pour le fichier CSV
            const char SEPARATOR = ';';
            const int SUCESS_RATE_COLLUMN = 2;
            const int SCORE_COLLUMN = 3;
            // Nom du fichier CSV contenant les scores
            string fileName = "ScoresGOT.csv";
            // Chemin d'accès au fichier CSV
            string path = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\" + fileName;

            // Lire toutes les lignes du fichier CSV à partir d'un tableau de string
            string[] lines = File.ReadAllLines(path);
            // Initialiser la somme des successRates
            int sumSuccessRate = 0;
            // Initialiser la somme des scores
            int sumScore = 0;
            int lineSuccessAt0 = 0;
            int lineScoreAt0 = 0;
            // Ignorer la première ligne (en-tête)
            foreach (string line in lines)
            {
                // Diviser la ligne en cellules
                string[] cells = line.Split(SEPARATOR);

                // Initialiser la variable de succès
                int success = 0;
                // Vérifier si la cellule contient un succès valide
                if (cells.Length >= 4 && int.TryParse(cells[SUCESS_RATE_COLLUMN], out success))
                {
                    if (success == 0)
                    {
                        // Ignorer les scores de 0
                        lineSuccessAt0++;
                        continue;
                    }
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
                float averageSuccess = (float)sumSuccessRate / ((lines.Length - lineSuccessAt0) - 1);
                Console.WriteLine($"La moyenne des successRates est : {averageSuccess}");
            }

            Console.WriteLine();

            // Parcourir à nouveau les lignes pour calculer les scores
            foreach (string line in lines)
            {
                // Diviser la ligne en cellules
                string[] cells = line.Split(SEPARATOR);

                // Initialiser la variable de score
                int score = 0;
                // Vérifier si la cellule contient un score valide
                if (cells.Length >= 4 && int.TryParse(cells[SCORE_COLLUMN], out score))
                {
                    if (score == 0)
                    {
                        // Ignorer les scores de 0
                        lineScoreAt0++;
                        continue;
                    }
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
                float averageScore = (float)sumScore / ((lines.Length - lineScoreAt0) - 1);
                Console.WriteLine($"La moyenne des scores est : {averageScore}");
            }
        }

        public static void TpCsvLanguageManager()
        {
            // Définir le mot-clé à traduire
            string keyWord = "Mat19";
            // Sélectionner la langue
            string SelectedLanguage = "French";
            // Appeler la méthode SelectLanguage avec la langue spécifiée
            LanguageManager.SelectLanguage(SelectedLanguage);
            // Appeler la méthode GetLanguage avec le mot-clé spécifié
            string translation = LanguageManager.GetLanguage(keyWord);
            // Afficher la traduction
            Console.WriteLine($"La traduction de {keyWord} en {SelectedLanguage} est : {translation}");
            // Changer la langue
            LanguageManager.GetLanguage(keyWord);
        }
    }
}
