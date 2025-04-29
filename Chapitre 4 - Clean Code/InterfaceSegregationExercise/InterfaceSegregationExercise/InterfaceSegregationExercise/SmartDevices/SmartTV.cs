using InterfaceSegregationExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExercise.SmartDevices
{
    class SmartTV : IConnectableToInternet, IDisplayableMessage, IDisplayableVideo, IPlayableSound
    {
        public bool ConnectToInternet()
        {
            Console.WriteLine("Connected !");
            return true;
        }

        public void DisplayMessage(string information)
        {
            Console.WriteLine(information);
        }

        public void DisplayVideo(Video video)
        {
            Console.WriteLine(video);
        }

        public void PlaySound(Sound sound)
        {
            Console.WriteLine(sound);
        }
    }
}
