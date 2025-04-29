using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExample
{
    public class EmployeeManagerModel : EmployeeModel
    {
        public EmployeeManagerModel(IncomingData incomingData) : base(incomingData)
        {
        }

        public override string GenerateMail(string role)
        {
            //appelle une autre méthode
            return FirstName + LastName + "@manager-nicepenguins.fr";
        }
    }
}
