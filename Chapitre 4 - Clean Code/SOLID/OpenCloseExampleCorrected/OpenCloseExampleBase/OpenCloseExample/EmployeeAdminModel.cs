using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExample
{
    public class EmployeeAdminModel : EmployeeModel
    {
        public EmployeeAdminModel(IncomingData incomingData) : base(incomingData)
        {
        }

        public override string GenerateMail(string role)
        {
            return FirstName.Substring(0, 1) + LastName + "@admin-nicepenguins.fr";
        }
    }
}
