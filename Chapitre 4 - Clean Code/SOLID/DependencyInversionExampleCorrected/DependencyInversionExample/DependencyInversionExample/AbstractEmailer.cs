using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    public class AbstractEmailer
    {
        public void SendMail(string mail, string emailAddress)
        {
            Console.WriteLine("Simulating sending the mail " + mail + " to " + emailAddress);
        }
    }
}
