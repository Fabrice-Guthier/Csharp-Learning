using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Chapitre_3_B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "Bear_Datas.csv";
            string outputFileName = "ours.csv";
            string inputCsvPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\" + inputFileName;
            string outputCsvPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\" + outputFileName;

            if (!File.Exists(inputCsvPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erreur : Le fichier d'entrée '{inputCsvPath}' n'a pas été trouvé.");
                Console.ResetColor();
                Console.WriteLine("Appuyez sur une touche pour quitter.");
                Console.ReadKey();
                return;
            }

            var inputConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Le fichier GBIF a une ligne d'en-tête
                Delimiter = ";", 
                MissingFieldFound = null, // Ignore les champs manquants dans la classe C#
                HeaderValidated = null,   // Ignore les en-têtes non mappés
            };

            // Configuration pour l'ÉCRITURE (choisir un délimiteur pour la sortie, ex: ';')
            var outputConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            Console.WriteLine($"Lecture du fichier d'entrée : {inputCsvPath}...");

            // Utilisation de 'using' pour garantir la fermeture correcte des fichiers
            using (var reader = new StreamReader(inputCsvPath, Encoding.UTF8)) // Spécifier l'encodage (UTF8 est courant)
            using (var csvReader = new CsvReader(reader, inputConfig))
            using (var writer = new StreamWriter(outputCsvPath, false, Encoding.UTF8)) // false = écraser si existe
            using (var csvWriter = new CsvWriter(writer, outputConfig))
            {
                // Lecture, Filtrage et Transformation en une seule passe (efficace en mémoire)
                var filteredRecords = csvReader.GetRecords<GbifInputRecord>() 
                                         .Where(record => record.BasisOfRecord != null && // Vérifie que BasisOfRecord n'est pas null
                                                        record.BasisOfRecord.Equals("HUMAN_OBSERVATION", StringComparison.OrdinalIgnoreCase)) // Garde seulement les observations humaines (ignore la casse)
                                         .Select(record => new FilteredOutputRecord // Transforme en format de sortie
                                         {
                                             Year = record.Year, // Récupère l'année
                                             GbifID = record.GbifID // Récupère l'ID GBIF
                                         });

                Console.WriteLine("Filtrage terminé. Écriture du fichier de sortie...");

                csvWriter.WriteRecords(filteredRecords);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Traitement terminé avec succès. Fichier de sortie créé : {outputCsvPath}");
                Console.ResetColor();
            }
        }
    }
}
