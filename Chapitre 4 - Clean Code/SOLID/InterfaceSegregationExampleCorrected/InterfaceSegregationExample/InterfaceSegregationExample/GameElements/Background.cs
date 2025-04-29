using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExample.GameElements
{
    class Background : IDisplayableTooltip, ISelectable
    {
        public string Tip { get; set; }

        public void DisplayToolTip()
        {
            Console.WriteLine(Tip);
        }

        public void Select()
        {
            Console.WriteLine(Tip);
        }
    }
}
