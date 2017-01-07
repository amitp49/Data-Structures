using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ArrayRunner : IRunner
    {
		void IRunner.Run()
		{

			MyArray<int> myArray = new MyArray<int>(16)
			{
				Arr = new int[] { 12, 15, 10, 11, 5, 6, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2 }
			};
			myArray.PrintElementsWhichDoesntHaveAnyHigerOnTheirRight();

			int sum = 15;
			//myArray.PrintElementsHavingSumAs(sum);
			myArray.PrintElementsHavingSumAsUsingDictionary(sum);

			Console.WriteLine("Majority element : " + myArray.FindMajorityElement());

			MyArray<int> myArray2 = new MyArray<int>(9)
			{
				Arr = new int[] { 5, 5, 2, 2, 2, 2, 6, 6, 6 }
			};
			Console.WriteLine("Odd occurance from array where all other are even is:" + myArray2.FindOddOccuranceNumberFromEvenArray());

			myArray2.LeftRotate(3);
			myArray2.Print();

			bool[,] knows = new bool[4, 4] {
				{false,false,false,false},
				{false,false,false,false},
				{false,false,false,false},
				{false,false,false,false}
			};
			ArrayAlgos.PrintCelebrity(knows);

			List<Interval> listOfIntervals = new List<Interval>();
			listOfIntervals.Add(new Interval(6, 8));
			listOfIntervals.Add(new Interval(1, 9));
			listOfIntervals.Add(new Interval(2, 4));
			listOfIntervals.Add(new Interval(4, 7));

			List<Interval> listOfMergedIntervals = ArrayAlgos.GetOverLappingIntervals(listOfIntervals);
			foreach (var item in listOfMergedIntervals)
			{
				Console.WriteLine("(" + item.Start + "," + item.End + ")");
			}

			int[] arr = new int[] { 1, 4, 45, 6, 10, 8 };
			ArrayAlgos.FindTripletsHavingSumAs(arr, 22);

			Console.ReadLine();

		}
	}
}
