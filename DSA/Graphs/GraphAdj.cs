﻿// /Users/amitp/Documents/dsa/DSA/Graphs/MyClass.cs
// amitp
// (c) Amit Patel
// 03-01-2017
using System;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using UnionFind;

namespace Graphs
{
	
	public class GraphAdj
	{
		
		public int V
		{
			get;
			set;
		}

		public List<AdjNode>[] adj
		{
			get;
			set;
		}

		public List<Edge> Edges
		{
			get;
			set;
		}

		public GraphAdj(int v)
		{
			this.V = v;
			this.adj = new List<AdjNode>[this.V];
			for (int i = 0; i < this.V; i++)
			{
				this.adj[i] = new List<AdjNode>(); //allocate actual memory
			}
			this.Edges = new List<Edge>();
		}

		public void AddDirectedEdge(int from, int to)
		{
			adj[from].Add(new AdjNode(to));
			this.Edges.Add(new Edge(from,to,true));
		}

		public void AddDirectedEdge(int from, int to, int weight)
		{
			adj[from].Add(new AdjNode(to,weight));
			this.Edges.Add(new Edge(from, to, true, weight));
		}

		public void AddUnDirectedEdge(int from, int to)
		{
			adj[from].Add(new AdjNode(to));
			adj[to].Add(new AdjNode(from));
			this.Edges.Add(new Edge(from, to));
		}

		public void AddUnDirectedEdge(int from, int to, int weight)
		{
			adj[from].Add(new AdjNode(to,weight));
			adj[to].Add(new AdjNode(from,weight));
			this.Edges.Add(new Edge(from, to, false, weight));
		}

		public List<int> BFSTraversal()
		{
			return BFSTraversal(0);
		}

		public List<int> BFSTraversal(int startNode)
		{
			bool[] visited = new bool[this.V];
			List<int> bfsTraversalList = new List<int>();

			BFSTraversalInternalIterative(startNode, visited, bfsTraversalList);

			for (int i = 0; i < this.V; i++)
			{
				if (i != startNode) // don't process tree having start node again
				{
					if (visited[i] == false)
					{
						BFSTraversalInternalIterative(i,visited,bfsTraversalList);
					}
				}
			}
			return bfsTraversalList;
		}

		public void BFSTraversalInternalIterative(int startNode,bool[] visited, List<int> bfsTraversalList)
		{
			if (startNode >= V)
				return;
			
			Queue<int> queue = new Queue<int>();
			queue.Enqueue(startNode);
			visited[startNode] = true; // mark as visited while enqueu, not dequeue to avoid infinite loop due to self loop 

			while (queue.Count>0)
			{
				int currentVertex = queue.Dequeue();
				bfsTraversalList.Add(currentVertex);

				foreach (var adjacentVertex in adj[currentVertex])
				{
					if (visited[adjacentVertex.Id] == false)
					{
						queue.Enqueue(adjacentVertex.Id);
						visited[adjacentVertex.Id] = true; //to avoid self loops, mark it as visited
					}
				}
			}
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

			foreach (var adjacentVertex in adj[currentVertex])
			{
				if (visited[adjacentVertex.Id]  == false) //not visited yet
				{
					DFSTraversalInternalUtil(adjacentVertex.Id, visited, dfsTraversalList);
				}
			}
		}

		public int GetConnectedComponentCountUsingDFSLogic()
		{
			int count = 0;
			bool[] visited = new bool[this.V];

			//loop over all vertex in case if there are disconnected trees, we want to increment components

			for (int i = 0; i < this.V; i++)
			{
				if (visited[i] == false)
				{
					count++;
					GetConnectedComponentCountUsingDFSLogicInternalUtil(i, visited);
				}
			}

			return count;
		}

		private void GetConnectedComponentCountUsingDFSLogicInternalUtil(int currentVertex, bool[] visited)
		{
			if (visited[currentVertex] == true)
				return;

			visited[currentVertex] = true;

			foreach (var adjacentVertex in adj[currentVertex])
			{
				if (visited[adjacentVertex.Id] == false) //not visited yet
				{
					GetConnectedComponentCountUsingDFSLogicInternalUtil(adjacentVertex.Id, visited);
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
				if (visited[adjacentVertex.Id] == false)
				{
					bool isReachable = IsReachableUsingDFSLogicInternalUtil(adjacentVertex.Id,targetedVertex,visited);
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
				if (visited[adjacentVertex.Id] == false) // still first time encounter - color white
				{
					bool isCycleInAnyChild = IsCyclicUsingDFSTraversalLogicInternalUtil(adjacentVertex.Id, visited, stillInProgressAndPresentInRecurionStack);
					if (isCycleInAnyChild == true)
					{
						return true;
					}
				}
				else if (stillInProgressAndPresentInRecurionStack[adjacentVertex.Id]==true) // in progress would always be visited, but not vice versa
				{
					return true;
				}
			}

			stillInProgressAndPresentInRecurionStack[currentVertex] = false; // mark it black - completed
			return false;
		}

		public bool IsCyclicUsingUnionFind()
		{
			UnionFindDs unionFind = new UnionFindDs(this.V);

			for (int fromVertex = 0; fromVertex < this.V; fromVertex++)
			{
				foreach (var adjacentVertex in adj[fromVertex])
				{
					//for each edge , we are running it
					int x = unionFind.Find(fromVertex);
					int y = unionFind.Find(adjacentVertex.Id);
					if (x == y) // in same group (only if both are not -1)
					{
						return true; //cycle found
					}
					else
					{
						unionFind.Union(fromVertex,adjacentVertex.Id);
					}
				}
			}
			return false;
		}

		public int[,] AllPairShortestPaths()
		{
			int[,] solution = new int[this.V, this.V];

			//Initlize all as INF/MAX
			for (int i = 0; i < this.V; i++)
			{
				for (int j = 0; j < this.V; j++)
				{
					if(i!=j)
						solution[i, j] = Int32.MaxValue;
				}
			}

			//Assign current graph layout to solution in matrix form

			for (int currentVertex= 0; currentVertex < this.V; currentVertex++)
			{
				foreach (var adjacentVertex in adj[currentVertex])
				{
					solution[currentVertex, adjacentVertex.Id] = adjacentVertex.Weight;
				}
			}

			//Iterate through all vertex as intermediate path
			for (int intermediateVertex = 0; intermediateVertex < this.V; intermediateVertex++)
			{
				for (int fromVertex = 0; fromVertex < this.V; fromVertex++)
				{
					for (int toVertex = 0; toVertex < this.V; toVertex++)
					{
						int currentDirectDistance = solution[fromVertex, toVertex];
						int distanceUsingIntermediate = Int32.MaxValue;

						//To avoid interger overflow when summing to max values
						if(solution[fromVertex, intermediateVertex] < Int32.MaxValue/2 &&
						   solution[intermediateVertex, toVertex] < Int32.MaxValue/2)
						 	distanceUsingIntermediate = solution[fromVertex, intermediateVertex] + solution[intermediateVertex, toVertex];
						
						if (distanceUsingIntermediate < currentDirectDistance)
						{
							solution[fromVertex, toVertex] = distanceUsingIntermediate;
						}
					}
				}
			}

			return solution;
		}
	}
}

