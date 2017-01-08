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

			//WE CAN NOT FIND CYCLES IN DIRECTED GRAPH USING UNION FIND
			bool isCyclicUndirected = undirectedGraph.IsCyclicUsingUnionFind();

			if (isCyclicUndirected == true)
			{
				Console.WriteLine("Undirected Graph is cyclic using union find...");
			}

			Console.WriteLine("-------------------");

			GraphAdj directedGraph = new GraphAdj(4);
			directedGraph.AddDirectedEdge(0, 1, 5);
			directedGraph.AddDirectedEdge(1, 2, 3);
			directedGraph.AddDirectedEdge(2, 3, 1);
			directedGraph.AddDirectedEdge(0, 3, 10);

			int[,] solution = directedGraph.FloydWarshallAllPairShortestPaths();
			for (int i = 0; i < solution.GetLength(0); i++)
			{
				for (int j = 0; j < solution.GetLength(1); j++)
				{
					Console.Write(solution[i,j] + " , ");
				}
				Console.WriteLine("");
			}

			Console.WriteLine("-------------------");

			GraphAdj undirectedGraph2 = new GraphAdj(4);
			undirectedGraph2.AddUnDirectedEdge(0, 1, 10);
			undirectedGraph2.AddUnDirectedEdge(0, 2, 6);
			undirectedGraph2.AddUnDirectedEdge(0, 3, 5);
			undirectedGraph2.AddUnDirectedEdge(1, 3, 15);
			undirectedGraph2.AddUnDirectedEdge(2, 3, 4);

			List<Edge> resultTree = undirectedGraph2.KruskalMST();
			foreach (var edge in resultTree)
			{
				Console.WriteLine("From:{0}, To:{1}, Weight:{2}",edge.From,edge.To,edge.Weight);
			}

			Console.WriteLine("-------------------");
			
			GraphAdj undirectedGraph3 = new GraphAdj(5);
			undirectedGraph3.AddUnDirectedEdge(0, 1, 2);
			undirectedGraph3.AddUnDirectedEdge(0, 3, 6);
			undirectedGraph3.AddUnDirectedEdge(1, 2, 3);
			undirectedGraph3.AddUnDirectedEdge(1, 3, 8);
			undirectedGraph3.AddUnDirectedEdge(1, 4, 5);
			undirectedGraph3.AddUnDirectedEdge(2, 4, 7);
			undirectedGraph3.AddUnDirectedEdge(3, 4, 9);
			
			List<Edge> resultTree3 = undirectedGraph3.PrimsMST();
			foreach (var edge in resultTree3)
			{
				Console.WriteLine("From:{0}, To:{1}, Weight:{2}", edge.From, edge.To, edge.Weight);
			}

			Console.WriteLine("-------------------");
			
			GraphAdj undirectedGraph4 = new GraphAdj(9);
			undirectedGraph4.AddUnDirectedEdge(0,1,4);
			undirectedGraph4.AddUnDirectedEdge(0,7,8);
			undirectedGraph4.AddUnDirectedEdge(1,2,8);
			undirectedGraph4.AddUnDirectedEdge(1,7,11);
			undirectedGraph4.AddUnDirectedEdge(2,3,7);
			undirectedGraph4.AddUnDirectedEdge(2,8,2);
			undirectedGraph4.AddUnDirectedEdge(2,5,4);
			undirectedGraph4.AddUnDirectedEdge(3,4,9);
			undirectedGraph4.AddUnDirectedEdge(3,5,14);
			undirectedGraph4.AddUnDirectedEdge(4,5,10);
			undirectedGraph4.AddUnDirectedEdge(5,6,2);
			undirectedGraph4.AddUnDirectedEdge(6,7,1);
			undirectedGraph4.AddUnDirectedEdge(6,8,6);
			undirectedGraph4.AddUnDirectedEdge(7,8,7);

			Dictionary<int, int> vertexToShortestDistance = undirectedGraph4.DijkstraShortestPathFromSource(0);
			Console.WriteLine("Source --> distance");

			foreach (var item in vertexToShortestDistance)
			{
				Console.WriteLine("{0} --> {1}",item.Key,item.Value);
			}

			Console.WriteLine("-------------------");

			GraphAdj directedGraph2 = new GraphAdj(5);
			directedGraph2.AddDirectedEdge(0, 1, -1);
			directedGraph2.AddDirectedEdge(0, 2, 4);
			directedGraph2.AddDirectedEdge(1, 2, 3);
			directedGraph2.AddDirectedEdge(1, 3, 2);
			directedGraph2.AddDirectedEdge(1, 4, 2);
			directedGraph2.AddDirectedEdge(3, 2, 5);
			directedGraph2.AddDirectedEdge(3, 1, 1);
			directedGraph2.AddDirectedEdge(4, 3, -3);

			bool negativeCycleFlag = false;
			Dictionary<int, int> vertexToShortestDistanceBellmanFord = directedGraph2.BellmanFordShortestPathWithNegativeCycles(0, ref negativeCycleFlag);
			if (negativeCycleFlag == false)
			{
				foreach (var item in vertexToShortestDistanceBellmanFord)
				{
					Console.WriteLine("{0} --> {1}", item.Key, item.Value);
				}
			}
			else
			{
				Console.WriteLine("Negative weight cycle present...");
			}

			Console.WriteLine("-------------------");
			
			Console.ReadKey();

		}
	}
}

