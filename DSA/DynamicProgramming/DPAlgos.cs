// /Users/amitp/Documents/dsa/DSA/DynamicProgramming/DPAlgos.cs
// amitp
// (c) Amit Patel
// 23-01-2017
using System;
namespace DynamicProgramming
{
	public class DPAlgos
	{
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
	}
}
