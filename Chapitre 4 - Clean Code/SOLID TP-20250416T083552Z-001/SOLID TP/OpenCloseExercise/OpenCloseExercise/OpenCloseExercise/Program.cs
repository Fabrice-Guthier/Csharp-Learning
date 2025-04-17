using System;

namespace OpenCloseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(5.2f, new Vector(0f, 1.5f));
            Square s = new Square(2.2f, new Vector(1f, 2f));

            Drawer drawer = new Drawer();

            drawer.DrawShape(s);
            drawer.DrawShape(c);

        }
    }
}
