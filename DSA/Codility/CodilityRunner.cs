// /Users/amitp/Documents/dsa/DSA/Codility/CodilityRunner.cs
// amitp
// (c) Amit Patel
// 22-03-2017
using System;
using Interfaces;

namespace Codility
{
	public class CodilityRunner : IRunner
	{
		public void Run()
		{
			int[] A = new int[] { -1, 3, -4, 5, 1, -6, 2 , 1 };
			var solution1 = new Solution1();
			int result = solution1.solution(A);
			Console.WriteLine("Result :" + result );
			Console.ReadKey();
		}
	}
}
