using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public class GetBonus : ITriggerable
    {
        public int Quantity { get; set; }
        public Characteristic CharacteristicToModify { get; set; }

        public GetBonus(int quantity, Characteristic characteristicToModify)
        {
            Quantity = quantity;
            CharacteristicToModify = characteristicToModify;
        }

        public void Trigger(Player player)
        {
            switch (CharacteristicToModify)
            {
                case Characteristic.health:
                    player.HealthPoints += Quantity;
                    break;
                case Characteristic.attack:
                    player.AttackPoints += Quantity;
                    break;
                case Characteristic.speed:
                    player.SpeedPoints += Quantity;
                    break;
                default:
                    break;
            }
        }
    }
}
