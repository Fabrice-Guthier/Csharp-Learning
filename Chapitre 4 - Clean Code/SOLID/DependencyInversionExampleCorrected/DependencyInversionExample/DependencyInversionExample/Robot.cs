using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    public class Robot : AbstractPerson
    {
        public Robot(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {

        }
    }
}
