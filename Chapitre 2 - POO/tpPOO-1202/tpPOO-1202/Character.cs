using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_1202
{
    public class Character
    {
        private string name;
        private int healthPoints;
        private Weapon hasWeapon;



        public Character()
        {
            name = "";
            healthPoints = 100;
            hasWeapon = new Weapon();
        }

        public Character(string initName, int initHealthPoints)
        {
            name = initName;
            healthPoints = initHealthPoints;
        }
        public Character(string initName, int initHealthPoints, Weapon initHasWeapon)
        {
            name = initName;
            healthPoints = initHealthPoints;
            hasWeapon = initHasWeapon;
        }

        public void SetName(string newName)
        {
            name = newName;
        }
        public string GetName()
        {
            return name;
        }

        public void SetHealthPoints(int newHealthPoints)
        {
            healthPoints = newHealthPoints;
        }
        public int GetHealthPoints()
        {
            return healthPoints;
        }

        public Weapon GetWeapon()
        {
            return hasWeapon;
        }

        public void SetWeapon(Weapon newWeapon)
        {
            hasWeapon = newWeapon;
        }

        public void TriggerTrap(int damageTaken)
        {
            healthPoints -= damageTaken;
        }

        public void AttackWall(Wall wall)
        {
            if (hasWeapon.GetAttackPoints() > wall.GetResistance())
            {
                wall.SetIsDestroyed(true);
            }
        }

        public void PlayerVersusPlayer(Character otherPlayer)
        {
            int otherPlayerHealthPoints = otherPlayer.GetHealthPoints();
            int weaponAttack = hasWeapon.GetAttackPoints();
            int newOtherHealthPoints = otherPlayerHealthPoints - weaponAttack;

            otherPlayer.SetHealthPoints(newOtherHealthPoints);
        }

    }
}
