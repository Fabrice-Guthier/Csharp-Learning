using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_Chat_Alerts
{
    // Définition de la classe Bot qui hérite de la classe User
    class Bot : User
    {
        // Propriété pour stocker le contenu du message
        public Message Content { get; set; }

        // Constructeur de la classe Bot avec une liste de serveurs et un surnom
        public Bot(List<Server> servers, string nickName) : base(servers, nickName) { }

        // Constructeur de la classe Bot avec un surnom uniquement
        public Bot(string nickName) : base(nickName) { }

        // Méthode virtuelle qui est appelée lorsqu'un message est lu
        public virtual void OnReadMessage(object sender, PostArgs postArgs)
        {
            // Vérifie si le contenu du message contient "!Salut"
            if (postArgs.Message.Content.Contains("!Salut"))
            {
                // Publie un nouveau message dans le canal
                postArgs.Channel.PostMessage(new Message(this, "Ceci est un message de test BIDI BIDI BIDI DANGER!!!"));
            }
        }
    }
}
