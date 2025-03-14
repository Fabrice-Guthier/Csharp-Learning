using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_Chat_Alerts
{
    // Définition de la classe Message
    class Message
    {
        // Propriété pour stocker l'utilisateur
        public User User { get; set; }
        // Propriété pour stocker le contenu du message
        public string Content { get; set; }

        // Constructeur avec un seul paramètre de contenu
        public Message(string content)
        {
            // Assigner le contenu ou lever une exception si null
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        // Constructeur avec des paramètres utilisateur et contenu
        public Message(User user, string content)
        {
            // Assigner l'utilisateur
            User = user;
            // Assigner le contenu ou lever une exception si null
            Content = content ?? throw new ArgumentNullException(nameof(content));

        }
    }
}
