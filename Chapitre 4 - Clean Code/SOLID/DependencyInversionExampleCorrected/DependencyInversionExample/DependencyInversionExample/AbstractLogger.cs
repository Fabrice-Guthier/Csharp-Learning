using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    public abstract class AbstractLogger
    {
        public string Log { get; set; }

        public AbstractLogger()
        {
            Log = "";
        }

        public void AddToLog(string textToAdd)
        {
            Log += textToAdd;
        }
    }
}
