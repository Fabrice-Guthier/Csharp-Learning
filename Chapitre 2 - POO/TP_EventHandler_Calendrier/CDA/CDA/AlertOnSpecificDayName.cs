using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class AlertOnSpecificDayName : Alert
    {
        public DayName DayNameTrigger { get; set; }

        public AlertOnSpecificDayName(string message, DayName dayNameTrigger) : base(message)
        {
            DayNameTrigger = dayNameTrigger;
        }

        public override void DisplayMessage(object? sender, CalendarArgs calendarArgs)
        {
            if (calendarArgs.DayName == DayNameTrigger)
            {
                base.DisplayMessage(sender, calendarArgs);
            }
        }
    }
}
