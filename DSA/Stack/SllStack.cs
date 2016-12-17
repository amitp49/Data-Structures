using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class SllStack<T> : IEnumerable<T> where T: IComparable
    {
        private SinglyLinkedList<T> linkedList = new SinglyLinkedList<T>();

        public int Count { get; private set; }

        public SllStack()
        {

        }

        public void Push(T data)
        {
            linkedList.PushToHead(data);
            Count++;
        }

        public T Pop()
        {
            if(Count>0)
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


        public IEnumerator<T> GetEnumerator()
        {
            SllNode<T> current = linkedList.Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
            
        }
    }
}
