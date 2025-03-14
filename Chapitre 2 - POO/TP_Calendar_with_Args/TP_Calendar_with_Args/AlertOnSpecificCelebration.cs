using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calendar_with_Args
{
    public class AlertOnSpecificCelebration : Alert
    {
        public int DayNumberTrigger { get; set; }
        public DayName DayNameTrigger { get; set; }
        public Month MonthTrigger { get; set; }
        public int YearTrigger { get; set; }
        public AlertOnSpecificCelebration(string message, int dayNumberTrigger, Month monthTrigger) : base(message)
        {
            DayNumberTrigger = dayNumberTrigger;
            MonthTrigger = monthTrigger;
        }
        public override void DisplayMessage(object sender, CalendarArgs calendarArgs)
        {
            if (calendarArgs.DayNumber == DayNumberTrigger && calendarArgs.Month == MonthTrigger)
            {
                base.DisplayMessage(sender, calendarArgs);
                Console.WriteLine();
            }
        }
    }
}

