using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Player player = new Player(100, 10, 10);
            Dungeon dungeon = new Dungeon();

            DamageAllMonsters damageAllMonsters = new DamageAllMonsters(dungeon, 10);
            GetBonus getBonus = new GetBonus(10, Characteristic.health);

            Treasure treasure1 = new Treasure("Potion de soin", getBonus);
            Treasure treasure2 = new Treasure("Parchemin de foudre magique", damageAllMonsters); //on pourrait du coup mettre ce trésor dans une pièce pour le résoudre

            Trap trap1 = new Trap("Piège à loup", 50, Characteristic.health);
            Monster monster1 = new Monster("Gros Zombie", 25, 5, 1);


            Room room1 = new Room(treasure1, "L'entrée");
            Room room2 = new Room(trap1, "La pièce avec un piège à loup");
            Room room3 = new Room(monster1, "La pièce du zombie");

            dungeon.Rooms.Add(room1);
            dungeon.Rooms.Add(room2);
            dungeon.Rooms.Add(room3);

            dungeon.Play(player);

            Console.WriteLine(player.HealthPoints);
        }
    }
}