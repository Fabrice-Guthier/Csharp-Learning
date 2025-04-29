using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public abstract class Bird
    {
        public string FeatherColor { get; set; }

        protected Bird(string featherColor)
        {
            FeatherColor = featherColor ?? throw new ArgumentNullException(nameof(featherColor));
        }
    }
}
