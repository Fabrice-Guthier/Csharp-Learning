using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz_25_02
{
    public class FizzBuzz
    {
        public string GetOutput(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Le nombre doit être supérieur à 0");
            }
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FIZZBUZZ";
            }
            else if (number % 3 == 0)
            {
                return "FIZZ";
            }
            else if (number % 5 == 0)
            {
                return "BUZZ";
            }
            else
            {
                return number.ToString();
            }
        }
    }
}
