using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Roguelike_test
{
    public class MonsterEncounter : Encounter
    {
        public Monster Monster { get; set; }

        public MonsterEncounter(Monster monster)
        {
            Monster = monster;
        }

        public override void Interact(Player player)
        {
            Console.WriteLine("Un monstre apparaît !");
            Fight(player, Monster);
        }

        private void Fight(Player player, Monster monster)
        {
            Character firstAttacker;
            if (player.Speed >= monster.Speed)
            {
                firstAttacker = player;
            }
            else
            {
                firstAttacker = monster;
            }

            Character secondAttacker;
            if (firstAttacker == player)
            {
                secondAttacker = monster;
            }
            else
            {
                secondAttacker = player;
            }

            Character attacker = firstAttacker;
            Character defender = secondAttacker;

            while (player.IsAlive() && monster.IsAlive())
            {
                Console.WriteLine($"{attacker.GetType().Name} attaque !");
                defender.TakeDamage(attacker.Attack);

                if (!defender.IsAlive())
                {
                    Console.WriteLine($"{defender.GetType().Name} est vaincu !");
                    break;
                }

                Character temp = attacker;
                attacker = defender;
                defender = temp;
            }
        }
    }
}
