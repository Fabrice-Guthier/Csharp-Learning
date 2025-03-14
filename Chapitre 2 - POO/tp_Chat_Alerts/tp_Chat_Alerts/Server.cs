using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_Chat_Alerts
{
    // Définition de la classe Server
    class Server
    {
        // Propriété pour stocker les canaux
        public List<Channel> Channels { get; set; }
        // Propriété pour stocker les utilisateurs
        public List<User> Users { get; set; }
        public string ServerName { get; set; }

        // Constructeur par défaut
        public Server(string serverName) 
        {
            ServerName = serverName;
        }

        // Constructeur avec paramètres
        public Server(List<Channel> channels, List<User> users)
        {
            // Initialisation des canaux
            Channels = channels;
            // Initialisation des utilisateurs
            Users = users;
        }
    }
}
