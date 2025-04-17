using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExercise
{
    internal class Drawer
    {
        public virtual void DrawShape(Shape toDraw)
        {
            toDraw.Draw();
        }
    }
}
