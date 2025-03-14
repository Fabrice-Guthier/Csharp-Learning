using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tp_POO_Genericite_1902
{
    class ListLifo<T> : MainList<T>
    {

        public override T Get()
        {
            return elements.Last();
        }
        public override void Remove()
        {
            int index = elements.Count - 1;
            elements.RemoveAt(index);
        }
        public override T GetAndRemove()
        {
            element = Get();
            Remove();

            return element;
        }

        

    }
}
