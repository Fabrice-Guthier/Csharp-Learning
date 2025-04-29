using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class Square : Rectangle
    {
        public override float height { get => base.height;
            set
            { 
                height = value;
                width = value;
            }
        }

        public override float width { 
            get => base.width; 
            set
            {
                height = value;
                width = value;
            }
        }
        public Square(float width, float height) : base(width, height)
        {
        }
    }
}
