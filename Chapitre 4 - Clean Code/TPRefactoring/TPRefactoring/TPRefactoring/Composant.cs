using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class Composant
    {
        public string Type { get; set; }
        public List<int> Dimensions { get; set; } //c'est une liste car selon le composant, il peut y avoir un nombre différent de dimensions (hauteur, largeur, longueur etc...)

        public Composant(string type, List<int> dimensions)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
        }
    }
}
