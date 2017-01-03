// /Users/amitp/Documents/dsa/DSA/Graphs/GraphRunner.cs
// amitp
// (c) Amit Patel
// 03-01-2017
using System;
using System.Collections.Generic;
using Interfaces;
namespace Graphs
{
	public class GraphRunner : IRunner
	{

		public void Run()
		{
			GraphAdj graph = new GraphAdj(4);
			graph.AddDirectedEdge(0, 1);
			graph.AddDirectedEdge(0, 2);
			graph.AddDirectedEdge(1, 2);
			graph.AddDirectedEdge(2, 0);
			graph.AddDirectedEdge(2, 3);
			graph.AddDirectedEdge(3, 3);
			List<int> dfsList = graph.DFSTraversal(2);

			for (int i = 0; i < dfsList.Count; i++)
			{
				Console.WriteLine(dfsList[i] + ", ");
			}

			int from = 1;
			int to = 3;
			bool isReachable = graph.IsReachableUsingDFSLogic(from, to);
			if (isReachable == true)
			{
				Console.WriteLine("{0} is reachable from {1}",to, from);
			}

			Console.WriteLine("-------------------");


			GraphAdj cyclicGraph = new GraphAdj(4);
			cyclicGraph.AddDirectedEdge(0, 1);
			cyclicGraph.AddDirectedEdge(0, 2);
			cyclicGraph.AddDirectedEdge(1, 2);
			cyclicGraph.AddDirectedEdge(2, 0);
			cyclicGraph.AddDirectedEdge(2, 3);
			cyclicGraph.AddDirectedEdge(3, 3);
			bool isCyclic = cyclicGraph.IsCyclicUsingDFSTraversalLogic();

			if (isCyclic == true)
			{
				Console.WriteLine("Graph is cyclic...");
			}
			Console.ReadKey();
		}
	}
}

