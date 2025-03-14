using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public interface ITriggerable
    {
        public void Trigger(Player player);
    }
}
