using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class DllStack<T> : MyStack<T>, IEnumerable<T> where T: IComparable
    {
        private DoublyLinkedList<T> linkedList = new DoublyLinkedList<T>();

        public int Count { get; private set; }

        public DllStack()
        {

        }

        public void Push(T data)
        {
            linkedList.PushToHead(data);
            Count++;
        }

        public T Pop()
        {
            if (Count > 0)
            {
                Count--;
                return linkedList.DeleteHeadNode().Data;
            }
            return default(T);
        }

        public T Peek()
        {
            if (Count > 0)
            {
                return linkedList.Head.Data;
            }
            return default(T);
        }

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            DllNode<T> current = linkedList.Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
