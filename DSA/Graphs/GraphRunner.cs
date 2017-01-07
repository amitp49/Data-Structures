﻿// /Users/amitp/Documents/dsa/DSA/Graphs/GraphRunner.cs
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
			GraphAdj graph = new GraphAdj(6);
			graph.AddDirectedEdge(0, 1);
			graph.AddDirectedEdge(0, 2);
			graph.AddDirectedEdge(1, 2);
			graph.AddDirectedEdge(2, 0);
			graph.AddDirectedEdge(2, 3);
			graph.AddDirectedEdge(3, 3);
			graph.AddDirectedEdge(4, 5);
			List<int> dfsList = graph.DFSTraversal(2);

			for (int i = 0; i < dfsList.Count; i++)
			{
				Console.WriteLine(dfsList[i] + ", ");
			}

			Console.WriteLine("-------------------");


			int from = 1;
			int to = 3;
			bool isReachable = graph.IsReachableUsingDFSLogic(from, to);
			if (isReachable == true)
			{
				Console.WriteLine("{0} is reachable from {1}",to, from);
			}
			Console.WriteLine("-------------------");

			List<int> bfsList = graph.BFSTraversal(2);

			for (int i = 0; i < bfsList.Count; i++)
			{
				Console.WriteLine(bfsList[i] + ", ");
			}
			Console.WriteLine("-------------------");

			Console.WriteLine("Connected component count: {0}",graph.GetConnectedComponentCountUsingDFSLogic());
			Console.WriteLine("-------------------");

			bool isCyclic = graph.IsCyclicUsingDFSTraversalLogic();

			if (isCyclic == true)
			{
				Console.WriteLine("Graph is cyclic...");
			}
			Console.WriteLine("-------------------");

			GraphAdj undirectedGraph = new GraphAdj(4);
			undirectedGraph.AddUnDirectedEdge(0, 1);
			undirectedGraph.AddUnDirectedEdge(1, 2);
			undirectedGraph.AddUnDirectedEdge(2, 0);

			bool isCyclicUndirected = graph.IsCyclicUsingUnionFind();

			if (isCyclicUndirected == true)
			{
				Console.WriteLine("Undirected Graph is cyclic using union find...");
			}

			Console.ReadKey();
		}
	}
}
