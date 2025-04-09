using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class Bac
    {
        public Produit TypeBac { get; set; } //type de produit stocké dans cette réserve

        public List<Produit> ProduitsStockes { get; set; }

        public Bac(Produit typeBac)
        {
            TypeBac = typeBac;
            ProduitsStockes = new List<Produit>();
        }
    }
}
