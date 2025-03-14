using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSampleCode
{
    public class CustomStack
    {
        private readonly List<int> _list = new List<int>();

        public int Count()
        {
            return _list.Count;
        }

        public void Push(int value)
        {
            _list.Add(value);
        }

        public int Pop()
        {
            if (Count() == 0)
                throw new StackCantBeEmptyException("Can't call Pop on an empty stack.");

            var poped = _list[_list.Count - 1]; // On cherche le dernier élément
            _list.Remove(poped);

            return poped;
        }

        // Cette classe n'a pas a être testée individuellement
        public class StackCantBeEmptyException : Exception
        {
            public StackCantBeEmptyException(string? message) : base(message)
            {
            }
        }
    }


}
