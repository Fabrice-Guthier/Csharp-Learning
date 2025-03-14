using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Treasure : Encounter
    {
        public ITriggerable Effect { get; set; }

        public Treasure(string name, ITriggerable effect) : base(name)
        {
            Effect = effect;
        }

        public override void Resolve(Player player)
        {
            Effect.Trigger(player);
        }
    }
}
