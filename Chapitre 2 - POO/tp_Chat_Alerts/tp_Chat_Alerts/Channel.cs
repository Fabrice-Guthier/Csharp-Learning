using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tp_Chat_Alerts
{
    class Channel
    {
        public string ChannelName { get; set; }
        // Liste des utilisateurs dans le canal
        public List<User> Users { get; set; }
        // Liste des messages dans le canal
        public List<Message> Messages { get; set; }

        // Événement déclenché lors de la publication d'un message
        public event EventHandler<PostArgs> OnPostMessage;

        // Constructeur par défaut
        public Channel(string channelName)
        {
            ChannelName = channelName;

            Users = new List<User>();
            Messages = new List<Message>();
        }

        // Constructeur avec paramètres
        public Channel(List<User> users, List<Message> messages)
        {
            Users = users;
            Messages = messages;
        }

        // Méthode pour publier un message dans le canal
        public void PostMessage(Message message)
        {
            // Affiche le message dans la console
            Console.WriteLine(message.User.NickName + ": " + message.Content);
            // Crée un nouvel objet PostArgs avec le message et le canal actuel
            PostArgs postArgs = new PostArgs(message, this);
            // Déclenche l'événement OnPostMessage si des abonnés sont présents
            OnPostMessage?.Invoke(this, postArgs);

            
        }
    }
}
