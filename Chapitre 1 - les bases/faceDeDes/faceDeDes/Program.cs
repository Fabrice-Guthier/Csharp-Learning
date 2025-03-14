using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faceDeDes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int faceDe = 0;
            var randomNumber = new Random();
            

            int resultatJet = 0;

            Console.WriteLine("Saisissez un nombre de dés á lancer :");
            string saisieNombreDeDes = Console.ReadLine();
            int nombreDeDes = int.Parse(saisieNombreDeDes);

            while (nombreDeDes > 0)
            {
                faceDe = randomNumber.Next(1, 6);
                if (faceDe == 1)
                {
                    Console.WriteLine("<<   >>");
                    Console.WriteLine("<< 0 >>");
                    Console.WriteLine("<<   >>");
                    Console.WriteLine();
                }
                if (faceDe == 2)
                {
                    Console.WriteLine("<< 0 >>");
                    Console.WriteLine("<<   >>");
                    Console.WriteLine("<< 0 >>");
                    Console.WriteLine();
                }
                if (faceDe == 3)
                {
                    Console.WriteLine("<< 0 >>");
                    Console.WriteLine("<< 0 >>");
                    Console.WriteLine("<< 0 >>");
                    Console.WriteLine();
                }
                if (faceDe == 4)
                {
                    Console.WriteLine("<<0 0>>");
                    Console.WriteLine("<<   >>");
                    Console.WriteLine("<<0 0>>");
                    Console.WriteLine();
                }
                if (faceDe == 5)
                {
                    Console.WriteLine("<<0 0>>");
                    Console.WriteLine("<< 0 >>");
                    Console.WriteLine("<<0 0>>");
                    Console.WriteLine();
                }
                if (faceDe == 6)
                {
                    Console.WriteLine("<<0 0>>");
                    Console.WriteLine("<<0 0>>");
                    Console.WriteLine("<<0 0>>");
                    Console.WriteLine();
                }

                nombreDeDes--;
                resultatJet += faceDe;
            }
        Console.WriteLine("Le résultat du jet de dés est de : " + resultatJet);
        Console.ReadLine();
        }
    }
}
