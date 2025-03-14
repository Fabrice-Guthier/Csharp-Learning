using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpReferences_1002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Faire une fonction qui convertit un nombre de secondes en heures + minutes + secondes
            // (elle modifie par référence 3 variables ou bien 2 variables et elle en renvoie une troisième comme vous préférez)
            // saisir le temps en secondes
            //créer la formule pour passer du temps en secondes vers les minutes et un pour les heures
            int hours = 0;
            int minutes = 0;
            int timeInSeconds = 16132;
            int secondesRestantes = 0;

            secondesRestantes = TimeConversion(ref hours, ref minutes, timeInSeconds);

            Console.WriteLine(hours + "h " + minutes + "min " + secondesRestantes + "sec");

            Console.ReadLine();   
        }

        static int TimeConversion(ref int h, ref int min, int sec)
        {
            h = sec / 3600;
            min = (sec % 3600) / 60;
            sec %= 60;
            return sec;
        }
    }
}
