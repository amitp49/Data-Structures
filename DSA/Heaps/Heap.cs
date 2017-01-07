// /Users/amitp/Documents/dsa/DSA/Array/Heap.cs
// amitp
// (c) Amit Patel
// 02-01-2017
using System;
using System.Collections.Generic;
using System.Collections;
namespace Heaps
{
	public class Heap<T> where T:IComparable
	{
		public T[] arr
		{
			get;
			set;
		}

		private HeapType heapType;
		private IComparer comparer;
		private Dictionary<T, int> reverseMapping = new Dictionary<T, int>();

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

		private Heap(int maxSize, HeapType heapType)
		{
			this.MaxSize = maxSize;
			this.CurrentSize = 0;
			this.heapType = heapType;
			this.arr = new T[this.MaxSize];
		}

		public Heap(T[] arr, HeapType heapType)
		{
			this.arr = arr;
			this.MaxSize = arr.Length;
			this.CurrentSize = arr.Length;
			this.heapType = heapType;

			//Create reverse mapping for allowing external user to change key/pririty at run time, and we will hepify
			FillReverseMapping();
		}

		private void FillReverseMapping()
		{
			for (int i = 0; i < this.arr.Length; i++)
			{
				reverseMapping.Add(this.arr[i],i);
			}
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

		public T GetMin()
		{
			return this.arr[0];
		}

		public void RemoveMin()
		{
			SwapData(0, this.CurrentSize-1);
			CurrentSize--;
			HeapifyDown(CurrentSize, 0);
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

		public void ChangeKey(T node)
		{
			int currentIndex = reverseMapping[node];
			//TODO: still need to delete and re insert
		}

		private void SwapData(int a, int b)
		{
			T temp = this.arr[a];
			this.arr[a] = this.arr[b];
			this.arr[b] = temp;

			//Update Reverse mapping while swapping data
			UpdateReverseMappingAfterSwap(a, b);
		}

		private void UpdateReverseMappingAfterSwap(int a, int b)
		{
			T firstObject = this.arr[a];
			T secondObject = this.arr[b];

			reverseMapping[firstObject] = a;
			reverseMapping[secondObject] = b;
		}
	}
}

