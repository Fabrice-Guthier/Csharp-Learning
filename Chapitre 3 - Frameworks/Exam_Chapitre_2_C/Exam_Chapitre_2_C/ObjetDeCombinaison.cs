using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Chapitre_2_C
{
    public class ObjetDeCombinaison : ObjetMagique
    {
        public ObjetMagique ObjetMagique1 { get; set; }
        public ObjetMagique ObjetMagique2 { get; set; }

        public ObjetDeCombinaison(ObjetMagique objetMagique1, ObjetMagique objetMagique2)
        {
            ObjetMagique1 = objetMagique1;
            ObjetMagique2 = objetMagique2;
        }
    }
}
