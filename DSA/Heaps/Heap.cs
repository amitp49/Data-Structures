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

		public Heap(int maxSize, HeapType heapType)
		{
			this.MaxSize = maxSize;
			this.CurrentSize = 0;
			this.heapType = heapType;
			this.arr = new T[this.MaxSize];
			AssignComparer();
		}

		public Heap(T[] arr, HeapType heapType)
		{
			this.arr = arr;
			this.MaxSize = arr.Length;
			this.CurrentSize = arr.Length;
			this.heapType = heapType;
			AssignComparer();
			
			//Create reverse mapping for allowing external user to change key/pririty at run time, and we will hepify
			FillReverseMapping();

			//now call build heap
			BuildHeap(arr.Length);
		}

		private void AssignComparer()
		{
			if (heapType == HeapType.MinHeap)
			{
				comparer = Comparer.Default;
			}
			else if (heapType == HeapType.MaxHeap)
			{
				comparer = new ReverseComparer();
			}
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
				HeapifyDown(0);
			}

			CurrentSize = MaxSize; //restore
		}

		public void Insert(T data)
		{
			if (this.MaxSize == this.arr.Length)
			{
				//TODO: Need to resize heap array
			}
			else
			{
				this.CurrentSize++;
				this.arr[CurrentSize - 1] = data;
				PercolateUp(CurrentSize-1);
			}
		}

		private void PercolateUp(int index)
		{
			if (index != 0)
			{
				int parentIndex = (index - 1) / 2;

				if (comparer.Compare(arr[parentIndex], arr[index]) > 0)
				{
					SwapData(parentIndex, index);
					PercolateUp(parentIndex);
				}
			}
		}

		public T GetZeroIndexElement()
		{
			return this.arr[0];
		}

		public void RemoveZeroIndexElement()
		{
			SwapData(0, this.CurrentSize-1);
			CurrentSize--;
			HeapifyDown(0);
		}

		private void BuildHeap(int n)
		{
			for (int i = n/2-1; i >=0; i--)
			{
				HeapifyDown(i);
			}
		}

		private void HeapifyDown(int elementIndex)
		{
			int childIndex = elementIndex;
			int leftChildIndex = elementIndex * 2 + 1;
			int rightChildIndex = elementIndex * 2 + 2;

			if (leftChildIndex < this.CurrentSize-1 && comparer.Compare(arr[leftChildIndex], arr[elementIndex]) > 0)
			{
				childIndex = leftChildIndex;
			}

			if (rightChildIndex < this.CurrentSize-1 && comparer.Compare(arr[rightChildIndex], arr[childIndex]) > 0)
			{
				childIndex = rightChildIndex;
			}

			if (childIndex != elementIndex)
			{
				SwapData(childIndex,elementIndex);
				HeapifyDown(childIndex);
			}
		}

		public void UpdateHeapForChangedPriority(T node)
		{
			int currentIndex = reverseMapping[node];
			// We can just call both : percolate up and hepify down. Methods will move it only if required
			PercolateUp(currentIndex);
			HeapifyDown(currentIndex);
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

