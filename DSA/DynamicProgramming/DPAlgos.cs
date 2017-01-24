// /Users/amitp/Documents/dsa/DSA/DynamicProgramming/DPAlgos.cs
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
	}
}
