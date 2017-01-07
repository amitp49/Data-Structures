// /Users/amitp/Documents/dsa/DSA/Graphs/VertextNode.cs
// amitp
// (c) Amit Patel
// 07-01-2017
using System;
namespace Interfaces
{
	public class VertexNode : IComparable
	{
		public int Key
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public int Parent
		{
			get;
			set;
		}

		public VertexNode(int id)
		{
			this.Id = id;
			this.Key = 0;
		}

		public VertexNode(int id, int key, int parent = 0)
		{
			this.Id = id;
			this.Key = key;
			this.Parent = parent;
		}

		public int CompareTo(object obj)
		{
			var vertexNodeCompareTo = obj as VertexNode;
			return Key.CompareTo(vertexNodeCompareTo.Key);
		}
	}
}
