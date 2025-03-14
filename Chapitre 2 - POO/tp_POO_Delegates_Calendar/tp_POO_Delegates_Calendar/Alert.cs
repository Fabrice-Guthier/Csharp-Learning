using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Delegates_Calendar
{
    // Définition de la classe Alert
    class Alert
    {
        public string Message { get; set; }
        // Propriété message
        public Alert(string message) 
        { 
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
        // Méthode statique pour afficher le message d'alerte
        public void DisplayMessage()
        {
            Console.WriteLine(Message);
        }
    }
}
