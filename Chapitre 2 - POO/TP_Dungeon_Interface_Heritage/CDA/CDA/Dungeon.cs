using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Dungeon
    {
        public List<Room> Rooms { get; set; }

        public Dungeon()
        {
            Rooms = new List<Room>();
        }

        public void Play(Player player)
        {
            foreach (Room room in Rooms)
            {
                room.Enter(player);
            }
        }
    }
}
