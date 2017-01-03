// /Users/amitp/Documents/dsa/DSA/Graphs/MyClass.cs
// amitp
// (c) Amit Patel
// 03-01-2017
using System;
using System.Collections.Generic;
using System.Collections;
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

	}
}

