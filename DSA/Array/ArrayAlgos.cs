using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ArrayAlgos
    {
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
