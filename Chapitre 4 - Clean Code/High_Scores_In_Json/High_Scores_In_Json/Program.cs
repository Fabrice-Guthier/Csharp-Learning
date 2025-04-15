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
            Scores.LoadScores();

            // Demander le nom du joueur
            InputManager nickName = new InputManager();
            string playerName = nickName.InputNickName();

            // Créer une nouvelle instance de jeu et démarrer le jeu
            Game game = new Game();
            game.Play();

            // Créer une nouvelle instance de Scores pour enregistrer le score du joueur
            Scores score = new Scores();
            score.Name = playerName.ToString(); // Lire le nom du joueur entré dans la console précédemment
            score.Score = game.nombreDeCoups; // Assigner le score du jeu au score du joueur

            // Sauvegarder le nouveau score dans le fichier JSON
            Scores.SaveScores(score);
        }
    }
}