using System;
using System.Collections.Generic;
using System.Text;

namespace DRYExercise
{
    class AccountLog
    {
        public List<string> Logs { get; set; }

        public AccountLog()
        {
            Logs = new List<string>();
        }

        public void DisplayLogs()
        {
            Console.WriteLine(GetLogs());
        }

        public string GetLogs()
        {
            string toReturn = "";

            foreach (string log in Logs)
            {
                toReturn += log + "\n";
            }

            return toReturn;
        }
    }
}
