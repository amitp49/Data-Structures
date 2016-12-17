using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MyArray<T> where T : IComparable
    {
        private int size;


        public T[] Arr { get; set; }

        public MyArray()
        {
            this.size = 0;
            this.Arr = null;
        }

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

        public T FindMajorityElement()
        {
            //Element which occurs > n/2 times

            //Find possible candidate
            T element = FindPossibleMajorityElement();

            //Confirm if possible candidate is actually majority element
            bool confirmation = ConfirmMajorityElement(element);

            if(confirmation==true)
            {
                return element;
            }
            return default(T);
        }

        private T FindPossibleMajorityElement()
        {
            int possibleMajorityElementIndex = 0; //Lets say first element is majority element
            int count = 1; // Increase count as 1 because we have considered first element as majority

            for (int i = 1; i < this.size; i++)
            {
                if(this.Arr[i].CompareTo(this.Arr[possibleMajorityElementIndex]) == 0)
                {
                    count++;
                }
                else
                {
                    count--;
                }

                //Critical : at any point if count drops to zero then possible majority candidate is out of race, and we will pick up new candidate
                if(count==0)
                {
                    possibleMajorityElementIndex = i;
                    count = 1;
                }
            }
            return this.Arr[possibleMajorityElementIndex];
        }

        private bool ConfirmMajorityElement(T element)
        {
            int count = 0;
            for (int i = 0; i < this.size; i++)
            {
                if(this.Arr[i].CompareTo(element) == 0)
                {
                    count++;
                }
            }

            //check and confirm
            return (count > this.size / 2);
        }

        public void PrintElementsHavingSumAsUsingDictionary(int sum)
        {
            Dictionary<int, bool> dictionary = new Dictionary<int, bool>();

            for (int i = 0; i < this.size; i++)
            {
                if (dictionary.ContainsKey(Convert.ToInt32(this.Arr[i])) == false)
                    dictionary.Add(Convert.ToInt32(this.Arr[i]),true);
            }

            for (int i = 0; i < this.size; i++)
            {
                if(dictionary.ContainsKey(sum - Convert.ToInt32(this.Arr[i])))
                {
                    Console.WriteLine("Pair:" + (sum - Convert.ToInt32(this.Arr[i])) + " + " + Convert.ToInt32(this.Arr[i]) + " = " + sum);
                    //remove key from dictionary, so that reverse duplicate pair does not print again
                    dictionary.Remove(Convert.ToInt32(this.Arr[i]));
                }
            }
        }

        public void PrintElementsHavingSumAs(int sum)
        {
            //Make another copy if we need to modify it for this function purpose only
            T[] anotherCopy = new T[this.size];
            Array.Copy(this.Arr,anotherCopy,this.size);

            //Sort given copy array
            Array.Sort(anotherCopy);

            //Take two indexes and find sum
            int start = 0;
            int end = this.size-1;

            for (int i = start, j = end; i < j;)
            {
                if (Convert.ToInt32(anotherCopy[i]) + Convert.ToInt32(anotherCopy[j]) > sum)
                {
                    j--;
                }
                else if(Convert.ToInt32(anotherCopy[i]) + Convert.ToInt32(anotherCopy[j]) < sum)
                {
                    i++;
                }
                else // found sum
                {
                    Console.WriteLine("Pair:" + anotherCopy[i] + " + " + anotherCopy[j] + " = " + sum);
                    i++;
                    j--;
                }
            }
        }
    }
}
