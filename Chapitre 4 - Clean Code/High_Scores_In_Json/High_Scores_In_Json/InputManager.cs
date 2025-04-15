using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Scores_In_Json
{
    internal class InputManager
    {
        public string InputNickName()
        {
            Console.WriteLine("Saisissez votre nom :");
            string playerName = Console.ReadLine();
            return playerName;
        }
    }
}
