using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    interface IMessageSender
    {
        void SendMessage(string mail, string emailAddress);
    }
}
