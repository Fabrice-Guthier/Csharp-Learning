using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExercise
{
    class Square : Shape
    {
        public float Side { get; set; }
        public Vector Center { get; set; }

        public Square(float side, Vector center)
        {
            Side = side;
            Center = center ?? throw new ArgumentNullException(nameof(center));
        }

        public override void Draw()
        {
            Console.WriteLine("I'm drawing a " + Side + "px side square with " + Center + " as center coordinate");
        }
    }
}
