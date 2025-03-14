using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Player
    {
        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int SpeedPoints { get; set; }

        public Player(int healthPoints, int attackPoints, int speedPoints)
        {
            HealthPoints = healthPoints;
            AttackPoints = attackPoints;
            SpeedPoints = speedPoints;
        }

        public override string ToString()
        {
            return "HP : " + HealthPoints +
                "\nAP : " + AttackPoints +
                "\nSP : " + SpeedPoints;
        }
    }
}
