using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PokeApi_Json_WorkShop
{
    internal class Program
    {
        static async Task Main(string[] args) 
            // on passe le main en async pour le délai de connexion à l'API
        {
            Console.WriteLine("Saisir un nom ou un ID de Pokemon :");

            string userInput = Console.ReadLine();
            // saisie de l'utilisateur
            string url = "https://pokeapi.co/api/v2/pokemon/" + userInput + "/";
            // url du fichier json, avec l'id ou le nom du pokemon

            HttpClient client = new HttpClient();
            // client http

            string jsonString = await client.GetStringAsync(url);
            // récupération du fichier json

            JsonObject root = JsonNode.Parse(jsonString).AsObject();
            // création de l'objet json

            JsonNode id = root["id"];
            // récupération de l'id
            JsonNode name = root["name"];
            // récupération du nom
            JsonNode types = root["types"];
            // récupération des types

            Console.WriteLine($"ID: {id}");
            // affichage de l'id
            Console.WriteLine($"Nom: {name}");
            // affichage du nom
            Console.WriteLine("Types:");
            // affichage des types

            foreach (var type in types.AsArray())
            // on parcourt les types qu'on affiche dans un tableau
            {
                Console.WriteLine(type["type"]["name"]);
                // affichage du nom du type, récupéré par le point root["types"]
            }
        }
    }
}
