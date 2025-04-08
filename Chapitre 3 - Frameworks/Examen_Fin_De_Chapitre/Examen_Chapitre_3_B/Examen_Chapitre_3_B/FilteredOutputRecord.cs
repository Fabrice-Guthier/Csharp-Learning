using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Chapitre_3_B
{
    public class FilteredOutputRecord
    {
        [Index(0)]
        public int? Year { get; set; }

        [Index(1)]
        public long GbifID { get; set; }
    }
}
