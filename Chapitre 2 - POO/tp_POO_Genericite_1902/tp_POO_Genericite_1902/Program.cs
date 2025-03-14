using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Genericite_1902
{
    class Program
    {
        public static void Main(string[] args)
        {

            ListFifo<int> test = new ListFifo<int>();

            test.Add(3);

            List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<char> myCharList = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };

            int randomInt = GetRandomInList(myList);
            char randomChar = GetRandomInList(myCharList);
            Console.WriteLine(randomInt + " " + randomChar);
        }
        

        public static T GetRandomInList<T>(List<T> myList)
        {
            T ToReturn = default;

            Random randomPick = new Random();
            int randomIndex = randomPick.Next(0, myList.Count);

            ToReturn = myList[randomIndex];

            return ToReturn;
        }
    }
}
