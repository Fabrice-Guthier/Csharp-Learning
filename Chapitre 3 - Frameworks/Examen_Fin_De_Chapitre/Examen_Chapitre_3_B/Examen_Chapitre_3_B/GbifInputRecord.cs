using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Chapitre_3_B
{
    public class GbifInputRecord
    {
        [Name("gbifID")]
        public long GbifID { get; set; }

        [Name("year")]
        public int? Year { get; set; }

        [Name("basisOfRecord")]
        public string BasisOfRecord { get; set; }
    }
}
