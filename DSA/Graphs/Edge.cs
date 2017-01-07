// /Users/amitp/Documents/dsa/DSA/Graphs/Edge.cs
// amitp
// (c) Amit Patel
// 07-01-2017
using System;
namespace Graphs
{
	public class Edge : IComparable
	{
		public int From
		{
			get;
			set;
		}
		public int To
		{
			get;
			set;
		}
		public int Weight
		{
			get;
			set;
		}
		public bool IsDirected
		{
			get;
			set;
		}

		public Edge(int from, int to, bool isDirected = false, int weight = 0)
		{
			this.From = from;
			this.To = to;
			this.Weight = weight;
			this.IsDirected = isDirected;
		}

		public int CompareTo(object obj)
		{
			if (obj is Edge)
			{
				var comparingTo = obj as Edge;
				return this.Weight.CompareTo(comparingTo.Weight);
			}
			return 0; //TODO:what should we return?
		}
	}
}
