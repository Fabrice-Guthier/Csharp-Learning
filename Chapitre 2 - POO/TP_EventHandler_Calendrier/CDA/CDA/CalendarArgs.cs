using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class CalendarArgs : EventArgs
    {
        public int Year { get; set; }
        public Month Month { get; set; }
        public DayName DayName { get; set; }
        public int DayNumber { get; set; }

        public CalendarArgs(int year, Month month, DayName dayName, int dayNumber)
        {
            Year = year;
            Month = month;
            DayName = dayName;
            DayNumber = dayNumber;
        }
    }
}
