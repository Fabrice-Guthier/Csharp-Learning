using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class TapisRoulant
    {
        public List<Produit> ProduitsSurLeTapis { get; set; }

        public TapisRoulant()
        {
            ProduitsSurLeTapis = new List<Produit>();
        }
    }
}
