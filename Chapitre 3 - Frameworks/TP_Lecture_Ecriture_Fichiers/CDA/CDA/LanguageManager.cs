using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDA
{
    public static class LanguageManager
    {
        public static int CurrentLanguage { get; set; }
        const char SEPARATOR = ';';

        public static string GetMatByKey(string key)
        {
            string toReturn = "";

            string fileName = @"Datas\LanguageMats.csv";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + fileName;

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] cells = line.Split(SEPARATOR);

                if(cells[0] == key)
                {
                    toReturn = cells[CurrentLanguage];
                    break;
                }
            }

            return toReturn;
        }
    }
}
