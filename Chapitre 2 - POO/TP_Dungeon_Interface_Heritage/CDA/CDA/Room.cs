using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Room
    {
        public Encounter Encounter { get; set; }
        public string Name { get; set; }

        public Room(Encounter encounter, string name)
        {
            Encounter = encounter ?? throw new ArgumentNullException(nameof(encounter));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Enter(Player player)
        {
            Encounter.Resolve(player);
        }
    }
}
