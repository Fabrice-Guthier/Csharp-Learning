using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionExercise
{
    class Manager : Employee, IManager
    {
        public void GeneratePerformanceReview()
        {
            Console.WriteLine("I'm reviewing a direct report's performance.");
        }
        
        public override void CalculatePerHourRate(int rank)
        {
            float baseAmount = 19.75f;

            Salary = baseAmount + (rank * 4);
        }
    }
}
