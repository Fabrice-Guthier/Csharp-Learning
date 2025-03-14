using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Monster : Encounter
    {
        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int SpeedPoints { get; set; }

        public Monster(string name, int healthPoints, int attackPoints, int speedPoints) : base(name)
        {
            HealthPoints = healthPoints;
            AttackPoints = attackPoints;
            SpeedPoints = speedPoints;
        }

        public override void Resolve(Player player)
        {
            bool monsterAttacking = false;

            if (SpeedPoints > player.SpeedPoints)
                monsterAttacking = true;

            while(player.HealthPoints > 0 && HealthPoints > 0)
            {
                if(monsterAttacking)
                {
                    player.HealthPoints -= AttackPoints;
                }
                else
                {
                    HealthPoints -= player.AttackPoints;
                }

                monsterAttacking = !monsterAttacking;

                Console.WriteLine("Player : \n" + player);
                Console.WriteLine("Monster : \n" + this);
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return "HP : " + HealthPoints +
                "\nAP : " + AttackPoints +
                "\nSP : " + SpeedPoints;
        }
    }
}
