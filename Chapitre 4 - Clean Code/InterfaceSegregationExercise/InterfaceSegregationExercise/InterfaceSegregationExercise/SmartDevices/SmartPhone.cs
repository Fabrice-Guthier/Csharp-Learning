using InterfaceSegregationExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExercise.SmartDevices
{
    class SmartPhone : ISmartDevice
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

        public void SetupAlarm(DateTime date)
        {
            Console.WriteLine("Alarm set to : " + date);
        }

        public void TreatVoice(Sound sound)
        {
            Console.WriteLine(sound);
        }

        public void SendMail(string mail, string emailAddress)
        {
            Console.WriteLine("Mail send to : " + emailAddress);
        }

    }
}
