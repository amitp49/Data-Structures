// /Users/amitp/Documents/dsa/DSA/UnionFind/UnionFindRunner.cs
// amitp
// (c) Amit Patel
// 07-01-2017
using System;
using Interfaces;

namespace UnionFind
{
	public class UnionFindRunner: IRunner
	{
		void IRunner.Run()
		{
			UnionFindDs unionFindDs = new UnionFindDs(5);
			int x = unionFindDs.Find(0);
			Console.WriteLine("Leader for 0: {0}",x);
			Console.ReadLine();
		}
	}
}
