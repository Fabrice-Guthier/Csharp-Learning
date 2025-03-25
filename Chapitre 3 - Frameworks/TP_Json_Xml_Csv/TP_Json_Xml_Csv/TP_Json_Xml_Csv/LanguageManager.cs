using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_Json_Xml_Csv
{
    public static class LanguageManager
    {
        // Propriété pour stocker la langue sélectionnée
        public static string Language { get; set; }
        const char SEPARATOR = ';';
        const int KEYCOLUMN = 0;
        const int FRENCHCOLUMN = 2;
        const int ENGLISHCOLUMN = 3;
        // Méthode pour obtenir la traduction d'un mot clé
        public static string GetLanguage(string key)
        {
            // Nom du fichier de traduction
            string fileTranslateName = "LanguageMats.csv";
            // Chemin d'accès au fichier de traduction
            string path = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\" + fileTranslateName;

            // Lire toutes les lignes du fichier de traduction
            string[] lines = File.ReadAllLines(path);
            // Variable pour stocker le mot traduit
            string word = "";

            // Parcourir chaque ligne du fichier de traduction
            foreach (string line in lines)
            {
                // Diviser la ligne en cellules séparées par des points-virgules
                string[] cells = line.Split(SEPARATOR);
                // Vérifier si la première cellule correspond au mot clé
                if (cells[KEYCOLUMN] == key)
                {
                    // Si la langue sélectionnée est le français, prendre la troisième cellule
                    if (Language == "French")
                    {
                        word = cells[FRENCHCOLUMN];
                    }
                    // Si la langue sélectionnée est l'anglais, prendre la quatrième cellule
                    else if (Language == "English")
                    {
                        word = cells[ENGLISHCOLUMN];
                    }
                    // Sortir de la boucle une fois le mot trouvé
                    break;
                }
            }
            // Retourner le mot traduit
            return word;
        }

        // Méthode pour sélectionner la langue
        public static void SelectLanguage(string language)
        {
            Language = language;
        }
    }
}
