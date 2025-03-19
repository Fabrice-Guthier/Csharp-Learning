using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Chapitre_2_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendrier calendrier = new Calendrier(1, "janvier", 2025);
            Client locataire = new Client("Bon", "Jean", 4356);
            Client proprietaire = new Client("Picsou", "Donald", 32445);
            Logement logement = new Logement(proprietaire, locataire, 570, "Appartement", calendrier);

            calendrier.AppelerPremierDuMois();
            Console.WriteLine("Le locataire a maintenant " + locataire.Fonds + " euros");

            // 3.5pts / 4pts
        }
    }
}
