using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Chapitre_2_B
{
    class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public long Fonds { get; set; }
        public Client(string nom, string prenom, long fonds)
        {
            Nom = nom;
            Prenom = prenom;
            Fonds = fonds;
        }
    }
}
