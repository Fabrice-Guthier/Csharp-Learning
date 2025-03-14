using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Alert
    {
        public string Message { get; set; }

        public Alert(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public virtual void DisplayMessage(object? sender, CalendarArgs calendarArgs)
        {
            Console.WriteLine(Message);
        }
    }
}
