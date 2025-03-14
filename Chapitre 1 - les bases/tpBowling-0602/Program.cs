using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBowling_0602
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // créer les variables pour les tirs, les strikes, les points bonus des strikes, les spares, les points bonus des spares
            // créer le tableau d'affichage, histoire que ça ressemble à quelque chose
            //          ___________
            //          |  9 |  0 |  
            //          |---------|
            //          |    39   |
            //          -----------
            //

            // si le 1er lancer est un strike, score+=10 et on passe qu 2e lancer
            // sinon on a un 2e essai, on peut faire un spare et avoir un bonus de points qui va se cumuler sur le tir suivant
            // on peut faire afficher le score après chaque tir, sur 2 colonnes, et aussi le total en dessous, oú les points bonus sont pris en compte

            // on répète ça pour autant de tirs possibles

            // 

            int bowlOne = 0;
            int bowlTwo = 0;
            int strike = 0;
            int strikeBonus = 0;
            int spare = 0;
            int spareBonus = 0;

            int[] tableauDesScores = new int[3];
        }
    }
}