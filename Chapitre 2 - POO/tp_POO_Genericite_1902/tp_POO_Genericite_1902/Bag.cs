using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tp_POO_Genericite_1902
{
    class Bag<T> : MainList<T>
    {
        private Random rand = new Random();
        private int index = 0;
        private int RandomNumber(List<T> liste)
        {
            return rand.Next(liste.Count);
        }
        public override T Get()
        {
            index = RandomNumber(elements);
            return elements[index];
        }

        public override void Remove()
        {
            index = RandomNumber(elements);
            elements.RemoveAt(index);
        }
        public override T GetAndRemove()
        {
            index = RandomNumber(elements);
            element = elements[index];

            elements.RemoveAt(index);

            return element;
        }

        
    }
}
