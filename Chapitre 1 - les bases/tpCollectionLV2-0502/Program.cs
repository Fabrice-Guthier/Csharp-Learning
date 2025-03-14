using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpCollectionLV2_0502
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listeNoms = new List<string>();

            listeNoms.Add("Enjoliveur");
            listeNoms.Add("Roue");
            listeNoms.Add("Selle");
            listeNoms.Add("Rateau");
            listeNoms.Add("Balançoire");
            listeNoms.Add("Gorge");
            listeNoms.Add("Porte");

            List<string> listePrenoms = new List<string>();

            listePrenoms.Add("en bois");
            listePrenoms.Add("en eau");
            listePrenoms.Add("en plastique");
            listePrenoms.Add("En mousse");
            listePrenoms.Add("en pelouse");
            listePrenoms.Add("en acier trop dur");
            listePrenoms.Add("en profondeur");

            string nomAleatoire = "";
            string prenomAleatoire = "";

            bool continuer = true;
            while (continuer == true)
            {
                Console.WriteLine("Que voulez-vous faire ? Saisissez le numéro de ligne correspondant");
                Console.WriteLine("1 -- générer un nom complet");
                Console.WriteLine("2 -- quitter");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Random random = new Random();
                        int indexNom = random.Next(listeNoms.Count);
                        int indexPrenom = random.Next(listePrenoms.Count);

                        nomAleatoire = listeNoms[indexNom];
                        prenomAleatoire = listePrenoms[indexPrenom];

                        Console.WriteLine(nomAleatoire + " " + prenomAleatoire);
                        break;

                    case "2":
                        Console.WriteLine("Merci d'avoir joué !!");
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Action non reconnue. Veuillez réessayer.");
                        break;
                }
            }



            Console.ReadLine();
        }
    }
}
