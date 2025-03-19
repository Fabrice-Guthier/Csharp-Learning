using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Chapitre_2_C
{
    public class ObjetMagique
    {
        public string Nom { get; set; }
        public int Valeur { get; set; }
        public int BonusPV { get; set; }
        public int BonusPM { get; set; }
        public int BonusAttaque { get; set; }
        public int BonusVitesse { get; set; }


        public ObjetMagique()
        {
            Nom = "Épée en mousse";
            Valeur = 0;
        }

        public ObjetMagique(string nom)
        {
            Nom = nom;
        }

        public ObjetMagique(int valeur)
        {
            Valeur = valeur;
        }

        public ObjetMagique(string nom, int valeur, int bonusPV, int bonusPM, int bonusAttaque, int bonusVitesse)
        {
            Nom = nom;
            Valeur = valeur;
            BonusPV = bonusPV;
            BonusPM = bonusPM;
            BonusAttaque = bonusAttaque;
            BonusVitesse = bonusVitesse;
        }
    }
}
