﻿// /Users/amitp/Documents/dsa/DSA/DynamicProgramming/DPAlgos.cs
// amitp
// (c) Amit Patel
// 23-01-2017
using System;
using System.Linq;
using System.Collections.Generic;
namespace DynamicProgramming
{
	public class DPAlgos
	{
		/// <summary>
		/// LIS of the specified arr in O(N^2).
		/// </summary>
		/// <param name="arr">Array</param>
		public int LIS(int[] arr)
		{
			int n = arr.Length;
			int[] lisUptoIndex = new int[n]; //every lis is 1
			//initialize
			for (int i = 0; i < n; i++)
			{
				lisUptoIndex[i] = 1;
			}

			int maxLisSoFar = 0;

			for (int i = 1; i < n; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (arr[j] < arr[i] && lisUptoIndex[i] < lisUptoIndex[j] + 1)
					{
						lisUptoIndex[i] = lisUptoIndex[j] + 1;
					}
				}

				//update max so far
				if (lisUptoIndex[i] > maxLisSoFar)
				{
					maxLisSoFar = lisUptoIndex[i];
				}
			}
			return maxLisSoFar;
		}

		public int MaxSumIncreasingSubsequence(int[] arr)
		{
			int n = arr.Length;
			int[] msiUptoIndex = new int[n]; //every msi is element itself for size one

			for (int i = 0; i < n; i++)
			{
				msiUptoIndex[i] = arr[i];
			}

			int maxMsiSoFar = 0;

			for (int i = 1; i < n; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (arr[j] < arr[i] && msiUptoIndex[i] < msiUptoIndex[j] + arr[i])
					{
						msiUptoIndex[i] = msiUptoIndex[j] + arr[i];
					}
				}

				//update max so far
				if (msiUptoIndex[i] > maxMsiSoFar)
				{
					maxMsiSoFar = msiUptoIndex[i];
				}
			}
			return maxMsiSoFar;
		}

		public int LongestBitonicSubsequence(int[] arr)
		{
			int n = arr.Length;

			//Step:1 Find LIS from right

			int[] lisUptoIndexFromRight = new int[n];
			for (int i = 0; i < n; i++)
			{
				lisUptoIndexFromRight[i] = 1;
			}

			for (int i = 1; i < n; i++) // start from second element
			{
				for (int j = 0; j < i; j++)
				{
					if (arr[j] < arr[i] && lisUptoIndexFromRight[i] < lisUptoIndexFromRight[j] + 1)
					{
						lisUptoIndexFromRight[i] = lisUptoIndexFromRight[j] + 1;
					}
				}
			}

			//Step:2 Find LIS from left to right
			int[] lisUptoIndexFromLeft = new int[n];
			for (int i = 0; i < n; i++)
			{
				lisUptoIndexFromLeft[i] = 1;
			}

			for (int i = n-2; i >= 0; i--) // start from second last element
			{
				for (int j = n-1; j > i; j--)
				{
					if (arr[j] < arr[i] && lisUptoIndexFromLeft[i] < lisUptoIndexFromLeft[j] + 1)
					{
						lisUptoIndexFromLeft[i] = lisUptoIndexFromLeft[j] + 1;
					}
				}
			}

			//Step:3 add both at each location
			int runningMax = lisUptoIndexFromLeft[0] + lisUptoIndexFromRight[0] - 1; // current element is counted twise
			for (int i = 1; i < n; i++)
			{
				if (runningMax < lisUptoIndexFromLeft[i] + lisUptoIndexFromRight[i] - 1)
				{
					runningMax = lisUptoIndexFromLeft[i] + lisUptoIndexFromRight[i] - 1;
				}
			}

			return runningMax;
		}

		/// <summary>
		/// LIS in NLogN using binary search.
		/// http://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/
		/// </summary>
		/// <returns>LIS</returns>
		/// <param name="arr">Arr.</param>
		public int LISinNLogNUsingBinarySearch(int[] arr)
		{
			int n = arr.Length;
			int len = 1;
			int[] activeListEndElements = new int[n];

			//initialize with starting element
			activeListEndElements[0] = arr[0];

			for (int i = 1; i < n; i++)
			{
				int ceilingIndex = BinarySearchCeilIndex(activeListEndElements,0,len-1,arr[i]);
				activeListEndElements[ceilingIndex] = arr[i];

				if (ceilingIndex == len)
				{
					len++;
				}
			}
			return len;
		}

		/// <summary>
		/// Search ceiling index for the given new element in array using binary search.
		/// http://www.geeksforgeeks.org/search-floor-and-ceil-in-a-sorted-array/
		/// </summary>
		/// <returns>The ceil index.</returns>
		/// <param name="array">Arr.</param>
		/// <param name="left">Left.</param>
		/// <param name="right">Right.</param>
		/// <param name="newElement">New element.</param>
		private int BinarySearchCeilIndex(int[] array, int left, int right, int newElement)
		{
			while (right >= left)
			{
				int mid = left + (right - left) / 2;

				if (newElement < array[left])
				{
					return left;
				}
				else if (newElement>array[right])
				{
					return right+1;
				}
				else if(array[mid]==newElement)
				{
					return mid;
				}
				else if (array[mid] > newElement)
				{
					if (mid - 1 >= left && array[mid - 1] < newElement)
					{
						return mid; //found ceil
					}
					else
					{
						right = mid;
					}
				}
				else if (array[mid] < newElement)
				{
					if (mid + 1 <= right && array[mid + 1] >= newElement)
					{
						return mid + 1; //found ceil
					}
					else
					{
						left = mid;
					}
				}
			}
			return right; //should never come
		}

		public string LCS(string a, string b)
		{
			int alen = a.Length;
			int blen = b.Length;
			int[,] lcsTable = new int[alen + 1, blen + 1];

			for (int i = 0; i < alen+1; i++)
			{
				for (int j = 0; j < blen+1; j++)
				{
					if (i == 0 || j == 0)
					{
						lcsTable[i, j] = 0;
					}
					else if (a.ElementAt(i - 1) == b.ElementAt(j - 1))
					{
						lcsTable[i, j] = lcsTable[i - 1, j - 1] + 1;
					}
					else
					{
						lcsTable[i, j] = Math.Max(lcsTable[i-1,j],lcsTable[i,j-1]);
					}
				}
			}

			int lcsLength = lcsTable[alen,blen];

			//To print actual LCS string
			List<char> lcsChars = new List<char>(lcsLength);

			int x = alen;
			int y = blen;

			while (x > 0 && y > 0)
			{
				if (a.ElementAt(x - 1) == b.ElementAt(y - 1))
				{
					lcsChars.Add(a.ElementAt(x - 1));
					x--;
					y--;
				}
				else if (lcsTable[x - 1, y] > lcsTable[x, y - 1]) //find larger of top and left
				{
					x--;
				}
				else
				{
					y--;
				}
			}

			lcsChars.Reverse();
			return String.Join(String.Empty, lcsChars.ToArray());;
		}

		/// <summary>
		/// Edit distance - only first string is allowed to be modified via
		/// 1. Insert
		/// 2. Remove
		/// 3. Replace
		/// </summary>
		/// <returns>The distance.</returns>
		/// <param name="a">String A</param>
		/// <param name="b">String B</param>
		public int EditDistance(string a, string b)
		{
			int alen = a.Length;
			int blen = b.Length;
			int[,] editDistanceTable = new int[alen + 1, blen + 1];

			int INSERTCOST = 1, REMOVECOST = 1, REPLACECOST = 1;

			for (int i = 0; i < alen + 1; i++)
			{
				for (int j = 0; j < blen + 1; j++)
				{
					if (i == 0) //if string A is empty, then to make targer string B, insert char
					{
						editDistanceTable[i, j] = j * INSERTCOST;
					}
					else if (j == 0) //if second targeted string is empty, then remove char from string A
					{
						editDistanceTable[i, j] = i * REMOVECOST;
					}
					else if (a.ElementAt(i - 1) == b.ElementAt(j - 1))
					{
						editDistanceTable[i, j] = editDistanceTable[i - 1, j - 1];
					}
					else // min of insert/remove/replace
					{
						int insert = editDistanceTable[i, j - 1] + INSERTCOST;
						int remove = editDistanceTable[i - 1, j] + REMOVECOST;
						int replace = editDistanceTable[i - 1, j - 1] + REPLACECOST;

						editDistanceTable[i, j] = Math.Min(insert,Math.Min(remove,replace));
					}
				}
			}

			return editDistanceTable[alen, blen];
		}

		public string LongestNonRepeatingSubString(string str)
		{
			int n = str.Length;
			char[] strarr = str.ToCharArray();
			int startIndex = 0;
			int endIndex = 0;
			int maxStartIndex = 0;
			int maxEndIndex = 0;

			Dictionary<char, int> visitedDictionary = new Dictionary<char, int>();
			visitedDictionary.Add(strarr[0],0);

			for (int i = 1; i < n; i++)
			{
				int previousOccuranceIndex = -1;
				bool previouslyOccured = visitedDictionary.ContainsKey(strarr[i]);
				if (previouslyOccured == false)
				{
					endIndex = i;
					//add to dictionary
					visitedDictionary.Add(strarr[i], i);
				}
				else
				{
					previousOccuranceIndex = visitedDictionary[strarr[i]];
					if (startIndex > previousOccuranceIndex)
					{
						endIndex = i;
					}
					else
					{
						//time to update windows size in maxlength
						if ((endIndex - startIndex + 1) > (maxEndIndex - maxStartIndex + 1))
						{
							maxStartIndex = startIndex;
							maxEndIndex = endIndex;
						}

						startIndex = previousOccuranceIndex+1;
					}
					//update to dictionary
					visitedDictionary[strarr[i]] = i;
				}

			}

			return str.Substring(maxStartIndex,maxEndIndex-maxStartIndex+1);
		}

		public int MinJumpToReachEnd(int[] jumpArray)
		{
			int n = jumpArray.Length;
			int[] minJumpToReachIndex = new int[n];

			//all other INT.MAX except first
			for (int i = 1; i < n; i++)
			{
				minJumpToReachIndex[i] = Int32.MaxValue;
			}

			minJumpToReachIndex[0] = 0; // At start, zero jump
			
			for (int current = 1; current < n; current++)
			{
				for (int exploredIndex = 0; exploredIndex < current; exploredIndex++)
				{
					//check if sum doesn't overflow
					if (minJumpToReachIndex[exploredIndex]!= Int32.MaxValue &&
						minJumpToReachIndex[exploredIndex] + jumpArray[exploredIndex] >= current &&
					    minJumpToReachIndex[current] > minJumpToReachIndex[exploredIndex]+1)
					{
						minJumpToReachIndex[current] = minJumpToReachIndex[exploredIndex] + 1;
					}
				}
			}
			return minJumpToReachIndex[n - 1];
		}

		/// <summary>
		/// Get maximum value by cutting rod. Rod size = index+1
		/// </summary>
		/// <returns>The rod.</returns>
		/// <param name="rodPrice">Rod price.</param>
		public int CutRod(int[] rodPrice)
		{
			int n = rodPrice.Length;
			int[] maxValueOfSize = new int[n+1];

			//for zero size rod, value would be zero
			maxValueOfSize[0] = 0;
			maxValueOfSize[1] = rodPrice[0]; // index zero gives rod size one


			for (int i = 2; i <= n; i++)
			{
				for (int j = 0; j < i; j++) 
				{
					if(maxValueOfSize[i] < rodPrice[j] + maxValueOfSize[i - j -1])
						maxValueOfSize[i] = rodPrice[j] + maxValueOfSize[i - j -1];
				}
			}
			return maxValueOfSize[n];
		}

		public int CountWaysToMakeMoneyUsingCoins(int value, int[] coinArr)
		{
			int nCoin = coinArr.Length;
			int[,] table = new int[value+1,nCoin];

			//To make 0 value, using any coin there is only one way, DONOT include coin
			for (int i = 0; i < nCoin; i++)
			{
				table[0, i] = 1;
			}

			//fill other values rows
			for (int row = 1; row < value+1; row++)
			{
				for (int jcoin = 0; jcoin < nCoin; jcoin++)
				{
					int waysWhenIncludeCoin = (row - coinArr[jcoin]) >= 0 ? table[row-coinArr[jcoin],jcoin] : 0;
					int waysWhenDoesntIncludeCoin = (jcoin>=1)?table[row,jcoin-1]:0;
					table[row, jcoin] = waysWhenIncludeCoin + waysWhenDoesntIncludeCoin;
				}
			}

			return table[value,nCoin-1];
		}

		public int MatrixChainMultiplicationCost(int[] matrixDimention)
		{
			int numberOfMatrix = matrixDimention.Length - 1;
			int[,] minCost = new int[numberOfMatrix+1,numberOfMatrix+1]; // will not use zero index for simplicity

			//for each individual matrix, cost is zero for chain length = 1
			for (int i = 0; i <= numberOfMatrix; i++)
			{
				minCost[i, i] = 0;
			}

			//fill diagonaly right up for chain legth>2

			for (int chainLength = 2; chainLength <= numberOfMatrix; chainLength++)
			{
				for (int row = 1; row <= numberOfMatrix - chainLength + 1; row++)
				{
					int col = row + chainLength - 1;

					//if col is out of bound
					if (col > numberOfMatrix)
					{
						continue;
					}

					minCost[row, col] = Int32.MaxValue;

					for (int partition = row; partition < col; partition++)
					{
						int costUsingPartition = minCost[row, partition] +
												minCost[partition + 1, col] +
							matrixDimention[row - 1] * matrixDimention[partition] * matrixDimention[col];

						if (costUsingPartition < minCost[row, col])
						{
							minCost[row, col] = costUsingPartition;
						}
					}
				}
			}
			return minCost[1, numberOfMatrix];
		}

		//TODO: NOT WORKING
		public int MatrixChainMultiplicationCostOptimize(int[] matrixDimention)
		{
			int numberOfMatrix = matrixDimention.Length - 1;
			int[,] cost = new int[numberOfMatrix + 1, numberOfMatrix + 1]; // will not use zero index for simplicity

			//for each individual matrix, cost is zero for chain length = 1
			for (int i = 0; i <= numberOfMatrix; i++)
			{
				cost[i, i] = 0;
			}

			for (int i = 1; i <= numberOfMatrix-1; i++)
			{
				cost[i, i + 1] = matrixDimention[i-1] * matrixDimention[i] * matrixDimention[i+1];
			}

			//fill diagonaly right up for chain legth>=3
			for (int chainLength = 3; chainLength <= numberOfMatrix; chainLength++)
			{
				for (int row = 1; row <= numberOfMatrix - chainLength + 1; row++)
				{
					int col = row + chainLength - 1;

					//if col is out of bound
					if (col > numberOfMatrix || col-2 <0)
					{
						continue;
					}
					cost[row, col] = cost[row + 1, col - 1] +
						matrixDimention[row - 1] * matrixDimention[row] * matrixDimention[row + 1] +
						matrixDimention[col - 2] * matrixDimention[col - 1] * matrixDimention[col];
				}
			}

			//Find min cost

			for (int i = 1; i <= numberOfMatrix; i++)
			{
				for (int j = 1; j < i; j++)
				{
					int costUsingPartition = cost[1, j] +
											cost[j + 1, i] +
						matrixDimention[0] * matrixDimention[j] * matrixDimention[i];

					if (costUsingPartition < cost[i, j])
					{
						cost[i, j] = costUsingPartition;
					}
				}
			}

			return cost[1, numberOfMatrix];
		}

		public int LongestPalindromicSubsequence(string str)
		{
			int n = str.Length;
			int[,] lpsTable = new int[n,n];

			//for each char, lps size is 1
			for (int i = 0; i < n; i++)
			{
				lpsTable[i, i] = 1;
			}

			//for each adjacent pair of char, size if two if both of them are equal
			for (int i = 0; i < n-1; i++)
			{
				if (str.ElementAt(i) == str.ElementAt(i+1))
					lpsTable[i, i + 1] = 2;
			}

			//chain length >= 3

			for (int chainLength = 3; chainLength <= n; chainLength++)
			{
				for (int start = 0; start < n-chainLength+1; start++)
				{
					int end = start + chainLength - 1;

					if (str.ElementAt(start) == str.ElementAt(end))
					{
						lpsTable[start, end] = 2 + lpsTable[start + 1, end - 1];
					}
					else
					{
						int ignoreStartingChar = lpsTable[start + 1 ,end];
						int ignoreEndingChar = lpsTable[start, end - 1];
						lpsTable[start, end] = Math.Max(ignoreStartingChar,ignoreEndingChar);
					}
				}
			}

			return lpsTable[0,n-1];
		}

		public int MinimumCutsRequiredMakeEachPartionPalindrome(string str)
		{
			int n = str.Length;
			int[,] minCost = new int[n, n];

			//for each char, cost size is 0
			for (int i = 0; i < n; i++)
			{
				minCost[i, i] = 0;
			}

			//for each adjacent pair of char, cost is zero if equal, else cost is one
			for (int i = 0; i < n - 1; i++)
			{
				if (str.ElementAt(i) == str.ElementAt(i + 1))
					minCost[i, i + 1] = 0;
				else
					minCost[i, i + 1] = 1;
			}

			//fill diagonaly right up for chain legth>2
			for (int chainLength = 3; chainLength <= n; chainLength++)
			{
				for (int row = 0; row < n - chainLength + 1; row++)
				{
					int col = row + chainLength - 1;
					// if row to col is nothing but start to end in str

					//check if start to end is palindrome, then cost is zero
					if (str.ElementAt(row) == str.ElementAt(col) &&
						minCost[row + 1, col - 1] == 0) // IMP CHECK as we are not maining any other boolean 2D array for palindrome
					{
						minCost[row, col] = 0;
					}
					else
					{
						//Partition logic
						minCost[row, col] = Int32.MaxValue;

						for (int partition = row; partition < col; partition++)
						{
							int costUsingPartition = minCost[row, partition] +
													minCost[partition + 1, col] +
													1; //parition itself

							if (costUsingPartition < minCost[row, col])
							{
								minCost[row, col] = costUsingPartition;
							}
						}
					}
				}
			}

			return minCost[0, n-1];
		}

		/// <summary>
		/// Binomials the coeff - find C(n,k)
		/// </summary>
		/// <returns>The coeff.</returns>
		/// <param name="n">N.</param>
		/// <param name="k">K.</param>
		public int BinomialCoeff(int n, int k)
		{
			int[,] C = new int[n+1, k+1];

			for (int i = 0; i <= n; i++)
			{
				for (int j = 0; j <= Math.Min(i,k); j++)
				{
					if (j == 0 || i == j)
						C[i, j] = 1;
					else
						C[i, j] = C[i - 1, j - 1] + C[i-1,j];
				}
			}
			return C[n, k];
		}

		public int KnapSackZeroOne(int knapsackCapacity, int[] weight, int[] value)
		{
			int n = weight.Length;
			int[,] score = new int[n + 1, knapsackCapacity + 1];

			for (int item = 0; item <= n; item++)
			{
				for (int currentCapacity = 0; currentCapacity <= knapsackCapacity; currentCapacity++)
				{
					if (currentCapacity == 0 || item == 0)
					{
						score[item, currentCapacity] = 0;
					}
					else if (weight[item - 1] <= currentCapacity)
					{
						//Include or exclude depending on score - value[item-1] is value of ith item, as value store from 0th index
						int includeScore = value[item - 1] + score[item - 1, currentCapacity - weight[item-1]];
						int excludeScore = score[item - 1, currentCapacity];
						score[item, currentCapacity] = Math.Max(includeScore,excludeScore);
					}
					else
					{
						//Exclude is the only option as weight is more than current space
						int excludeScore = score[item - 1, currentCapacity];
						score[item, currentCapacity] = excludeScore;
					}
				}
			}

			return score[n,knapsackCapacity];
		}

		public bool CanPartitionInTwoEqualSum(int[] arr)
		{
			int sum = 0;
			int n = arr.Length;

			//find total sum
			for (int i = 0; i < n; i++)
			{
				sum += arr[i];
			}

			//if sum is odd, then can't partition in two equal sum set ever
			if(sum%2!=0)
				return false;

			//Use knapsack of weight = sum/2, pass same array for weight & values 
			int score = this.KnapSackZeroOne(sum/2,arr,arr);
			return (score==sum/2);
		}

		public int EggDrop(int totalEggs, int totalFloors)
		{
			int[,] minimumTrials = new int[totalEggs+1,totalFloors+1];

			for (int egg = 1; egg <= totalEggs; egg++)
			{
				//for zero floor, no trial needed
				minimumTrials[egg, 0] = 0;

				//for one floor, only one trial needed
				minimumTrials[egg, 1] = 1;
			}

			for (int floor = 1; floor <= totalFloors; floor++)
			{
				//with one egg, we need trials as many as floors in sequence
				minimumTrials[1, floor] = floor;
			}

			//fill rest
			for (int egg = 2; egg <= totalEggs; egg++)
			{
				for (int currentFloor = 2; currentFloor <= totalFloors; currentFloor++)
				{
					int runningMinEstimation = Int32.MaxValue;
					//We need to find MINIMUM estimation of WORST/MAX trials out of each floor beneath
					for (int beneathFloor = 1; beneathFloor <= currentFloor; beneathFloor++)
					{
						//Add one for this trial too
						int trialsIfEggBreaksFromBeneathFloor = 1 + minimumTrials[egg-1,beneathFloor-1];
						int trialsIfEggDoesNotBreakFromBeneathFloor = 1 + minimumTrials[egg,currentFloor-beneathFloor];
						int worstNumberOfTrials = Math.Max(trialsIfEggBreaksFromBeneathFloor,
						                                      trialsIfEggDoesNotBreakFromBeneathFloor);
						if (runningMinEstimation > worstNumberOfTrials)
							runningMinEstimation = worstNumberOfTrials;
					}

					minimumTrials[egg, currentFloor] = runningMinEstimation;
				}
			}
			return minimumTrials[totalEggs,totalFloors];
		}

		public int MinimumCostToReachCell(int[,] cost, int targetX, int targetY)
		{
			int[,] resultTable = new int[cost.Length+1, cost.GetLength(0)+1];

			//fill starting point cost as first cell 0,0
			resultTable[0, 0] = cost[0,0];

			//fill first row
			for (int i = 1; i < targetX+1; i++)
			{
				resultTable[i, 0] = cost[i,0] + resultTable[i - 1, 0];
			}

			//fill first column
			for (int j = 1; j < targetY+1; j++)
			{
				resultTable[0, j] = cost[0, j] + resultTable[0, j - 1];
			}

			//fill remaining table from second row and second column
			for (int i = 1; i < targetX+1; i++)
			{
				for (int j = 1; j < targetY+1; j++)
				{
					int top = resultTable[i-1,j];
					int diagonal = resultTable[i - 1, j - 1];
					int left = resultTable[i, j - 1];

					resultTable[i, j] = cost[i,j] + Math.Min(top,Math.Min(diagonal,left));
				}
			}

			return resultTable[targetX, targetY];
		}

		public int GetAllValidIpAddressesCount(string str)
		{
			int n = str.Length;
			int dots=3;
			int[,] DP = new int[4,n]; // 3 dots + 0 dots

			//Base row filling for row 0th, col 1,2,3
			DP[0, 0] = isValidNumber(str, 0, 0) ? 1 : 0;
			DP[0, 1] = isValidNumber(str, 0, 1) ? 1 : 0;
			DP[0, 2] = isValidNumber(str, 0, 2) ? 1 : 0;

			//Fill other cells
			for (int i = 1; i < dots+1; i++)
			{
				for (int j = i; j < n; j++)
				{
					int prev1 = (j - 1) >= 0 && isValidNumber(str, j, j) ? DP[i - 1,j - 1] : 0;
					int prev2 = (j - 2) >= 0 && isValidNumber(str, j-1, j) ? DP[i - 1,j - 2] : 0;
					int prev3 = (j - 3) >= 0 && isValidNumber(str, j-2, j) ? DP[i - 1,j - 3] : 0;

					DP[i, j] = prev1 + prev2 + prev3;
				}
			}
			return DP[3,n-1];
		}

		private bool isValidNumber(string str, int j1, int j2)
		{
			string number = str.Substring(j1, j2 - j1+1);
			int num=0;
			bool parsingSuccess = Int32.TryParse(number,out num);
			if (parsingSuccess && num <= 255)
			{
				return true;
			}
			return false;
		}
	}
}
