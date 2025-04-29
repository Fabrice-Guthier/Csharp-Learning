using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationExample
{
    interface IGameElement : IMovable, ISelectable, IDisplayableTooltip
    {
        
    }
}
