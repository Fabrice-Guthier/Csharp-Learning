using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExample
{
    internal interface IMovable
    {
        void MoveTo(Vector endPoint);
        void MoveWithTween(Vector endPoint, TweenType tween, float duration);
    }
}
