using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace TP_API_XML_BGG
{
    class Program
    {
        static void Main(string[] args)
        {
            SeachGameById();
            SearchGameByName();
        }

        public static void SeachGameById()
        {
            Console.WriteLine("Veuillez saisir un numéro pour trouver un jeu :");
            string userInput = Console.ReadLine();
            // saisie de l'utilisateur

            string xmlLink = "https://boardgamegeek.com/xmlapi2/thing?id=" + userInput;
            // lien de l'API avec la saisie utilisateur concaténée

            XmlDocument xmlDocument = new XmlDocument();
            // création d'un objet XmlDocument

            xmlDocument.Load(xmlLink);
            // chargement du lien de l'API

            XmlElement root = xmlDocument.DocumentElement;
            // récupération de la racine du document XML

            XmlNodeList nodes = root.SelectNodes("item");
            // récupération des noeuds "item"

            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node["name"].Attributes["value"].Value);
                // affichage du nom du jeu
                Console.WriteLine(node["description"].InnerText);
                // affichage de la description du jeu
            }
            Console.WriteLine();
        }

        public static void SearchGameByName()
        {
            Console.WriteLine("Veuillez saisir un nom pour trouver un jeu :");
            string userInput = Console.ReadLine();
            // saisie de l'utilisateur

            string xmlLink = "https://boardgamegeek.com/xmlapi2/search?query=" + userInput;
            // lien de l'API avec la saisie utilisateur concaténée

            XmlDocument xmlDocument = new XmlDocument();
            // création d'un objet XmlDocument

            xmlDocument.Load(xmlLink);
            // chargement du lien de l'API

            XmlElement root = xmlDocument.DocumentElement;
            // récupération de la racine du document XML

            XmlNodeList nodes = root.SelectNodes("item");
            // récupération des noeuds "item"

            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node["name"].Attributes["value"].Value);
                // affichage du nom du jeu
            }
            Console.WriteLine();

        }
    }
}
