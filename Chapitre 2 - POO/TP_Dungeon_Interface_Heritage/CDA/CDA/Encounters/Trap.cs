using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class Trap : Encounter
    {
        public int Quantity { get; set; }
        public Characteristic CharacteristicToModify { get; set; }

        public Trap(string name, int quantity, Characteristic characteristicToModify) : base(name)
        {
            Quantity = quantity;
            CharacteristicToModify = characteristicToModify;
        }

        public override void Resolve(Player player)
        {
            switch (CharacteristicToModify)
            {
                case Characteristic.health:
                    player.HealthPoints -= Quantity;
                    break;
                case Characteristic.attack:
                    player.AttackPoints -= Quantity;
                    break;
                case Characteristic.speed:
                    player.SpeedPoints -= Quantity;
                    break;
                default:
                    break;
            }
        }
    }
}
