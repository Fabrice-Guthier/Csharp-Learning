using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class Calculator
    {
        public int Add(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }
        public int Substract(int numberOne, int numberTwo)
        {
            return numberOne - numberTwo;
        }
        public int Multiply(int numberOne, int numberTwo)
        {
            return numberOne * numberTwo;
        }
        public float Divide(int numberOne, int numberTwo) // mettre les valeurs en int pour le test de division par 0, sinon il faut gérer l'exception
        {
            if (numberTwo == 0)
            {
                throw new ArgumentException("Two divided by ... Zero ... Zero ...");
            }
            return (float)numberOne / numberTwo;
        }
    }
}
