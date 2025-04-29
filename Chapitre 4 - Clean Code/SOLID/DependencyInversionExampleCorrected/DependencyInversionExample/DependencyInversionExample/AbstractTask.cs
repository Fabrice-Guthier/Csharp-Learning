using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    public class AbstractTask
    {
        public float TimeSpent { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public AbstractLogger Logger { get; set; }
        public AbstractPerson Owner { get; set; }

        public AbstractTask(string name, AbstractLogger logger, AbstractPerson owner)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TimeSpent = 0;
            Completed = false;
            Logger = logger;
            Owner = owner;
        }

        public void WorkOnTask(AbstractPerson person, float duration)
        {
            person.TimeWorked += duration;
            TimeSpent += duration;
        }

        public void CompleteTask()
        {
            Completed = true;

            Logger.AddToLog("\n" + Name + " task completed in " + TimeSpent + " hours");

            AbstractEmailer e = Factory.CreateAbstractEmailer();
            e.SendMail("\n" + Name + " task completed in " + TimeSpent + " hours", Owner.Email);
        }
    }
}
