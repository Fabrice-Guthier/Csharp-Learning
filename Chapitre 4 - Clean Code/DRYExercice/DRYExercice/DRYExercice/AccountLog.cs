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
            foreach (string log in Logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
