﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class ArrayStack<T>: IEnumerable<T> where T: IComparable
    {
        private T[] arr;
        private int capacity;
        public int Count { get; private set; } //will alway point to top empty space

        public ArrayStack(int capacity)
        {
            arr = new T[capacity];
            this.capacity = capacity;
            this.Count = 0;
        }

        public void Push(T data)
        {
            if(!IsFull())
            {
                this.arr[this.Count] = data;
                this.Count++;
            }
        }

        public T Pop()
        {
            if(!IsEmpty())
            {
                this.Count--;
                return this.arr[this.Count];
            }
            return default(T);
        }

        public T Peek()
        {
            //Do not remove item, just return top item
            if (!IsEmpty())
            {
                return this.arr[this.Count-1];
            }
            return default(T);
        }

        public void ClearAll()
        {
            this.arr = new T[this.capacity];
            this.Count = 0;
        }

        private bool IsEmpty()
        {
            return (this.Count == 0);
        }

        private bool IsFull()
        {
            return (this.Count >= this.capacity);
        }
    
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = this.Count-1; i >=0; i--)
            {
                yield return this.arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.arr[i];
            }
        }
    }
}
