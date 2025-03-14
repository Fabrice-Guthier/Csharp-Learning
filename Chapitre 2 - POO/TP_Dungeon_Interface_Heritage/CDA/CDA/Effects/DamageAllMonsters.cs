using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class DamageAllMonsters : ITriggerable
    {
        public Dungeon Dungeon { get; set; }
        public int DamageQuantity { get; set; }

        public DamageAllMonsters(Dungeon dungeon, int damageQuantity)
        {
            Dungeon = dungeon ?? throw new ArgumentNullException(nameof(dungeon));
            DamageQuantity = damageQuantity;
        }

        public void Trigger(Player player)
        {
            foreach (Room room in Dungeon.Rooms)
            {
                if(room.Encounter is Monster)
                {
                    Monster monster = (Monster)room.Encounter;
                    monster.HealthPoints -= DamageQuantity;
                }
            }
        }
    }
}
