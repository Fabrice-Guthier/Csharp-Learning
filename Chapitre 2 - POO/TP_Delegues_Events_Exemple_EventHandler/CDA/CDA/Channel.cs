using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Channel
    {
        public event EventHandler<MessageArgs> OnMessageSent;

        public void MessageSent()
        {
            //instructions

            if(OnMessageSent != null)
            {
                MessageArgs messageArgs = new MessageArgs(DateTime.Now, "test", "Anoarith", "AAA");

                OnMessageSent(this, messageArgs);
            }
        }
    }
}
