using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    public class Factory
    {
        public static AbstractPerson CreateAbstractPerson(string firstName, string lastName, string mail)
        {
            return new Robot(firstName, lastName, mail);
        }

        public static AbstractLogger CreateAbstractLogger()
        {
            return new Logger();
        }

        public static AbstractTask CreateAbstractTask(string name, AbstractLogger logger, AbstractPerson owner)
        {
            return new Task(name, logger, owner);
        }

        public static AbstractEmailer CreateAbstractEmailer()
        {
            return new Emailer();
        }
    }
}
