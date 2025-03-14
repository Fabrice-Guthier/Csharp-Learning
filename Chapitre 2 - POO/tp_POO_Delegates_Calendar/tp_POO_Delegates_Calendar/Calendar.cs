using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Delegates_Calendar
{
    class Calendar
    {
        // Propriétés de l'année, du mois, du numéro du jour, du nom du jour, des heures, des alertes et du message
        public int Year { get; set; }
        public Months Month { get; set; }
        public int DayNumber { get; set; }
        public Days DayName { get; set; }
        public List<Alert> Alerts { get; set; }

        // Événement déclenché lors du passage au jour suivant
        public event Action OnNextDay;
        public event Action OnNextWeek;
        public event Action OnNextMonth;
        public event Action OnNextyear;


        // Constructeur de la classe Calendar
        public Calendar(int year, Months month, int dayNumber, Days dayName)
        {
            Year = year;
            Month = month;
            DayNumber = dayNumber;
            DayName = dayName;
        }

        // Méthode ToString pour afficher la date sous forme de chaîne
        public override string ToString()
        {
            return $"{DayName} {DayNumber} {Month} {Year}";
        }

        // Méthode pour passer au jour suivant
        public void NextDay()
        {
            if (OnNextDay != null)
                OnNextDay();
                // Si le jour actuel est Dimanche, passer à Lundi
                if (DayName == Days.Dimanche)
            {
                DayName = Days.Lundi;
                if (OnNextWeek != null)
                    OnNextWeek();
            }
            else
            {
                DayName++;
            }
            // Incrémenter le numéro du jour
            DayNumber++;
            // Si le numéro du jour dépasse 30, réinitialiser à 1 et passer au mois suivant
            if (DayNumber >= 30)
            {
                DayNumber = 1;
                if (OnNextMonth != null)
                    OnNextMonth();
                // Si le mois actuel est Décembre, passer à Janvier et incrémenter l'année
                if (Month == Months.Décembre)
                {
                    Month = Months.Janvier;
                    Year++;
                    if (OnNextyear != null)
                        OnNextyear();
                    
                    Console.WriteLine($"Bonne Année {Year} !!");
                }
                else
                {
                    Month++;
                }
            }
        }
    }
}
