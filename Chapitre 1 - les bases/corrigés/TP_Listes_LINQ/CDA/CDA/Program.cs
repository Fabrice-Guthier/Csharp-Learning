using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Niveau 1 : Canal vocal
            List<string> personnesDansLeCanal = new List<string>();
            personnesDansLeCanal.Add("Alain Finkelkraut");
            personnesDansLeCanal.Add("BHL");
            personnesDansLeCanal.Add("Zemmour");
            personnesDansLeCanal.RemoveAt(2);

            foreach (string personne in personnesDansLeCanal)
            {
                Console.WriteLine(personne);
            }

            //Niveau 2 : Générateur aléatoire
            List<string> noms = new List<string> { "Hurlevent", "Coursevent", "Hurlenfer", "Fordring" };
            List<string> prenoms = new List<string> { "Gaston", "Gontran", "Ambrine", "Pénombrelle", "Cunégonde" };

            Random aleatoire = new Random();
            int indexNom = aleatoire.Next(0, noms.Count);
            int indexPrenom = aleatoire.Next(0, prenoms.Count);

            string nomAleatoire = noms[indexNom];
            string prenomAleatoire = prenoms[indexPrenom];

            Console.WriteLine(prenomAleatoire + " " + nomAleatoire);

            //Niveau 3 : Faire un dictionnaire
            Dictionary<string, string> dictionnaireFrancaisAnglais = new Dictionary<string, string>();

            dictionnaireFrancaisAnglais.Add("Bonjour", "Hello");
            dictionnaireFrancaisAnglais.Add("Pomme", "Apple");
            dictionnaireFrancaisAnglais.Add("Ordinateur", "Computer");

            Console.WriteLine(dictionnaireFrancaisAnglais["Pomme"]);

            Dictionary<string, string> dictionnaireFrancaisAllemand = new Dictionary<string, string>();

            dictionnaireFrancaisAllemand.Add("Bonjour", "Guten Tag");
            dictionnaireFrancaisAllemand.Add("Pomme", "Apfel");
            dictionnaireFrancaisAllemand.Add("Ordinateur", "Computer");

            Console.WriteLine(Traduction(dictionnaireFrancaisAllemand, "Pomme"));

            //LINQ
            List<int> pointsDeViePersonnages = new List<int> { 100, -10, 50, 40, -1 };

            List<int> pointsDeViePersonnagesVivants = pointsDeViePersonnages
                .Where(pointsDeVie => pointsDeVie > 0)
                .ToList();

            foreach (int pointsDeVie in pointsDeViePersonnagesVivants)
            {
                Console.WriteLine(pointsDeVie);
            }

            Console.WriteLine();

            //LINQ Ninja
            List<int> nombres = new List<int> { 17, 18, 8, -2, 20, 8000, 171, 10 };

            List<int> requete = nombres
                .Where(nombre => nombre > 10 && nombre % 2 == 0)
                .ToList();

            foreach (int nombre in requete)
            {
                Console.WriteLine(nombre);
            }

        }

        public static void Carre(int nombre)
        {
            nombre *= nombre;
            Console.WriteLine(nombre);
        }

        //Niveau 3,5 : fonction pour les dictionnaires
        public static string Traduction(Dictionary<string, string> dictionnaire, string motATraduire)
        {
            return dictionnaire[motATraduire];
        }
    }
}