using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    class SMSSender : IMessageSender
    {
        public void SendMessage(string mail, string emailAddress)
        {
            Console.WriteLine("SMS");
        }
    }
}
