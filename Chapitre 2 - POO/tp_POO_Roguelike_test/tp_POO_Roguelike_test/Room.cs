using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Roguelike_test
{
    public class Room
    {
        public Encounter Encounter { get; set; }

        public Room(Encounter encounter)
        {
            Encounter = encounter;
        }
    }
}
