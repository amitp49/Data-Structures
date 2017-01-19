// /Users/amitp/Documents/dsa/DSA/Heaps/HeapAlgos.cs
// amitp
// (c) Amit Patel
// 19-01-2017
using System;
using System.Collections.Generic;
using Interfaces;
using System.Linq;

namespace Heaps
{
	public class HeapAlgos
	{
		public Dictionary<char, string> HuffmanCodes(char[] arr, int[] freq)
		{
			int n = arr.Length;
			var minHeap = new Heap<HuffmanHeapNode<char>>(n, HeapType.MinHeap);

			//Insert all char with freq in min heap
			for (int i = 0; i < n; i++)
			{
				HuffmanHeapNode<char> huffmanNode = new HuffmanHeapNode<char>(arr[i],freq[i]);
				minHeap.Insert(huffmanNode);
			}

			//Combine top 2 min nodes and insert back until only one node remains
			while (minHeap.CurrentSize>1)
			{
				HuffmanHeapNode<char> left = minHeap.GetZeroIndexElement();
				minHeap.RemoveZeroIndexElement();

				HuffmanHeapNode<char> right = minHeap.GetZeroIndexElement();
				minHeap.RemoveZeroIndexElement();

				//Create new node
				HuffmanHeapNode<char> newInternalNode = new HuffmanHeapNode<char>('$',left.Frequency+right.Frequency);
				newInternalNode.Left = left;
				newInternalNode.Right = right;

				minHeap.Insert(newInternalNode);
			}

			//Get codes from tree
			Dictionary<char, string> codes = GetCodesFromTree(minHeap);
			return codes;
		}

		private Dictionary<char, string> GetCodesFromTree(Heap<HuffmanHeapNode<char>> minHeap)
		{
			Dictionary<char, string> codes = new Dictionary<char, string>();
			String str = "";
			GetCodesFromTreeRecUtil(minHeap.GetZeroIndexElement(),str,codes); // pas root node of tree
			return codes;
		}

		private void GetCodesFromTreeRecUtil(BinaryTreeNode<char> root, string str, Dictionary<char, string> codes)
		{
			if (root == null)
				return;

			if (root.Data.CompareTo('$') != 0) //leaf node
			{
				codes.Add(root.Data,str);
			}

			GetCodesFromTreeRecUtil(root.Left, str + 0, codes);
			GetCodesFromTreeRecUtil(root.Right, str + 1, codes);
		}
	}
}
