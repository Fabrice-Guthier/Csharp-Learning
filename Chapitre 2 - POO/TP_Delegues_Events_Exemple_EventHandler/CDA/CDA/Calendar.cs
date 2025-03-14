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

        public event Action<int, Month, DayName, int> OnNewTruc;
        public event Action OnNewDay;
        public event Action OnNewWeek;
        public event Action OnNewMonth;
        public event Action OnNewYear;

        public Calendar(int year, Month month, DayName dayName, int dayNumber)
        {
            Year = year;
            Month = month;
            DayName = dayName;
            DayNumber = dayNumber;
        }

        public void NextDay()
        {
            if(OnNewDay != null)
                OnNewDay();

            if (DayNumber >= 30)
            {
                DayNumber = 1;

                if (OnNewMonth != null)
                    OnNewMonth();

                //on change de mois
                if (Month >= Month.December)
                {
                    Month = Month.January;

                    //on change d'année
                    Year++;

                    if (OnNewYear != null)
                        OnNewYear();
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

                if (OnNewWeek != null)
                    OnNewWeek();
            }
            else
            {
                DayName++;
            }
        }

        public override string ToString()
        {
            return DayName + " " + DayNumber + " " + Month + " " + Year;
        }
    }
}
