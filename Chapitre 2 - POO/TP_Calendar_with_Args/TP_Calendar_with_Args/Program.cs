using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calendar_with_Args
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendar calendar = new Calendar(2025, Month.Janvier, 1, DayName.Mercredi);

            AlertOnSpecificDay alertOnFriday13th = new AlertOnSpecificDay("On est Vendredi 13!", 13, DayName.Vendredi);
            calendar.OnNextDay += alertOnFriday13th.DisplayMessage;

            AlertOnSpecificCelebration alertOnHalloween = new AlertOnSpecificCelebration("On est Halloween!", 31, Month.Octobre);
            calendar.OnNextDay += alertOnHalloween.DisplayMessage;

            AlertOnSpecificCelebration alertOnChristmas = new AlertOnSpecificCelebration("On est Noël!", 25, Month.Décembre);
            calendar.OnNextDay += alertOnChristmas.DisplayMessage;

            AlertOnSpecificCelebration alertOn1stMay = new AlertOnSpecificCelebration("On est le 1er Mai, c'est férie!", 1, Month.Mai);
            calendar.OnNextDay += alertOn1stMay.DisplayMessage;

            AlertOnSpecificCelebration alertOn8thMay = new AlertOnSpecificCelebration("On est le 8 Mai, c'est férié!", 8, Month.Mai);
            calendar.OnNextDay += alertOn8thMay.DisplayMessage;

            AlertOnSpecificCelebration alertOn14thJuly = new AlertOnSpecificCelebration("On est le 14 Juillet, c'est férié!", 14, Month.Juillet);
            calendar.OnNextDay += alertOn14thJuly.DisplayMessage;


            for (int i = 0; i < 3650; i++)
            {
                calendar.NextDay();
                Console.WriteLine(calendar);
            }
        }
    }
}
