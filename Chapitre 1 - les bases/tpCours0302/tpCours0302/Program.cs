using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace tpCours0302
{
    public class Program
    {
        // exercice lv1 : Faire une fonction qui calcule l'aire d'un rectangle
        public static int CalculAireRectangle(int longueur, int largeur)
        {
            return longueur * largeur;
        }

        // exercice lv2 : Faire une fonction qui prend en paramètre deux entier et qui renvoie un booléen qui est Vrai si ces deux entiers sont positifs
        public static bool TrueCheck(int firstInput, int secondInput)
        {
            if (firstInput >= 0 && secondInput >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            // correction avec une autre méthode

            //bool toReturn = false;

            //if (firstInput >= 0 && secondInput >= 0)
            //{
            //    toReturn = true;
            //}
            //else
            //{
            //    toReturn = false;
            //}

            //return toReturn;

        }

        // exercice lv3 : Faire une fonction exposant
        public static int ExposantExpression(int premierNombre, int deuxiemeNombre)
        {
            int result = 1;
            for (int i = 1; i <= deuxiemeNombre ; i++)
            {
                result *= premierNombre;
            }
            return result;

            // correction, on peut faire une vérification avec un if
            //int toReturn = 1;

            //for(int i = 1; i< deuxiemeNombre; i++)
            //{
            //    toReturn *= premierNombre;
            //}

            //return toReturn;
        }

        static void Main(string[] args)
        {
            // exercice lv1 : Faire une fonction qui calcule l'aire d'un rectangle
            int calculAire = CalculAireRectangle(12, 9);
            Console.WriteLine("L'aire du reclangle est de : " + calculAire);


            // exercice lv2 : Faire une fonction qui prend en paramètre deux entier et qui renvoie un booléen qui est Vrai si ces deux entiers sont positifs
            Console.WriteLine("Saisissez un premier nombre :");
            string inputBoolA = Console.ReadLine();
            int boolAResult = int.Parse(inputBoolA);

            Console.WriteLine("Saisissez un deuxième nombre :");
            string inputBoolB = Console.ReadLine();
            int boolBResult = int.Parse(inputBoolB);

            bool positiveNumbers = TrueCheck(boolAResult, boolBResult);

            Console.WriteLine("Le résultat est : " + positiveNumbers);


            // exercice lv3 : Faire une fonction exposant
            Console.WriteLine("Saisissez un nombre :");
            string inputNumber = Console.ReadLine();
            int number = int.Parse(inputNumber);

            Console.WriteLine("Saisissez un exposant :");
            string inputExpo = Console.ReadLine();
            int expo = int.Parse(inputExpo);

            int multiplication = ExposantExpression(number, expo);
            Console.WriteLine("Le résultat de l'opération est : " + multiplication);


            Console.ReadLine(); // on gqrde bien ce reqdline pour que la fenêtre reste ouverte
        }       
    }
}
