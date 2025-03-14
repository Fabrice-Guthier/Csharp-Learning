using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Calendar
    {
        public int Year { get; set; }
        public Month Month { get; set; }
        public DayName DayName { get; set; }
        public int DayNumber { get; set; }

        public event EventHandler<CalendarArgs> OnNewDay;
        public event EventHandler<CalendarArgs> OnNewWeek;
        public event EventHandler<CalendarArgs> OnNewMonth;
        public event EventHandler<CalendarArgs> OnNewYear;

        public Calendar(int year, Month month, DayName dayName, int dayNumber)
        {
            Year = year;
            Month = month;
            DayName = dayName;
            DayNumber = dayNumber;
        }

        public void NextDay()
        {
            CalendarArgs calendarArgs = new CalendarArgs(Year, Month, DayName, DayNumber);

            if (DayNumber >= 30)
            {
                DayNumber = 1;

                OnNewMonth?.Invoke(this, calendarArgs);

                //on change de mois
                if (Month >= Month.December)
                {
                    Month = Month.January;

                    //on change d'année
                    Year++;

                    OnNewYear?.Invoke(this, calendarArgs);
                }
                else
                {
                    Month++;
                }
            }
            else
            {
                DayNumber++;
            }

            if(DayName >= DayName.Sunday)
            {
                DayName = DayName.Monday;

                OnNewWeek?.Invoke(this, calendarArgs);
            }
            else
            {
                DayName++;
            }

            //On le ré-instancie parce que la date a changé entre temps
            CalendarArgs calendarArgs2 = new CalendarArgs(Year, Month, DayName, DayNumber);

            OnNewDay?.Invoke(this, calendarArgs2);
        }

        public override string ToString()
        {
            return DayName + " " + DayNumber + " " + Month + " " + Year;
        }
    }
}
