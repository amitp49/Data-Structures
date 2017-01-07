// /Users/amitp/Documents/dsa/DSA/Heaps/HeapRunner.cs
// amitp
// (c) Amit Patel
// 07-01-2017
using System;
using Interfaces;

namespace Heaps
{
	public class HeapRunner: IRunner
	{
		void IRunner.Run()
		{
			Heap<int> heap = new Heap<int>(new int[] { 12, 15, 10, 11, 5, 6, 2 }, HeapType.MinHeap);
			heap.Sort();
			foreach (var item in heap.arr)
			{
				Console.WriteLine(item + ", ");
			}

			Console.ReadLine();
			
		}
	}
}
