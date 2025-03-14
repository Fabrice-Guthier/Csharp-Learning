using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calendar_with_Args
{
    public class Alert
    {
        public string Message { get; set; }
        // Propriété message
        public Alert(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
        // Méthode statique pour afficher le message d'alerte
        public virtual void DisplayMessage(object sender, CalendarArgs calendarArgs)
        {
            Console.WriteLine(Message);
        }
    }
}
