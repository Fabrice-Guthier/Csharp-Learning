using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    public abstract class AbstractPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float TimeWorked { get; set; }

        public AbstractPerson(string firstName, string lastName, string email)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            TimeWorked = 0f;
        }
    }
}
