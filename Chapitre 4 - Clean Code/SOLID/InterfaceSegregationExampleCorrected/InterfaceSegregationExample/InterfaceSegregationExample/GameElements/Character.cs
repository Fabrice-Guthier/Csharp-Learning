using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExample.GameElements
{
    class Character : IMovable, ISelectable
    {
        public float PosX { get; set; }
        public float PosY { get; set; }

        public Character(float posX, float posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public void MoveTo(Vector endPoint)
        {
            PosX = endPoint.X;
            PosY = endPoint.Y;
        }

        public void MoveWithTween(Vector endPoint, TweenType tween, float duration)
        {
            while (PosX != endPoint.X && PosY != endPoint.Y)
            {
                System.Threading.Thread.Sleep(10);
                PosX += endPoint.X / (duration * 100);

                PosY += endPoint.Y / (duration * 100);
            }
        }

        public void Select()
        {
            Console.WriteLine("I'm selected !");
        }
    }
}
