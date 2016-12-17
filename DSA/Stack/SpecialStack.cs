using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class SpecialStack<T> : MyStack<T> where T:IComparable
    {
        //This stack will allow for getMin() and getMax() in O(1)

        MyStack<T> valueStack = new SllStack<T>();
        MyStack<T> minStack = new SllStack<T>();
        MyStack<T> maxStack = new SllStack<T>();

        public SpecialStack()
        {

        }

        public int Count
        {
            get { return valueStack.Count; }
        }

        public void Push(T data)
        {
            valueStack.Push(data);
            //critical to check empty else any garbage can come
            if(minStack.IsEmpty() || minStack.Peek().CompareTo(data) >= 0) // to handle duplicate push when equal
            {
                minStack.Push(data);
            }
            if (maxStack.IsEmpty() || maxStack.Peek().CompareTo(data) <= 0)
            {
                maxStack.Push(data);
            }
        }

        public T Peek()
        {
            return valueStack.Peek();
        }

        public T Pop()
        {
            if(!valueStack.IsEmpty())
            {
                T data = valueStack.Peek();

                //Remove min if needed
                if(minStack.Peek().CompareTo(data) == 0)
                {
                    minStack.Pop(); //discard top
                }

                //Remove max if needed
                if (maxStack.Peek().CompareTo(data) == 0)
                {
                    maxStack.Pop(); //discard top
                }

                return valueStack.Pop();
            }
            return default(T);
        }

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        public bool IsFull()
        {
            return false; //Linkedlist implemented stack can never be full until os doesn't allocate space any more
        }

        public IEnumerator<T> GetEnumerator()
        {
            return valueStack.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return valueStack.GetEnumerator();
        }

        public T GetMin()
        {
            return minStack.Peek();
        }

        public T GetMax()
        {
            return maxStack.Peek();
        }
    }
}
