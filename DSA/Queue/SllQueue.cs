using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class SllQueue<T> : MyQueue<T> where T: IComparable
    {
        SinglyLinkedList<T> linkedList = new SinglyLinkedList<T>();
        SllNode<T> front;
        SllNode<T> rear;

        public SllQueue()
        {
            front = null;
            rear = null;
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsEmpty()
        {
            return (this.front == null && this.rear==null);
        }

        public bool IsFull()
        {
            return false; //cannt be full as this is linked list
        }

        public void EnQueue(T data)
        {
            SllNode<T> newNode = new SllNode<T>(data);

            if (this.linkedList.Head==null)
            {
                this.linkedList.PushToHead(newNode);
                this.front = newNode;
                this.rear = newNode;
            }
            else
            {
                this.rear.Next = newNode;
                this.rear = newNode;
            }
            this.Count++;
        }

        public T DeQueue()
        {
            if(!this.IsEmpty())
            {
                T data =  this.front.Data;
                this.front = this.front.Next;

                this.Count--;
                if (this.Count == 0)
                {
                    this.front = null;
                    this.rear = null;
                }

                return data;
            }
            return default(T);
        }

        public T Peek()
        {
            if (!this.IsEmpty())
            {
                return this.front.Data;
            }
            return default(T);
        }
    }
}
