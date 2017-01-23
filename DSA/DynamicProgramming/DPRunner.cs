// /Users/amitp/Documents/dsa/DSA/DynamicProgramming/MyClass.cs
// amitp
// (c) Amit Patel
// 23-01-2017
using System;
using Interfaces;

namespace DynamicProgramming
{
	public class DPRunner : IRunner
	{
		void IRunner.Run()
		{
			DPAlgos dpAlgos = new DPAlgos();
			int[] arr = { 10, 22, 9, 33, 21, 50, 41, 60 };
			int lis = dpAlgos.LIS(arr);
			Console.WriteLine("LIS: {0}",lis);
			Console.WriteLine("---------");
			
			int lisNLogn = dpAlgos.LISinNLogNUsingBinarySearch(arr);
			Console.WriteLine("LIS NLogN: {0}", lisNLogn);
			Console.WriteLine("---------");

			string a = "AGGTAB";
			string b = "GXTXAYB";
			string lcs = dpAlgos.LCS(a,b);
			Console.WriteLine("LCS: {0}, length:{1}",lcs,lcs.Length);
			Console.WriteLine("---------");

			String str1 = "sunday";
			String str2 = "saturday";
			int editDistance = dpAlgos.EditDistance(str1, str2);
			Console.WriteLine("EDIT DISTANCE: {0}",editDistance);
			Console.WriteLine("---------");
			
			Console.ReadKey();
		}
	}
}
