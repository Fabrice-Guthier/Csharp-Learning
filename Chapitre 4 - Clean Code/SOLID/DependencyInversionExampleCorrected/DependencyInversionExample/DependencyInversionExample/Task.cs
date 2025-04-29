using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionExample
{
    class Task : AbstractTask
    {
        public Task(string name, AbstractLogger logger, AbstractPerson owner) : base(name, logger, owner)
        {
        }
    }
}
