using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Chapitre_2_C
{
    public class Joueur
    {
        ObjetMagique[] inventaire;
        public int PO { get; set; }
        public int PV { get; set; }
        public int PM { get; set; }
        public int Attaque { get; set; }
        public int Vitesse { get; set; }


        public Joueur()
        {
            inventaire = new ObjetMagique[6];
            PO = 0;
        }

        public void AcheterObjetAvecBonus(ObjetMagique objectMagique, int emplacement)
        {
            bool objetAjoute = false;
            if (PO >= objectMagique.Valeur)
            {
                for (int i = 0; i < inventaire.Length; i++)
                {
                    if (inventaire[i] != inventaire[emplacement])
                    {
                        inventaire[i] = objectMagique;
                        objetAjoute = true;
                        break;
                    }
                }
                PO -= objectMagique.Valeur;
                PV += objectMagique.BonusPV;
                PM += objectMagique.BonusPM;
                Attaque += objectMagique.BonusAttaque;
                Vitesse += objectMagique.BonusVitesse;
            }
            else
            {
                Console.WriteLine("je ne peux pas acheter cet objet");
            }
        }

        public void AcheterObjet(ObjetMagique objectMagique, int emplacement)
        {
            bool objetAjoute = false;
            if (PO >= objectMagique.Valeur)
            {
                for (int i = 0; i < inventaire.Length; i++)
                {
                    if (inventaire[i] != inventaire[emplacement])
                    {
                        inventaire[i] = objectMagique;
                        objetAjoute = true;
                        break;
                    }
                }
                PO -= objectMagique.Valeur;
            }
            else
            {
                Console.WriteLine("je ne peux pas acheter cet objet");
            }
        }

        public void AfficherInventaire()
        {
            Console.WriteLine("Inventaire du joueur :");
            foreach (ObjetMagique objetMagique in inventaire)
            {
                if (objetMagique == null)
                {
                    Console.WriteLine("vide");
                }
                else
                {
                    Console.WriteLine(objetMagique.Nom);
                }
            }
        }

        public void CombinerObjet(int emplacement1, int emplacement2, ObjetDeCombinaison objetDeCombinaison)
        {
            if (inventaire[emplacement1] == objetDeCombinaison.ObjetMagique1 && inventaire[emplacement2] == objetDeCombinaison.ObjetMagique2) // oublié le ou avec les emplacements inversés
            {
                inventaire[emplacement1] = objetDeCombinaison;
                inventaire[emplacement2] = null;
                Console.WriteLine($"Les objets {objetDeCombinaison.ObjetMagique1.Nom} et {objetDeCombinaison.ObjetMagique2.Nom} ont été combinés en {objetDeCombinaison.Nom}");
            }
            else
            {
                Console.WriteLine("Les objets à combiner ne correspondent pas aux emplacements spécifiés.");
            }
        }
    }
}
