using InterfaceSegregationExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExercise.SmartDevices
{
    class SmartFridge : IDisplayableMessage, IDisplayableVideo
    {
        public void DisplayMessage(string information)
        {
            Console.WriteLine(information);
        }

        public void DisplayVideo(Video video)
        {
            Console.WriteLine(video);
        }
    }
}
