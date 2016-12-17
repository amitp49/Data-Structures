﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ArrayRunner : IRunner
    {
        public void Run()
        {
            MyArray<int> myArray = new MyArray<int>(16) 
            { 
                Arr = new int[] {12,15,10,11,5,6,2,3,2,2,2,2,2,2,2,2} 
            };
            myArray.PrintElementsWhichDoesntHaveAnyHigerOnTheirRight();

            int sum = 15;
            //myArray.PrintElementsHavingSumAs(sum);
            myArray.PrintElementsHavingSumAsUsingDictionary(sum);

            Console.WriteLine("Majority element : " +  myArray.FindMajorityElement());
            Console.ReadLine();

            
        }
    }
}
