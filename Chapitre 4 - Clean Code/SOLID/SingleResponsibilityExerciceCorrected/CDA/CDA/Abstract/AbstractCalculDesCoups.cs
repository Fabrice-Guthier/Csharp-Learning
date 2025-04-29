using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA.Abstract
{
    abstract class AbstractCalculDesCoups
    {
        public int NombreDeCoups { get; set; }

        public AbstractCalculDesCoups()
        {
            NombreDeCoups = 0;
        }
    }
}
