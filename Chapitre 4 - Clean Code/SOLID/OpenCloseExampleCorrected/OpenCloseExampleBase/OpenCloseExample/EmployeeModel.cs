using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExample
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public EmployeeModel(IncomingData incomingData)
        {
            FirstName = incomingData.FirstName;
            LastName = incomingData.LastName;
            Email = GenerateMail(incomingData.Role);
        }

        public virtual string GenerateMail(string role)
        {
            return FirstName.Substring(0, 3) + LastName + "@nicepenguins.fr";
        }

    }
}
