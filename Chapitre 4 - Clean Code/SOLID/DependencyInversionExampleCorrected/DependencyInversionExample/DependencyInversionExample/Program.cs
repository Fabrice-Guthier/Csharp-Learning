using System;

namespace DependencyInversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPerson p = Factory.CreateAbstractPerson("Terry", "Pratchet", "terry.pratchet@discworld.com");
            AbstractLogger l = Factory.CreateAbstractLogger();

            AbstractTask t = Factory.CreateAbstractTask("Fix typos in main pages", l, p);

            t.WorkOnTask(p, 7f);
            t.WorkOnTask(p, 3.5f);
            t.CompleteTask();

        }
    }
}
