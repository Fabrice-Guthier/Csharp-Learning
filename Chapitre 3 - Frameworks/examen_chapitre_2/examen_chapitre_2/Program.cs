using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MNS;

namespace examen_chapitre_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //A 
            Fourmiliere fourmiliere = new Fourmiliere(500); //on instancie une fourmilière avec 500 fourmis
            fourmiliere.Proliferer(12); //on fait proliférer la fourmilière pendant 12 jours
            Console.WriteLine(fourmiliere.Population); //on affiche la population de la fourmilière
            //81 362 331 fourmis, ça fait beaucoup de fourmis !!!       3pts / 3pts
        }
    }
}
