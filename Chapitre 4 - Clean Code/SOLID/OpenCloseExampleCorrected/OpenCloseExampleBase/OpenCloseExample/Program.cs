using System;
using System.Collections.Generic;

namespace OpenCloseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDB employeeDB = new EmployeeDB();

            List<IncomingData> incomingDatas = new List<IncomingData>
            {
                new IncomingData("Karl", "Marx", "manager"),
                new IncomingData("Rosa", "Luxemburg", "none"),
                new IncomingData("Léon", "Trotski", "admin")
            };

            foreach (IncomingData i in incomingDatas)
            {
                EmployeeModel model;

                switch (i.Role)
                {
                    case "manager":
                        model = new EmployeeManagerModel(i);
                        break;
                    case "admin":
                        model = new EmployeeAdminModel(i);
                        break;
                    default:
                        model = new EmployeeModel(i);
                        break;
                }

                employeeDB.Employees.Add(model);
            }

            foreach (EmployeeModel employee in employeeDB.Employees)
            {
                Console.WriteLine(employee.Email);
            }

            Console.Read();
        }
    }
}
