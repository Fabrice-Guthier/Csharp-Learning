using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    abstract class FileWriter
    {
        public string Log { get; set; }

        public FileWriter()
        {
            Log = "";
        }

        public void AddToLog(string textToAdd)
        {
            Log += textToAdd;
        }
    }
}
