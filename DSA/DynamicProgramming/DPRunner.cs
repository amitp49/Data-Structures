﻿// /Users/amitp/Documents/dsa/DSA/DynamicProgramming/MyClass.cs
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

			int[,] cost = {{1, 2, 3},
                       {4, 8, 2},
                       {1, 5, 3}};
			int minCost = dpAlgos.MinimumCostToReachCell(cost,2,2);
			Console.WriteLine("MIN COST: {0}",minCost);
			Console.WriteLine("---------");

			string str = "GEEKSFORGEEKS";
			string strResult = dpAlgos.LongestNonRepeatingSubString(str);
			Console.WriteLine("Longest non repeating: {0}",strResult);
			Console.WriteLine("---------");

			int[] jumparray = { 1, 3, 6, 1, 0, 9 };
			int minJumpToReachEnd = dpAlgos.MinJumpToReachEnd(jumparray);
			Console.WriteLine("Min Jump: {0}",minJumpToReachEnd);
			Console.WriteLine("---------");

			int[] coinArr = { 1, 2, 3 };
			int make = 4;
			int numberOfWays = dpAlgos.CountWaysToMakeMoneyUsingCoins(make,coinArr);
			Console.WriteLine("Number of ways for coin: {0}",numberOfWays);
			Console.WriteLine("---------");

			// 1st matrix: 1 * 2
			// 2nd matrix: 2 * 3
			// 3rd matrix: 3 * 4
			int[] matrixDimention = new int[] { 1, 2, 3, 4 };
			int minConstToMultiplyMatrix = dpAlgos.MatrixChainMultiplicationCost(matrixDimention);
			Console.WriteLine("Min Const To Multiply Matrix: {0}",minConstToMultiplyMatrix);
			Console.WriteLine("---------");
			
			Console.ReadKey();
		}
	}
}
