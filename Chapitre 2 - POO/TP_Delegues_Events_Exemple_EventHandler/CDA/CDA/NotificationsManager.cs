using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class NotificationsManager
    {
        public void PlaySound(object? sender, MessageArgs messageArgs)
        {
            Console.WriteLine("Blip bloup " + messageArgs.NickNameSender);
        }

        public void Vibrations(object? sender, MessageArgs messageArgs)
        {
            Console.WriteLine("vvv vvvv");
        }
    }
}
