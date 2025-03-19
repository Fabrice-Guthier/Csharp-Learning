using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Chapitre_2_B
{
    class Logement
    {
        public Client Proprietaire { get; set; }
        public Client Locataire { get; set; }
        public float TarifLocation { get; set; }
        public string NomDuLogement { get; set; }
        public Calendrier Calendrier { get; set; }

        public Logement(Client proprietaire, Client locataire, float tarifLocation, string nomDuLogement, Calendrier calendrier)
        {
            Proprietaire = proprietaire;
            Locataire = locataire;
            TarifLocation = tarifLocation;
            NomDuLogement = nomDuLogement;
            Calendrier = calendrier;
            //if (Calendrier.Jour == 1)
            //{
            //    PayerLoyer();
            //}
            Calendrier.PremierDuMois += PayerLoyer;
        }

        public void PayerLoyer()
        {
            Locataire.Fonds -= (long)TarifLocation;
            Proprietaire.Fonds += (long)TarifLocation;
        }
    }
}
