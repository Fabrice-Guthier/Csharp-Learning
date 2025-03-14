using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_Chat_Alerts
{
    // Classe PostArgs
    class PostArgs
    {
        // Propriété Message
        public Message Message { get; set; }
        // Propriété Channel
        public Channel Channel { get; set; }
        // Constructeur de PostArgs
        public PostArgs(Message message, Channel channel)
        {
            this.Message = message;
            this.Channel = channel;
        }
    }
}
