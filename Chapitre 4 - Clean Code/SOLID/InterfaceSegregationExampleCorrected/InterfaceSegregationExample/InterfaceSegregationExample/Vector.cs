using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExample
{
    class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
