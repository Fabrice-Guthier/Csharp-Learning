using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSampleCode
{
    public class MathOperations
    {
        public int Add(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }

        public float Divide(int numberOne, int numberTwo)
        {
            if (numberTwo == 0)
                throw new ArgumentException("Second parameter can't be equal to zero");

            return (float)numberOne / numberTwo;
        }

        // Plus dur !
        public IEnumerable<int> GetOddNumbers(int limit)
        {
            if (limit < 0)
                throw new ArgumentException("Limit argument can't be negative");

            var numberList = new List<int>();

            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    numberList.Add(i);

            return numberList;
        }
    }
}
