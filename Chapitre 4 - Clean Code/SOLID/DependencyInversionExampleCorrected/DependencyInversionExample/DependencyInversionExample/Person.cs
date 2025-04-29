using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    public class Person : AbstractPerson
    {
        public Person(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }
    }
}
