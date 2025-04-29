using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class Rectangle
    {
        public virtual float width { get; set; }
        public virtual float height { get; set; }

        public Rectangle(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
