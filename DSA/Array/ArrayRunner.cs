using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class ArrayRunner : IRunner
    {
        public void Run()
        {
            MyArray<int> myArray = new MyArray<int>(8) 
            { 
                Arr = new int[] {12,15,10,11,5,6,2,3} 
            };
            myArray.PrintElementsWhichDoesntHaveAnyHigerOnTheirRight();
            Console.ReadLine();
        }
    }
}
