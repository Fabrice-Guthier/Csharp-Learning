using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS
{
    internal class Fourmiliere
    {
        public int Population { get; set; } //nombre de fourmis

        //constructeur par défaut
        public Fourmiliere()
		{
			Population = 1; //de base, on a une fourmi
		}

		//cette surcharge permet d'initialiser une fourmilière avec une population initiale égale à initPop
		public Fourmiliere(int initPop)
		{
			Population = initPop;
		}

		//fait proliférer la fourmilière pendant 1 jour
		public void Proliferer()
		{
			//un calcul savant qui a nécessité des années de recherche !!!
			Population = (int) Math.Round((double) Population * Math.E);
		}

		//fait proliférer la fourmilière pendant n jours 
		public void Proliferer(int nJours)
		{
			for (int i = 0; i < nJours; i++)
			{
				Proliferer();
			}
		}
	}
}
