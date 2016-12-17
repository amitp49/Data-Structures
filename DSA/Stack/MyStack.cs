using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public interface MyStack<T> : IEnumerable<T> where T : IComparable
    {
        int Count { get; }

        void Push(T data);

        T Peek();

        T Pop();
        bool IsEmpty();

    }
}
