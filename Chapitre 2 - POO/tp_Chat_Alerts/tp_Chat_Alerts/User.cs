using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_Chat_Alerts
{
    // Définition de la classe User
    class User
    {
        // Propriété pour stocker les serveurs
        public List<Server> Servers { get; set; }
        // Propriété pour stocker le pseudo
        public string NickName { get; set; }

        // Constructeur avec un pseudo
        public User(string nickName)
        {
            NickName = nickName;
            Servers = new List<Server>();
        }

        // Constructeur avec une liste de serveurs et un pseudo
        public User(List<Server> servers, string nickName)
        {
            Servers = servers;
            NickName = nickName;
        }
    }
}
