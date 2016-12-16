using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class MyArray<T> where T : IComparable
    {
        private int size;
        
        public T[] Arr { get; set; }

        public MyArray(int size)
        {
            this.size = size;
            this.Arr = new T[size];
        }

        public T this[int index]
        {
            get { return Arr[index]; }
            set { Arr[index] = value; }
        }

        public void PrintElementsWhichDoesntHaveAnyHigerOnTheirRight()
        {
            T runningMax = default(T);
            //Lets have another array of same size to store running max from end
            T[] another = new T[this.size];

            for (int i = this.size - 1; i >= 0; i--)
            {
                if (runningMax.CompareTo(Arr[i]) < 0)
                    runningMax = Arr[i];

                another[i] = runningMax;
            }

            //Now we will print element only if greater or equal then another 
            for (int i = 0; i < this.size; i++)
            {
                if(Arr[i].CompareTo(another[i]) >= 0)
                    Console.WriteLine(Arr[i] + ",");
            }
        }
    }
}
