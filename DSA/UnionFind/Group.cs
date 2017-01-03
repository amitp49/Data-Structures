// /Users/amitp/Documents/dsa/DSA/UnionFind/Group.cs
// amitp
// (c) Amit Patel
// 03-01-2017
using System;
namespace UnionFind
{
	public class Group
	{
		public int Parent
		{
			get;
			set;
		}
		public int Size
		{
			get;
			set;
		}

		public Group(int parent, int size)
		{
			this.Parent = parent;
			this.Size = size;
		}
	}
}

