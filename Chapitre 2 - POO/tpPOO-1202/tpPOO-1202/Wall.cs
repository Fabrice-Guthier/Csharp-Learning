using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_1202
{
    public class Wall
    {
        private int resistance;
        private bool isDestroyed;

        public Wall()
        {
            resistance = 0;
            isDestroyed = false;
        }

        public Wall(int initResistance, bool initIsDestroyed)
        {
            resistance = initResistance;
            isDestroyed = initIsDestroyed;
        }

        public void SetResistance(int newResistance)
        {
            resistance = newResistance;
        }
        public int GetResistance()
        {
            return resistance;
        }
        public void SetIsDestroyed(bool newIsDestroyed)
        {
            if (resistance <= 0)
            {
                isDestroyed = true;
            }
        }
        public bool GetIsDestroyed()
        {
            return isDestroyed;
        }
    }
}
