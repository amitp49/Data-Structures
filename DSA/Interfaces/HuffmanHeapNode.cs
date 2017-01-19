// /Users/amitp/Documents/dsa/DSA/Interfaces/HuffmanHeapNode.cs
// amitp
// (c) Amit Patel
// 19-01-2017
using System;
namespace Interfaces
{
	public class HuffmanHeapNode<T> : BinaryTreeNode<T>, IComparable where T : IComparable
	{
		public int Frequency
		{
			get {
				//if (base.AddOns != null)
					return base.AddOns[0];			
			}
			set {
				//if (base.AddOns != null)
					base.AddOns[0] = value;
			}
		}

		public HuffmanHeapNode(T data,int freq)
			:base(data)
		{
			this.AddOns = new DataList(1);
			this.AddOns[0]=freq;
		}

		public int CompareTo(object obj)
		{
			return this.Frequency.CompareTo(((HuffmanHeapNode<T>)obj).Frequency);
		}
	}
}
