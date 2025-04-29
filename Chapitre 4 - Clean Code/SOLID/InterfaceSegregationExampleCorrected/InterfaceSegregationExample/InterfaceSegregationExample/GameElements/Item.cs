using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExample.GameElements
{
    class Item : IDisplayableTooltip, IMovable
    {
        public string Tip { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }

        public Item(string tip, float posX, float posY)
        {
            Tip = tip ?? throw new ArgumentNullException(nameof(tip));
            PosX = posX;
            PosY = posY;
        }

        public void DisplayToolTip()
        {
            Console.WriteLine(Tip);
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
    }
}
