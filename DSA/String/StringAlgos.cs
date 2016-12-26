using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    public class StringAlgos
    {
        public static void PrintAllPermutations(string str)
        {
            PrintAllPermutationsInternalUtil(str.ToCharArray(),0,str.Length-1);
        }

        private static void PrintAllPermutationsInternalUtil(char[] arr, int low, int high)
        {
            if (low > high)
            {
                PrintCharArray(arr);
                return;
            }
            else
            {
                for (int i = low; i <= high; i++)
                {
                    Swap(arr,low,i);
                    PrintAllPermutationsInternalUtil(arr, low + 1, high);
                    Swap(arr, low, i);

                }
            }
        }

        private static void Swap(char[] arr, int low, int i)
        {
            char temp = arr[low];
            arr[low] = arr[i];
            arr[i] = temp;
        }

        private static void PrintCharArray(char[] arr)
        {
            //Print arr
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
