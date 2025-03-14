using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calendar_with_Args
{
    // Classe CalendarArgs qui hérite de EventArgs
    public class CalendarArgs : EventArgs
    {
        // Propriété pour l'année
        public int Year { get; set; }

        // Propriété pour le mois
        public Month Month { get; set; }

        // Propriété pour le numéro du jour
        public int DayNumber { get; set; }

        // Propriété pour le nom du jour
        public DayName DayName { get; set; }

        // Constructeur de la classe CalendarArgs
        public CalendarArgs(int year, Month month, int dayNumber, DayName dayName)
        {
            Year = year;
            Month = month;
            DayNumber = dayNumber;
            DayName = dayName;
        }
    }
}
