using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Roguelike_test
{
    public class Dungeon
    {
        public List<Room> Rooms { get; set; }
        public Player Player { get; set; }

        public Dungeon(Player player, List<Room> rooms)
        {
            Player = player;
            Rooms = rooms;
        }

        public void EnterRoom(int roomIndex)
        {
            if (roomIndex < 0 || roomIndex >= Rooms.Count)
            {
                Console.WriteLine("Pièce invalide.");
                return;
            }

            Rooms[roomIndex].Encounter.Interact(Player);
        }
    }
}
