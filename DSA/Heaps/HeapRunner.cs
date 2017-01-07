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
			Heap<int> heap = new Heap<int>(new int[] { 12, 15, 10, 11, 50, 6, 2 }, HeapType.MinHeap);
			heap.Sort();
			foreach (var item in heap.arr)
			{
				Console.WriteLine(item + ", ");
			}
			Console.WriteLine("---------");

			VertexNode vx = new VertexNode(4, 5);
			VertexNode[] arr = new VertexNode[7] { 
				new VertexNode(0,12),
				new VertexNode(1,15),
				new VertexNode(2,10),
				new VertexNode(3,11),
				vx,
				new VertexNode(5,60),
				new VertexNode(6,2)
			};

			Heap<VertexNode> minHeapOfObj = new Heap<VertexNode>(arr,HeapType.MinHeap);
			//minHeapOfObj.Sort();
			vx.Key = 50;
			minHeapOfObj.UpdateHeapForChangedPriority(vx);

			foreach (var item in minHeapOfObj.arr)
			{
				Console.WriteLine(item.Key + ", ");
			}
			Console.ReadLine();
			
		}
	}
}
