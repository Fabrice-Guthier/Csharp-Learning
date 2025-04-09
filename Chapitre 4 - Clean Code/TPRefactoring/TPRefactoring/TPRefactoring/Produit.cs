using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class Produit
    {
        public string Type { get; set; }

        public Dictionary<string, int> ComposantsNecessaires { get; set; } //nombre de composants nécessaire à la fabrication du produit

        public string Etiquetage { get; set; }

        public Produit(string type, Dictionary<string, int> composantsNecessaires)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            ComposantsNecessaires = composantsNecessaires ?? throw new ArgumentNullException(nameof(composantsNecessaires));
        }
    }
}
