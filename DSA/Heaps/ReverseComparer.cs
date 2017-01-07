// /Users/amitp/Documents/dsa/DSA/Heaps/MyClass.cs
// amitp
// (c) Amit Patel
// 07-01-2017
using System;
using System.Collections;

namespace Heaps
{
	public class ReverseComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			return Comparer.Default.Compare(y, x);
		}
	}

}
