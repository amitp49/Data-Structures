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

			int lisNLogn = dpAlgos.LISinNLogNUsingBinarySearch(arr);
			Console.WriteLine("LIS NLogN: {0}", lisNLogn);
			
			Console.WriteLine("---------");

			Console.ReadKey();
		}
	}
}
