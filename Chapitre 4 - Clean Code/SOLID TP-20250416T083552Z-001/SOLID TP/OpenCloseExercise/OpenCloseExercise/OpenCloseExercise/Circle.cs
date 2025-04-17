using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExercise
{
    class Circle : Shape
    {
        public float Radius { get; set; }
        public Vector Center { get; set; }

        public Circle(float radius, Vector center)
        {
            Radius = radius;
            Center = center ?? throw new ArgumentNullException(nameof(center));
        }

        public override void Draw()
        {
            Console.WriteLine("I'm drawing a " + Radius + "px radius circle with " + Center + " as center coordinate");
        }
    }
}
