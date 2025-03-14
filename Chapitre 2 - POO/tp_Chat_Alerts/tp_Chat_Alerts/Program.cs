using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_Chat_Alerts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crée une liste de messages
            List<Message> messages = new List<Message>();

            // Crée un serveur avec le nom "CDA C#"
            Server server = new Server("CDA C#");

            // Crée un utilisateur avec le nom "Fab"
            User user = new User("Fab");

            // Crée un canal avec le nom "General"
            Channel channel = new Channel("General");

            // Crée un bot avec le nom "Discordator"
            Bot botHello = new Bot("Discordator");

            // Abonne le bot à l'événement OnPostMessage du canal
            channel.OnPostMessage += botHello.OnReadMessage;

            // Crée un message de l'utilisateur avec le contenu "!Salut"
            Message message = new Message(user, "!Salut");

            // Poste le message dans le canal
            channel.PostMessage(message);
        }
    }
}
