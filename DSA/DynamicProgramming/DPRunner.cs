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
			int minConstToMultiplyMatrixOpt = dpAlgos.MatrixChainMultiplicationCostOptimize(matrixDimention);
			Console.WriteLine("Min Const To Multiply Matrix OPT: {0}", minConstToMultiplyMatrixOpt);
			Console.WriteLine("---------");

			int n = 5, k = 2;
			Console.WriteLine("Value of C(" + n + "," + k + ") is " + dpAlgos.BinomialCoeff(n, k));
			Console.WriteLine("---------");

			int[] val = new int[] { 60, 100, 120 };
			int[] wt = new int[] { 10, 20, 30 };
			int W = 50;
			Console.WriteLine("Max value for knapsack: {0}",dpAlgos.KnapSackZeroOne(W, wt, val));
			Console.WriteLine("---------");

			int eggs = 2, floors = 36;
			Console.WriteLine("Minimum number of trials in worst case with " + eggs + "  eggs and " + floors +
					 " floors is " + dpAlgos.EggDrop(eggs, floors));
			Console.WriteLine("---------");

			String seq = "BBABCBCAB";
			Console.WriteLine("The length of the lps is " + dpAlgos.LongestPalindromicSubsequence(seq));
			Console.WriteLine("---------");

			int[] rodPrice = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
			Console.WriteLine("Maximum Obtainable Value is " + dpAlgos.CutRod(rodPrice));
			Console.WriteLine("---------");

			int[] msiarr = new int[] { 1, 101, 2, 3, 100, 4, 5 };
			Console.WriteLine("Sum of maximum sum increasing subsequence is: " + dpAlgos.MaxSumIncreasingSubsequence(msiarr));
			Console.WriteLine("---------");

			int[] lbsarr = {0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5,13, 3, 11, 7, 15};
			Console.WriteLine("Length of LBS is " + dpAlgos.LongestBitonicSubsequence(lbsarr));
			Console.WriteLine("---------");

			string strToPartition = "ababbbabbababa";
			Console.WriteLine("Min cuts needed for Palindrome Partitioning is {0}", dpAlgos.MinimumCutsRequiredMakeEachPartionPalindrome(strToPartition));
			Console.WriteLine("---------");

			int[] setarr = { 3, 1, 1, 2, 2, 1 };
			if (dpAlgos.CanPartitionInTwoEqualSum(setarr) == true)
				Console.WriteLine("Can be divided into two subsets of equal sum");
        	else
           		Console.WriteLine("Can not be divided into two subsets of equal sum");
			Console.WriteLine("---------");
			
			Console.ReadKey();
		}
	}
}
