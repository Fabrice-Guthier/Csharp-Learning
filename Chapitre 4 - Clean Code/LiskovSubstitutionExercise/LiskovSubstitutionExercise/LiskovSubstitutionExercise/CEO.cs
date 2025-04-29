using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionExercise
{
    class CEO : Employee, ITheBoss, IManager
    {
        public void FireSomeone()
        {
            Console.WriteLine("You're Fired !");
        }
        public void GeneratePerformanceReview()
        {
            Console.WriteLine("I'm reviewing a direct report's performance.");
        }
        public void AssignManager(Employee manager)
        {
            Employee Manager = manager;
            Console.WriteLine("My new manager is " + manager.FirstName + " " + manager.LastName);
        }

        public override void CalculatePerHourRate(int rank)
        {
            float baseAmount = 150f;

            Salary = baseAmount * rank;
        }
    }
}
