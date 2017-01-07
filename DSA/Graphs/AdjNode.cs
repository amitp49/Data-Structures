// /Users/amitp/Documents/dsa/DSA/Graphs/AdjNode.cs
// amitp
// (c) Amit Patel
// 07-01-2017
using System;
namespace Graphs
{
	public class AdjNode
	{
		public int Weight
		{
			get;
			set;
		}
		public int Id
		{
			get;
			set;
		}

		public AdjNode(int id)
		{
			this.Id = id;
			this.Weight = 0;
		}
		public AdjNode(int id, int weight)
		{
			this.Id = id;
			this.Weight = weight;
		}
	}
}
