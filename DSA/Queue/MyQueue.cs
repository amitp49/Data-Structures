using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    interface MyQueue<T> where T: IComparable
    {
        int Count { get;  }
        bool IsEmpty();
        bool IsFull();
        void EnQueue(T data);
        T DeQueue();
        T Peek();
    }
}
