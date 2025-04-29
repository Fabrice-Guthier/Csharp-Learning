using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExample
{
    public class IncomingData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public IncomingData(string firstName, string lastName, string role)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Role = role;
        }
    }
}
