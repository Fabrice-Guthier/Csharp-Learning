using InterfaceSegregationExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExercise.SmartDevices
{
    class PersonalAssistant : IConnectableToInternet, IPlayableSound, ISetupableAlarm, ITreatableVoice
    {
        public bool ConnectToInternet()
        {
            Console.WriteLine("Connected !");
            return true;
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
    }
}
