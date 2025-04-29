using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionExercise
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Salary { get; set; }

        public virtual void CalculatePerHourRate(int rank)
        {
            float baseAmount = 12.5f;

            Salary = baseAmount + (rank * 2);
        }

    }
}
