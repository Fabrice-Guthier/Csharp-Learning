using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Roguelike_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100, 10, 5);
            List<Room> rooms = new List<Room>
        {
            new Room(new Treasure(20, 5, 2)),
            new Room(new Trap(10, 3, 1)),
            new Room(new MonsterEncounter(new Monster(50, 8, 3)))
        };

            Dungeon dungeon = new Dungeon(player, rooms);
            dungeon.EnterRoom(0); // Rencontre un trésor
            dungeon.EnterRoom(1); // Rencontre un piège
            dungeon.EnterRoom(2); // Rencontre un monstre
        }
    }
}
