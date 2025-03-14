using System;

namespace CDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calendar calendar = new Calendar(2025, Month.March, DayName.Monday, 3);

            Alert alert1 = new Alert("Réveil");
            Alert alert2 = new Alert("Acheter du pain");
            Alert alert3 = new Alert("Payer le loyer");
            Alert alert4 = new Alert("Bonne année");
            Alert alert5 = new Alert("Prends ton médicament");

            AlertOnSpecificDayName alertOnSpecificDayName = new AlertOnSpecificDayName("Cours à la Fac", DayName.Wednesday);
            AlertOnSpecificDayName alertOnSpecificDayName2 = new AlertOnSpecificDayName("Va faire tes quêtes quotidiennes sur Magic Arena", DayName.Sunday);

            /*calendar.OnNewDay += alert1.DisplayMessage;
            calendar.OnNewWeek += alert2.DisplayMessage;
            calendar.OnNewMonth += alert3.DisplayMessage;
            calendar.OnNewYear += alert4.DisplayMessage;*/
            calendar.OnNewDay += alert5.DisplayMessage;

            calendar.OnNewDay += alertOnSpecificDayName.DisplayMessage;
            calendar.OnNewDay += alertOnSpecificDayName2.DisplayMessage;

            for (int i = 0; i < 1000; i++)
            {
                calendar.NextDay();
                Console.WriteLine(calendar);

                if(i == 10)
                {
                    calendar.OnNewDay -= alert5.DisplayMessage;
                }
            }
        }
    }
}