using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calendar_with_Args
{
    public class Calendar
    {
        // Propriétés de l'année, du mois, du numéro du jour, du nom du jour, des heures, des alertes et du message
        public int Year { get; set; }
        public Month Month { get; set; }
        public int DayNumber { get; set; }
        public DayName DayName { get; set; }

        // Événement déclenché lors du passage au jour suivant

        public event EventHandler<CalendarArgs> OnNextDay;
        public event EventHandler<CalendarArgs> OnNextWeek;
        public event EventHandler<CalendarArgs> OnNextMonth;
        public event EventHandler<CalendarArgs> OnNextyear;

        // Constructeur de la classe Calendar
        public Calendar(int year, Month month, int dayNumber, DayName dayName)
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
            CalendarArgs calendarArgs = new CalendarArgs(Year, Month, DayNumber, DayName);

            // Déclencher l'événement OnNextDay
            OnNextDay?.Invoke(this, calendarArgs);
            // Si le jour actuel est Dimanche, passer à Lundi
            if (DayName == DayName.Dimanche)
            {
                DayName = DayName.Lundi;
                // Déclencher l'événement OnNextWeek
                OnNextWeek?.Invoke(this, calendarArgs);
            }
            else
            {
                DayName++;
            }
            // Incrémenter le numéro du jour
            DayNumber++;
            // Vérifier si l'année est bissextile
            bool isLeapYear = (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
            // Si le numéro du jour dépasse le dernier jour du mois, réinitialiser à 1 et passer au mois suivant
            if ((DayNumber > 28 && Month == Month.Février && !isLeapYear) ||
                (DayNumber > 29 && Month == Month.Février && isLeapYear) ||
                (DayNumber > 30 && (Month == Month.Avril || Month == Month.Juin || Month == Month.Septembre || Month == Month.Novembre)) ||
                (DayNumber > 31 && (Month == Month.Janvier || Month == Month.Mars || Month == Month.Mai || Month == Month.Juillet || Month == Month.Août || Month == Month.Octobre || Month == Month.Décembre)))
            {
                DayNumber = 1;
                // Déclencher l'événement OnNextMonth
                OnNextMonth?.Invoke(this, calendarArgs);
                // Si le mois actuel est Décembre, passer à Janvier et incrémenter l'année
                if (Month == Month.Décembre)
                {
                    Month = Month.Janvier;
                    Year++;
                    // Déclencher l'événement OnNextyear
                    OnNextyear?.Invoke(this, calendarArgs);

                    Console.WriteLine($"Bonne Année {Year} !!");
                    Console.WriteLine();
                }
                else
                {
                    Month++;
                }
            }
        }
    }
}
