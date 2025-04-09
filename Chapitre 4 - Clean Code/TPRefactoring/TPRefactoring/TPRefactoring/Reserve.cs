using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class Reserve
    {
        public Composant ComposantsStockes { get; set; } //type de composant stocké dans cette réserve
        public int Quantite { get; set; }

        public Reserve(Composant composantsStockes, int quantite)
        {
            ComposantsStockes = composantsStockes ?? throw new ArgumentNullException(nameof(composantsStockes));
            Quantite = quantite;
        }
    }
}
