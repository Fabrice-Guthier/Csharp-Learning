using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExercise.Interfaces
{
    interface ISendableMail
    {
        void SendMail(string mail, string emailAddress);
    }
}
