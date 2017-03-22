// /Users/amitp/Documents/dsa/DSA/Codility/MyClass.cs
// amitp
// (c) Amit Patel
// 22-03-2017
using System;
namespace Codility
{
	/// <summary>
	/// This is a demo task.
	/*
	A zero-indexed array A consisting of N integers is given.An equilibrium index of this array is any integer P such that 0 ≤ P<N and the sum of elements of lower indices is equal to the sum of elements of higher indices, i.e.
   A[0] + A[1] + ... + A[P−1] = A[P + 1] + ... + A[N−2] + A[N−1].
Sum of zero elements is assumed to be equal to 0. This can happen if P = 0 or if P = N−1.


   For example, consider the following array A consisting of N = 8 elements:


	 A[0] = -1

	 A[1] =  3

	 A[2] = -4

	 A[3] =  5

	 A[4] =  1

	 A[5] = -6

	 A[6] =  2

	 A[7] =  1
P = 1 is an equilibrium index of this array, because:


   A[0] = −1 = A[2] + A[3] + A[4] + A[5] + A[6] + A[7]
   P = 3 is an equilibrium index of this array, because:


   A[0] + A[1] + A[2] = −2 = A[4] + A[5] + A[6] + A[7]
   P = 7 is also an equilibrium index, because:


   A[0] + A[1] + A[2] + A[3] + A[4] + A[5] + A[6] = 0
and there are no elements with indices greater than 7.


   P = 8 is not an equilibrium index, because it does not fulfill the condition 0 ≤ P<N.

   Write a function:

class Solution { public int solution(int[] A); }

	that, given a zero-indexed array A consisting of N integers, returns any of its equilibrium indices.The function should return −1 if no equilibrium index exists.


	For example, given array A shown above, the function may return 1, 3 or 7, as explained above.


	Assume that:


	N is an integer within the range[0..100, 000];
	each element of array A is an integer within the range[−2, 147, 483, 648..2, 147, 483, 647].
Complexity:

expected worst-case time complexity is O(N);
	expected worst-case space complexity is O(N), beyond input storage(not counting the storage required for input arguments).
Elements of input arrays can be modified.


WRONG ANSWER,  got 2, but it is not equilibrium point, sum[0..1]=4294967294, sum[3..3]=-2
WRONG ANSWER,  got 0, but it is not equilibrium point, left sum (empty set)=0, sum[1..2]=-4294967296
WRONG ANSWER,  got 0, but it is not equilibrium point, left sum (empty set)=0, sum[1..2]=-4294967296
WRONG ANSWER,  got 2, but it is not equilibrium point, sum[0..1]=-4294967296, right sum (empty set)=0
WRONG ANSWER,  got 2, but it is not equilibrium point, sum[0..1]=-4294967296, right sum (empty set)=0

For example, for the input [0, -2147483648, -2147483648] the solution returned a wrong answer (got 0, but it is not equilibrium point, left sum (empty set)=0, sum[1..2]=-4294967296).

*/
	/// </summary>
	public class Solution1
	{
		public int solution(int[] A)
		{
			// write your code in C# 6.0 with .NET 4.5 (Mono)
			int n = A.Length;
			int[] leftSum = new int[n];
			int[] rightSum = new int[n];

			for (int i = 1; i < n; i++)
			{
				leftSum[i] += (leftSum[i - 1]+ A[i-1]);
			}

			for (int j = n-2; j >= 0; j--)
			{
				rightSum[j] += (rightSum[j + 1]+A[j+1]);
			}

			for (int i = 0; i < n; i++)
			{
				if (leftSum[i] == rightSum[i])
				{
					//Console.WriteLine(i);
					return i;
				}
			}

			return -1;
		}
	}
}
