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
        private DllNode<T> middleNode = null;

        public int Count { get; private set; }

        public DllStack()
        {

        }

        public void Push(T data)
        {
            linkedList.PushToHead(data);
            Count++;

            //update middle node
            if (middleNode == null)
            {
                middleNode = linkedList.Head;
            }
            else if(Count%2==0) //added new node to make even list, move middle
            {
                middleNode = middleNode.Prev;
            }
        }

        public T Pop()
        {
            if (Count > 0)
            {
                Count--;
                T data = linkedList.DeleteHeadNode().Data;

                //update middle node
                if(Count==0)
                {
                    middleNode = null;
                }
                else if(Count%2!=0)
                {
                    middleNode = middleNode.Next;
                }

                return data;
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

        public T GetMiddleNodeData()
        {
            if(middleNode!=null)
            {
                return middleNode.Data;
            }
            return default(T);
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
