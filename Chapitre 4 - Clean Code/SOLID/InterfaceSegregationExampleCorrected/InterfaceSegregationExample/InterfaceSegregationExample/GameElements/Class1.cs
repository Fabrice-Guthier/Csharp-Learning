using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExample.GameElements
{
    internal class Class1 : IGameElement
    {
        public void DisplayToolTip()
        {
            throw new NotImplementedException();
        }

        public void MoveTo(Vector endPoint)
        {
            throw new NotImplementedException();
        }

        public void MoveWithTween(Vector endPoint, TweenType tween, float duration)
        {
            throw new NotImplementedException();
        }

        public void Select()
        {
            throw new NotImplementedException();
        }
    }
}
