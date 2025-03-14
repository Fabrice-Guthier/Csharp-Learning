using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public abstract class Encounter
    {
        public string Name { get; set; }

        protected Encounter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public abstract void Resolve(Player player);
    }
}
