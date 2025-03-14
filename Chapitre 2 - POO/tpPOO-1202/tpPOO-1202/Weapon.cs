using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_1202
{
    public class Weapon
    {
        private string weaponName;
        private int attackPoints;

        public Weapon()
        {
            weaponName = "";
            attackPoints = 0;
        }

        public Weapon(string initWeaponName, int initAttackPoints)
        {
            weaponName = initWeaponName;
            attackPoints = initAttackPoints;
        }

        public void SetWeaponName(string newWeaponName)
        {
            weaponName = newWeaponName;
        }
        public string GetWeaponName()
        {
            return weaponName;
        }

        public void SetAttackPoints(int newAttackPoints)
        {
            attackPoints = newAttackPoints;
        }
        public int GetAttackPoints()
        {
            return attackPoints;
        }
        
    }
}
