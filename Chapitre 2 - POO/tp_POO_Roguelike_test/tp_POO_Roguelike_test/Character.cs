using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_POO_Roguelike_test
{
    public abstract class Character
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }

        public Character(int health, int attack, int speed)
        {
            Health = health;
            Attack = attack;
            Speed = speed;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
