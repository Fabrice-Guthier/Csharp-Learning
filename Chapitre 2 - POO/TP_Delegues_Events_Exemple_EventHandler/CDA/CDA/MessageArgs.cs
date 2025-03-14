using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class MessageArgs : EventArgs
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string NickNameSender { get; set; }
        public string NickNameReceiver { get; set; }


        public MessageArgs(DateTime date, string content, string nickNameSender, string nickNameReceiver)
        {
            Date = date;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            NickNameSender = nickNameSender;
            NickNameReceiver = nickNameReceiver;
        }
    }
}
