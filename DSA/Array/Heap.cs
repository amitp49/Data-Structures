// /Users/amitp/Documents/dsa/DSA/Array/Heap.cs
// amitp
// (c) Amit Patel
// 02-01-2017
using System;
using System.Collections.Generic;
using System.Collections;
namespace Arrays
{
	public enum HeapType
	{
		MinHeap,
		MaxHeap
	}

	public class ReverseComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			return Comparer.Default.Compare(y,x);
		}
	}

	public class Heap
	{
		public int[] arr
		{
			get;
			set;
		}

		private HeapType heapType;
		private IComparer comparer;

		public int CurrentSize
		{
			get;
			set;
		}

		public int MaxSize
		{
			get;
			set;
		}

		public object Current
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public Heap(int maxSize, HeapType heapType)
		{
			this.MaxSize = maxSize;
			this.CurrentSize = 0;
			this.heapType = heapType;
		}

		public Heap(int[] arr, HeapType heapType)
		{
			this.arr = arr;
			this.MaxSize = arr.Length;
			this.CurrentSize = arr.Length;
			this.heapType = heapType;
		}

		public void Sort()
		{
			int n = arr.Length;
			BuildHeap(n);

			for (int i = n-1; i >=0; i--)
			{
				SwapData(i, 0);
				CurrentSize--;
				HeapifyDown(CurrentSize-1,0);
			}

			CurrentSize = MaxSize; //restore
		}

		private void BuildHeap(int n)
		{
			for (int i = n/2-1; i >=0; i--)
			{
				HeapifyDown(n,i);
			}
		}

		private void HeapifyDown(int currentSize, int elementIndex)
		{
			if (heapType == HeapType.MinHeap)
			{
				comparer = Comparer.Default;
			}
			else if(heapType == HeapType.MaxHeap)
			{
				comparer = new ReverseComparer();
			}

			int childIndex = elementIndex;
			int leftChildIndex = elementIndex * 2 + 1;
			int rightChildIndex = elementIndex * 2 + 2;

			if (leftChildIndex < currentSize && comparer.Compare(arr[leftChildIndex], arr[elementIndex]) > 0)
			{
				childIndex = leftChildIndex;
			}

			if (rightChildIndex < currentSize && comparer.Compare(arr[rightChildIndex], arr[childIndex]) > 0)
			{
				childIndex = rightChildIndex;
			}

			if (childIndex != elementIndex)
			{
				SwapData(childIndex,elementIndex);
				HeapifyDown(currentSize,childIndex);
			}
		}

		private void SwapData(int childIndex, int elementIndex)
		{
			int temp = this.arr[childIndex];
			this.arr[childIndex] = this.arr[elementIndex];
			this.arr[elementIndex] = temp;
		}


	}
}

