// /Users/amitp/Documents/dsa/DSA/Graphs/MyClass.cs
// amitp
// (c) Amit Patel
// 03-01-2017
using System;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
namespace Graphs
{
	public class GraphAdj
	{
		
		public int V
		{
			get;
			set;
		}

		public List<int>[] adj
		{
			get;
			set;
		}

		public GraphAdj(int v)
		{
			this.V = v;
			adj = new List<int>[this.V];
			for (int i = 0; i < this.V; i++)
			{
				adj[i] = new List<int>(); //allocate actual memory
			}
		}

		public void AddDirectedEdge(int from, int to)
		{
			adj[from].Add(to);
		}

		public void AddUnDirectedEdge(int from, int to)
		{
			adj[from].Add(to);
			adj[to].Add(from);
		}

		public List<int> DFSTraversal()
		{
			return DFSTraversal(0); //start from zero by default
		}

		public List<int> DFSTraversal(int startNode)
		{
			if (startNode >= V)
				return null;
			
			List<int> dfsTraversalList = new List<int>();
			bool[] visited = new bool[this.V];

			//loop over all vertex in case if there are disconnected trees

			DFSTraversalInternalUtil(startNode, visited, dfsTraversalList);

			for (int i = 0; i < this.V; i++)
			{
				if (i != startNode) // don't process tree having start node
				{
					if (visited[i] == false)
					{
						DFSTraversalInternalUtil(i, visited, dfsTraversalList);
					}
				}
			}

			return dfsTraversalList;
		}

		private void DFSTraversalInternalUtil(int currentVertex, bool[] visited, List<int> dfsTraversalList)
		{
			if (visited[currentVertex] == true)
				return;

			visited[currentVertex] = true;
			dfsTraversalList.Add(currentVertex);

			for (int i = 0; i < adj[currentVertex].Count; i++)
			{
				int adjacentVertex = adj[currentVertex][i];

				if (visited[adjacentVertex]  == false) //not visited yet
				{
					DFSTraversalInternalUtil(adj[currentVertex][i], visited, dfsTraversalList);
				}
			}
		}

		public bool IsReachableUsingDFSLogic(int from, int to)
		{
			bool[] visited = new bool[this.V];
			bool isReachable = IsReachableUsingDFSLogicInternalUtil(from,to,visited);
			return isReachable;
		}

		private bool IsReachableUsingDFSLogicInternalUtil(int currentVertex, int targetedVertex, bool[] visited)
		{
			if (visited[currentVertex] == true)
				return false;
			
			if (currentVertex == targetedVertex)
				return true;
			
			visited[currentVertex] = true;

			foreach (var adjacentVertex in adj[currentVertex])
			{
				if (visited[adjacentVertex] == false)
				{
					bool isReachable = IsReachableUsingDFSLogicInternalUtil(adjacentVertex,targetedVertex,visited);
					if (isReachable == true)
						return true;
				}
			}

			return false;
		}

		public bool IsCyclicUsingDFSTraversalLogic()
		{
			bool[] visited = new bool[this.V];
			bool[] stillInProgressAndPresentInRecurionStack = new bool[this.V];

			for (int i = 0; i < this.V; i++)
			{
				bool cycleInThisSubtree = IsCyclicUsingDFSTraversalLogicInternalUtil(i, visited, stillInProgressAndPresentInRecurionStack); //start from 0
				if (cycleInThisSubtree == true)
				{
					return true;
				}
			}

			return false;
		}

		private bool IsCyclicUsingDFSTraversalLogicInternalUtil(int currentVertex, bool[] visited, bool[] stillInProgressAndPresentInRecurionStack)
		{
			if (visited[currentVertex] == true)
				return false;

			visited[currentVertex] = true;
			stillInProgressAndPresentInRecurionStack[currentVertex] = true; // mark it gray - in progess

			foreach (var adjacentVertex in adj[currentVertex])
			{
				if (visited[adjacentVertex] == false) // still first time encounter - color white
				{
					bool isCycleInAnyChild = IsCyclicUsingDFSTraversalLogicInternalUtil(adjacentVertex, visited, stillInProgressAndPresentInRecurionStack);
					if (isCycleInAnyChild == true)
					{
						return true;
					}
				}
				else if (stillInProgressAndPresentInRecurionStack[adjacentVertex]==true) // in progress would always be visited, but not vice versa
				{
					return true;
				}
			}

			stillInProgressAndPresentInRecurionStack[currentVertex] = false; // mark it black - completed
			return false;
		}
	}
}

