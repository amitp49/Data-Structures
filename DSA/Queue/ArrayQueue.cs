using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class ArrayQueue<T> : MyQueue<T> where T: IComparable
    {
        private T[] arr;
        private int capacity;
        private int front;
        private int rear;

        public int Count
        {
            get { return rear - front; }
        }

        public ArrayQueue(int capacity)
        {
            this.capacity = capacity;
            this.arr = new T[capacity];
            this.front = 0;
            this.rear = 0;
        }

        public bool IsEmpty()
        {
            return (this.Count == 0);
        }

        public bool IsFull()
        {
            return (rear >= this.capacity);
        }

        public void EnQueue(T data)
        {
            if(!this.IsFull())
            {
                this.arr[this.rear] = data;
                this.rear++;
            }
        }

        public T DeQueue()
        {
            if(!this.IsEmpty())
            {
                T data = this.arr[front];
                this.front++;
                return data;
            }
            return default(T);
        }

        public T Peek()
        {
            if (!this.IsEmpty())
            {
                T data = this.arr[front];
                return data;
            }
            return default(T);
        }
    }
}
