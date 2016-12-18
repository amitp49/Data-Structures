using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class CircularArrayQueue<T> : MyQueue<T> where T: IComparable
    {
        private T[] arr;
        private int capacity;
        private int front;
        private int rear;

        public int Count
        {
            get 
            { 
                if(rear>=front)
                {
                    return (rear - front); 
                }
                else
                {
                    return (this.capacity - front) + (rear);
                }
            }
        }

        public CircularArrayQueue(int capacity)
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
            return (this.Count == (this.capacity-1)); //This is critical. One space would be wasted always
        }

        public void EnQueue(T data)
        {
            if(!this.IsFull())
            {
                this.arr[this.rear] = data;
                this.rear = (this.rear + 1) % this.capacity;
                return;
            }
            throw new Exception("Queue is full");
        }

        public T DeQueue()
        {
            if(!this.IsEmpty())
            {
                T data = this.arr[front];
                this.front = (this.front + 1) % this.capacity;
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
