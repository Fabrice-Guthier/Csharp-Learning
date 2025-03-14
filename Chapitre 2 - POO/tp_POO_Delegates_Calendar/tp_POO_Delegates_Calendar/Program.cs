using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Delegates_Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crée une instance de Calendar avec l'année 2025, le mois de février, le 28ème jour, et le jour de la semaine vendredi
            Calendar calendar = new Calendar(2025, Months.Mars, 3, Days.Lundi);

            // Crée une instance de Alert
            Alert alert1 = new Alert("Debout");
            Alert alert2 = new Alert("Rdv médecin");
            Alert alert3 = new Alert("Aller chercher le drive");
            Alert alert4 = new Alert("Go jouer");

            // Affiche les informations du calendrier
            calendar.OnNextDay += alert1.DisplayMessage;
            calendar.OnNextWeek += alert2.DisplayMessage;
            calendar.OnNextMonth += alert3.DisplayMessage;
            calendar.OnNextyear += alert4.DisplayMessage;
            // Boucle pour avancer le calendrier
            for (int i = 1; i <= 10000; i++)
            {
                calendar.NextDay();
            }

            // Affiche les informations du calendrier après avoir avancé
            Console.WriteLine(calendar);
        }
    }
}

