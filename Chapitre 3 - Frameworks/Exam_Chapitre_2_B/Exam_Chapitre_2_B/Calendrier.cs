using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Chapitre_2_B
{
    class Calendrier
    {

        public int Jour { get; set; }
        public string Mois { get; set; }
        public int Annee { get; set; }

        public event Action PremierDuMois;
        public Calendrier(int jour, string mois, int annee)
        {
            Jour = jour;
            Mois = mois;
            Annee = annee;
        }

        public void AppelerPremierDuMois()
        {
            if (Jour == 1)
            {
                PremierDuMois?.Invoke();
            }
        }

    }
}
