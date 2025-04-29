using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public abstract class BirdFlying : Bird
    {
        public BirdFlying(string featherColor) : base(featherColor)
        {
        }

        public abstract void Fly();
    }
}
