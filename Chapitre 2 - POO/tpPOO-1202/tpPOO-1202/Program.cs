using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tpPOO_1202
{
    public class Program
    {
        static void Main(string[] args)
        {
            Character player1 = new Character("xX_H@rdc0r3-G@m3r_Xx", 100);

            player1.TriggerTrap(7);

            Console.WriteLine("Aie, vous avez marché dans un piège, il vous reste " + player1.GetHealthPoints() + " points de vie.");

            Wall wall1 = new Wall(18, false);

            Weapon Rubilacxe = new Weapon("Rubilacxe", 18);
            Weapon Tetanos = new Weapon("Tetanos", 20);

            Character player2 = new Character("Gontran", 76, Rubilacxe);
            Character player3 = new Character("Marcel", 88, Tetanos);

            Console.WriteLine(player2.GetWeapon().GetWeaponName() + " " + player2.GetWeapon().GetAttackPoints());

            player3.AttackWall(wall1);
            Console.WriteLine("Alors il est cassé le mur ? " + wall1.GetIsDestroyed());


            player3.PlayerVersusPlayer(player2);

            Console.WriteLine("Il reste " + player2.GetHealthPoints() + " points de vie à l'adversaire.");





            Console.ReadLine();
        }
    }
}
