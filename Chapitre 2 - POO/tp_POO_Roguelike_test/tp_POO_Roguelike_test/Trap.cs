using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Roguelike_test
{
    public class Trap : Encounter
    {
        public int HealthPenalty { get; set; }
        public int AttackPenalty { get; set; }
        public int SpeedPenalty { get; set; }

        public Trap(int healthPenalty, int attackPenalty, int speedPenalty)
        {
            HealthPenalty = healthPenalty;
            AttackPenalty = attackPenalty;
            SpeedPenalty = speedPenalty;
        }

        public override void Interact(Player player)
        {
            player.Health -= HealthPenalty;
            player.Attack -= AttackPenalty;
            player.Speed -= SpeedPenalty;
            Console.WriteLine("Vous êtes tombé dans un piège !");
        }
    }

}
