using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExample
{
    public class EmployeeDB
    {
        public List<EmployeeModel> Employees { get; set; }

        public EmployeeDB()
        {
            Employees = new List<EmployeeModel>();
        }
    }
}
