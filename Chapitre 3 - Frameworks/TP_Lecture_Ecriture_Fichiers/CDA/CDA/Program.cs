using System;
using System.Xml;
using System.Text.Json.Nodes;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TP_CSV();
            //TP_CSV_LanguageManager();
            //Exemple_XML();

            string fileName = @"Datas\Test.json";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + fileName;

            string jsonString = File.ReadAllText(path);

            JsonObject root = JsonNode.Parse(jsonString).AsObject();

            JsonNode menu = root["menu"];
            JsonNode popup = menu["popup"];
            JsonNode menuItem = popup["menuitem"];
            JsonNode element = menuItem[1];
            JsonNode result = element["onclick"];

            Console.WriteLine(result);
        }

        public static void Exemple_XML()
        {
            string fileName = @"Datas\books.xml";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + fileName;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);

            XmlElement root = xmlDocument.DocumentElement;

            foreach (XmlNode book in root.ChildNodes)
            {
                Console.WriteLine(book.Attributes["category"].Value);

                foreach (XmlNode elementsInBook in book.ChildNodes)
                {
                    if (elementsInBook.Name == "title")
                    {
                        Console.WriteLine(elementsInBook.InnerText);
                    }
                }
            }
        }

        public static void TP_CSV_LanguageManager()
        {
            LanguageManager.CurrentLanguage = 2;
            string matName = LanguageManager.GetMatByKey("Mat5");

            Console.WriteLine(matName);
        }

        public static void TP_CSV()
        {
            const char SEPARATOR = ';';
            const int SUCCESS_RATE_COLLUMN = 2;
            const int SCORE_COLLUMN = 3;

            string fileName = @"Datas\ScoresGOT.csv";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + fileName;

            string[] lines = File.ReadAllLines(path);
            int successRateSum = 0;
            int scoreSum = 0;
            int numberOfScores = 0;

            foreach (string line in lines)
            {
                string[] cells = line.Split(SEPARATOR);

                string successRate = cells[SUCCESS_RATE_COLLUMN];
                string score = cells[SCORE_COLLUMN];
                int successRateInt = 0;
                int scoreInt = 0;

                if (int.TryParse(successRate, out successRateInt))
                {
                    successRateSum += successRateInt;
                }

                if (int.TryParse(score, out scoreInt))
                {
                    scoreSum += scoreInt;
                }

                if (scoreInt != 0 && successRateInt != 0)
                {
                    numberOfScores++;
                }
            }

            float successRateAverage = (float)successRateSum / (float)numberOfScores;
            float scoreAverage = (float)scoreSum / (float)numberOfScores;

            Console.WriteLine(successRateAverage);
            Console.WriteLine(scoreAverage);
        }
    }
}