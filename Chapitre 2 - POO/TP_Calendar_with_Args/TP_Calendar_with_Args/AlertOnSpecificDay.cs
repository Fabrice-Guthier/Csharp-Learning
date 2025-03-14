using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calendar_with_Args
{
    public class AlertOnSpecificDay : Alert
    {
        public int DayNumberTrigger { get; set; }
        public DayName DayNameTrigger { get; set; }
        public Month MonthTrigger { get; set; }
        public int YearTrigger { get; set; }
        public AlertOnSpecificDay(string message, int dayNumberTrigger, DayName dayNameTrigger) : base(message)
        {
            DayNumberTrigger = dayNumberTrigger;
            DayNameTrigger = dayNameTrigger;
        }
        public override void DisplayMessage(object sender, CalendarArgs calendarArgs)
        {
            if (calendarArgs.DayNumber == DayNumberTrigger && calendarArgs.DayName == DayNameTrigger)
            {
                base.DisplayMessage(sender, calendarArgs);
                Console.WriteLine();
            }
        }
    }
}
