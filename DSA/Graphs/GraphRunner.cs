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

			Console.WriteLine("---------DFS Reachable----------");


			int from = 1;
			int to = 3;
			bool isReachable = graph.IsReachableUsingDFSLogic(from, to);
			if (isReachable == true)
			{
				Console.WriteLine("{0} is reachable from {1}",to, from);
			}
			Console.WriteLine("---------BFS----------");

			List<int> bfsList = graph.BFSTraversal(2);

			for (int i = 0; i < bfsList.Count; i++)
			{
				Console.WriteLine(bfsList[i] + ", ");
			}
			Console.WriteLine("-------------------");

			Console.WriteLine("Connected component count: {0}",graph.GetConnectedComponentCountUsingDFSLogic());
			Console.WriteLine("----------Cycle using dfs---------");

			bool isCyclic = graph.IsCyclicUsingDFSTraversalLogic();

			if (isCyclic == true)
			{
				Console.WriteLine("Graph is cyclic...");
			}
			Console.WriteLine("--------Cycle using union find-----------");

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

			Console.WriteLine("-------Floyd------------");

			GraphAdj directedGraph = new GraphAdj(4);
			directedGraph.AddDirectedEdge(0, 1, 5);
			directedGraph.AddDirectedEdge(1, 3, 3);
			directedGraph.AddDirectedEdge(3, 2, 1);
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

			Console.WriteLine("-------TOPO------------");
			
			List<int> topologicalOrderForDag2 = directedGraph.TopologicalSortUsingIndegreeAndQueue();
			foreach (var item in topologicalOrderForDag2)
			{
				Console.Write("{0}, ", item);
			}
			Console.WriteLine();

			Console.WriteLine("-------FW------------");
			
			bool[,] rechability = directedGraph.TransitiveClosureUsingFloydWarshallAllPairReachabilityMatrix();

			for (int i = 0; i < rechability.GetLength(0); i++)
			{
				for (int j = 0; j < rechability.GetLength(1); j++)
				{
					Console.Write(rechability[i, j] + " , ");
				}
				Console.WriteLine("");
			}

			Console.WriteLine("-------DFS------------");
			
			bool[,] rechabilityDFS = directedGraph.TransitiveClosureReachableUsingDFSForAllPair();

			for (int i = 0; i < rechabilityDFS.GetLength(0); i++)
			{
				for (int j = 0; j < rechabilityDFS.GetLength(1); j++)
				{
					Console.Write(rechabilityDFS[i, j] + " , ");
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


			Console.WriteLine("---------Dijkstra----------");
			
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

			Console.WriteLine("---------Articulation Point----------");

			GraphAdj undirectedGraph5 = new GraphAdj(5);
			undirectedGraph5.AddUnDirectedEdge(1,0);
			undirectedGraph5.AddUnDirectedEdge(0,2);
			undirectedGraph5.AddUnDirectedEdge(2,1);
			undirectedGraph5.AddUnDirectedEdge(0,3);
			undirectedGraph5.AddUnDirectedEdge(3,4);
			
			List<int> articulationPoints = undirectedGraph5.ArticulationPointsOrCutVerticesUsingDFSLogic();

			foreach (var item in articulationPoints)
			{
				Console.Write("{0}, ", item);
			}

			Console.WriteLine("");

			Console.WriteLine("---------Articulation Point----------");
			
			GraphAdj undirectedGraph6 = new GraphAdj(7);
			undirectedGraph6.AddUnDirectedEdge(0,1);
			undirectedGraph6.AddUnDirectedEdge(1,2);
			undirectedGraph6.AddUnDirectedEdge(2,0);
			undirectedGraph6.AddUnDirectedEdge(1,3);
			undirectedGraph6.AddUnDirectedEdge(1,4);
			undirectedGraph6.AddUnDirectedEdge(1,6);
			undirectedGraph6.AddUnDirectedEdge(3,5);
			undirectedGraph6.AddUnDirectedEdge(4,5);
			

			List<int> articulationPoints2 = undirectedGraph6.ArticulationPointsOrCutVerticesUsingDFSLogic();

			foreach (var item in articulationPoints2)
			{
				Console.Write("{0}, ", item);
			}

			Console.WriteLine("");

			Console.WriteLine("--------BellmanFord-----------");

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

			Console.WriteLine("---------TOPOLOGICAL SORT----------");

			bool noCycleAndTopoLogicalPossible = false;
			List<int> topologicalOrder = directedGraph2.TopologicalSortingUsingDFSWithStack(ref noCycleAndTopoLogicalPossible);
			if (noCycleAndTopoLogicalPossible == true)
			{
				foreach (var item in topologicalOrder)
				{
					Console.Write("{0}, ", item);
				}
				Console.WriteLine();
				
			}
			else
			{
				Console.WriteLine("Cycle found!!! No topological ordering..");
			}

			Console.WriteLine("--------DAG-----------");

			GraphAdj directedAcyclicGraph = new GraphAdj(6);
			directedAcyclicGraph.AddDirectedEdge(0,1,5);
			directedAcyclicGraph.AddDirectedEdge(0,2,3);
			directedAcyclicGraph.AddDirectedEdge(1,3,6);
			directedAcyclicGraph.AddDirectedEdge(1,2,2);
			directedAcyclicGraph.AddDirectedEdge(2,4,4);
			directedAcyclicGraph.AddDirectedEdge(2,5,2);
			directedAcyclicGraph.AddDirectedEdge(2,3,7);
			directedAcyclicGraph.AddDirectedEdge(3,4,-1);
			directedAcyclicGraph.AddDirectedEdge(4,5,-2);

			List<int> topologicalOrderForDag = directedAcyclicGraph.TopologicalSortUsingIndegreeAndQueue();
			foreach (var item in topologicalOrderForDag)
			{
				Console.Write("{0}, ", item);
			}
			Console.WriteLine();

			Console.WriteLine("---------Shortest Distance - DAG--------");
			int source = 1;
			Dictionary<int, int> vertexToShortestDistanceTopo = directedAcyclicGraph.DirectedAcyclicGraphShortestPathFromSourceUsingTopoLogicalSortOrder(source);
			Console.WriteLine("Source --> distance");
			
			foreach (var item in vertexToShortestDistanceTopo)
			{
				Console.WriteLine("{0}->{1} ", item.Key,item.Value);
			}
			Console.WriteLine("-------SCC----------");

			GraphAdj directedGraph3 = new GraphAdj(5);
			directedGraph3.AddDirectedEdge(1,0);
			directedGraph3.AddDirectedEdge(0,2);
			directedGraph3.AddDirectedEdge(2,1);
			directedGraph3.AddDirectedEdge(0,3);
			directedGraph3.AddDirectedEdge(3,4);

			List<List<int>> sccList = directedGraph3.GetStroglyConnectedComponentsUsingDFS();

			foreach (var scc in sccList)
			{
				foreach (var vertex in scc)
				{
					Console.Write("{0}, ", vertex);
				}
				Console.WriteLine("");
			}
			Console.WriteLine("-----------------");

			GraphAdj directedGraph4 = new GraphAdj(6);
			directedGraph4.AddDirectedEdge(0,1,16);
			directedGraph4.AddDirectedEdge(0,2,13);
			directedGraph4.AddDirectedEdge(1,2,10);
			directedGraph4.AddDirectedEdge(1,3,12);
			directedGraph4.AddDirectedEdge(2,1,4);
			directedGraph4.AddDirectedEdge(2,4,14);
			directedGraph4.AddDirectedEdge(3,2,9);
			directedGraph4.AddDirectedEdge(3,5,20);
			directedGraph4.AddDirectedEdge(4,3,7);
			directedGraph4.AddDirectedEdge(4,5,4);

			int maxFlow = directedGraph4.FordFulkarsonMaximumFlow(0,5);
			Console.WriteLine("Max Flow: {0}",maxFlow);

			Console.WriteLine("-----------------");


			int numberToRepresentMultipleInZeroOne = 55;
			GraphAdj directedGraphForNumber = new GraphAdj(numberToRepresentMultipleInZeroOne);
			String resultString = directedGraphForNumber.GetMultipleInZeroOneOnlyFor(numberToRepresentMultipleInZeroOne);
			Console.WriteLine("Multiple of {0} -> {1}",numberToRepresentMultipleInZeroOne,resultString);
			Console.WriteLine("-----------------");
			
			Console.ReadKey();

		}
	}
}

