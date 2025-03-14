using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpTableaux0502
{
    internal class Program
    {
        //lv2 
        internal static float tableauCalculMoyenne(float[] nombres)
        {
            //corrigé
            float aRenvoyer = 0f;

            float cumulDesNotes = 0f;
            foreach (float nonbre in nombres)
            {
                aRenvoyer += nonbre;
            }
            aRenvoyer /= nombres.Length;


            //for (int i = 0; i < nombres.Length; i++)
            //{
            //    cumulDesNotes += nombres[i];
            //}

            //float noteMoyenne = cumulDesNotes / calculMoyenne.Length;
            //Console.WriteLine(noteMoyenne);
        }

        //lv3
        

        static void Main(string[] args)
        {
            //lv1 
            string[] firstNameTable = new string[4];

            firstNameTable[0] = "Fabrice";
            firstNameTable[1] = "Émilie";
            firstNameTable[2] = "Christopher";
            firstNameTable[3] = "Michel";

            for (int i = 0; i < firstNameTable.Length; i++)
            {
                Console.WriteLine(firstNameTable[i]);
            }
            //foreach (string firstName in firstNameTable)
            //{
            //    Console.WriteLine(firstNameTable[firstName]);
            //}

            //lv2
            //corrigé
            float[] notes = { 20f, 19f, 18f, 17f };
            Console.WriteLine(tableauCalculMoyenne(notes));

            //float[] tableauDesNotes = new float[5];
            //tableauDesNotes[0] = 14.5f;
            //tableauDesNotes[1] = 12f;
            //tableauDesNotes[2] = 12.5f;
            //tableauDesNotes[3] = 9f;
            //tableauDesNotes[4] = 10.5f;

            //tableauCalculMoyenne(tableauDesNotes);
            //

            //lv3
           
            //


            Console.ReadLine();
        }

    }
  
}
