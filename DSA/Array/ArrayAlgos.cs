using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ArrayAlgos
    {
        public static void FindTripletsHavingSumAs(int[] arr, int Sum)
        {
            Array.Sort(arr);
            int size = arr.Length;

            for (int index = 0; index < size-2; index++)
            {
                int current = arr[index];
                int remaining = Sum - current;
                int i = index + 1;
                int j = size - 1;

                while (i < j)
                {
                    if(arr[i]+arr[j]==remaining)
                    {
                        Console.WriteLine("Triplet: " + arr[i] + " + " + arr[j] + " + " + current + " = " + Sum );
                        i++;
                        j--;
                    }
                    else if(arr[i]+arr[j] < remaining)
                    {
                        i++;
                    }
                    else // if(arr[i]+arr[j] > remaining)
                    {
                        j--;
                    }
                }
            }
        }
        public static List<Interval> GetOverLappingIntervals(List<Interval> listOfIntervals)
        {
            List<Interval> listOfMergedInterval = new List<Interval>();

            listOfIntervals.Sort();
            listOfMergedInterval.Add(listOfIntervals[0]);

            for (int i = 1; i < listOfIntervals.Count; i++)
            {
                if (listOfIntervals[i].Start < listOfMergedInterval[listOfMergedInterval.Count - 1].End)
                {
                    listOfMergedInterval[listOfMergedInterval.Count - 1].End = listOfIntervals[i].End;
                }
                else
                {
                    listOfMergedInterval.Add(listOfIntervals[i]);
                }
            }

            return listOfMergedInterval;
        }
        /// <summary>
        /// It should give person who doesn't know anybody, but all others knows him
        /// </summary>
        /// <param name="acquaintance">acquaintance is square matrix represent if person I knows person J</param>
        public static void PrintCelebrity(bool[,] acquaintance)
        {
            int start = 0, end=0;
            int size = acquaintance.GetLength(1);
            Dictionary<int, bool> canBeCelebrity = new Dictionary<int, bool>();
            for (int i = 0; i < size; i++)
            {
                canBeCelebrity.Add(i,true);
            }

            for (start=0,end=size-1; start < end; start++,end--)
            {
                if(acquaintance[start,end])
                {
                    canBeCelebrity[start] = false;
                    start++;
                }

                if(acquaintance[end,start])
                {
                    canBeCelebrity[end] = false;
                    end--;
                }
            }

            // Confirm Celebrity
            for (int i = 0; i < size; i++)
            {
                if(acquaintance[start,i])
                {
                    Console.WriteLine("No celebrity found.");
                    return;
                }
            }

            Console.WriteLine("Celebrity: " + start);
        }
    }
}
