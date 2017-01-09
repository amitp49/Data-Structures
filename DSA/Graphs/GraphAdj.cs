// amitp
// (c) Amit Patel
// 03-01-2017
using System;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using UnionFind;
using Heaps;
using Interfaces;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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

		public void AddEdge(Edge edge)
		{
			this.Edges.Add(edge);
			adj[edge.From].Add(new AdjNode(edge.To, edge.Weight));
			if (edge.IsDirected == false)
			{
				adj[edge.To].Add(new AdjNode(edge.From, edge.Weight));
			}
		}

		public GraphAdj GetTransposeGraph()
		{
			GraphAdj transposeGraph = new GraphAdj(this.V);
			transposeGraph.adj = new List<AdjNode>[this.V];
			for (int i = 0; i < this.V; i++)
			{
				transposeGraph.adj[i] = new List<AdjNode>(); //allocate actual memory
			}
			transposeGraph.Edges = new List<Edge>();
			foreach (var edge in this.Edges)
			{
				transposeGraph.AddEdge(new Edge(edge.To,edge.From,edge.IsDirected,edge.Weight)); // reverse to and from
			}
			return transposeGraph;
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

		public List<List<int>> GetStroglyConnectedComponentsUsingDFS()
		{
			List<List<int>> stroglyConnectedComponentsList = new List<List<int>>();

			List<int>  dfsOrder = this.DFSTraversal();
			dfsOrder.Reverse();

			List<int> reverseDfsOrder = dfsOrder;

			GraphAdj transposeGraph = this.GetTransposeGraph();

			bool[] visited = new bool[this.V];
			foreach (var vertex in reverseDfsOrder)
			{
				if (visited[vertex] == false)
				{
					List<int> stronglyConnectedComponentDfsOrderList = new List<int>();
					DFSTraversalInternalUtil(vertex, visited, stronglyConnectedComponentDfsOrderList);
					stroglyConnectedComponentsList.Add(stronglyConnectedComponentDfsOrderList);
				}	
			}
			return stroglyConnectedComponentsList;
		}

		public List<int> ArticulationPointsOrCutVerticesUsingDFSLogic()
		{
			List<int> articulationPoints = new List<int>();

			bool[] isArticulationPoint = new bool[this.V];
			bool[] visited = new bool[this.V];
			int[] parent = new int[this.V];
			int[] children = new int[this.V];
			int[] dfsDiscoveryTime = new int[this.V];
			int[] lowestDiscoveryTimeReachableNode = new int[this.V];
			bool[] inStack = new bool[this.V];
			int time = 0;

			//Initialize parent with -1
			for (int i = 0; i < this.V; i++)
			{
				parent[i] = -1;
			}

			//DFS
			for (int i = 0; i < this.V; i++)
			{
				if (visited[i]==false)
				{
					ArticulationPointsOrCutVerticesUsingDFSLogicRecUtil(i,
					                                                    visited,
					                                                    inStack,
					                                                    parent,
					                                                    children,
					                                                    dfsDiscoveryTime,
					                                                    lowestDiscoveryTimeReachableNode, 
					                                                    isArticulationPoint,
					                                                    ref time);
					if (parent[i] == -1 && children[i] >= 2)
					{
						isArticulationPoint[i] = true; // root of connected component having more than two child!! its like root of tree
					}
				}
			}


			//output
			for (int i = 0; i < this.V; i++)
			{
				if (isArticulationPoint[i] == true)
				{
					articulationPoints.Add(i);
				}
			}
			return articulationPoints;
		}

		private void ArticulationPointsOrCutVerticesUsingDFSLogicRecUtil(int currentVertex, 
		                                                                 bool[] visited, 
		                                                                 bool[] inStack,
		                                                                 int[] parent,
		                                                                 int[] children,
		                                                                 int[] dfsDiscoveryTime, 
		                                                                 int[] lowestDiscoveryTimeReachableNode, 
		                                                                 bool[] isArticulationPoint,
		                                                                ref int time)
		{
			visited[currentVertex] = true;
			inStack[currentVertex] = true; //processing start - color - gray
			dfsDiscoveryTime[currentVertex] = time;
			lowestDiscoveryTimeReachableNode[currentVertex] = time;
			time++;

			foreach (var adjacentVertex in this.adj[currentVertex])
			{
				if (visited[adjacentVertex.Id] == false) //first time, discover color- white
				{
					//assign parent if starting visiting this node for first time
					parent[adjacentVertex.Id] = currentVertex;
					children[currentVertex]++;

					ArticulationPointsOrCutVerticesUsingDFSLogicRecUtil(adjacentVertex.Id, visited, inStack, parent, children, dfsDiscoveryTime, lowestDiscoveryTimeReachableNode, isArticulationPoint, ref time);
					lowestDiscoveryTimeReachableNode[currentVertex] = Math.Min(lowestDiscoveryTimeReachableNode[currentVertex],
																				lowestDiscoveryTimeReachableNode[adjacentVertex.Id]);

					//Check if current vertext is articulation point, due to adjacentVertext which doesn't point to any ancestor
					if (parent[currentVertex] != -1 &&
					   lowestDiscoveryTimeReachableNode[adjacentVertex.Id] >= dfsDiscoveryTime[currentVertex])
					{
						isArticulationPoint[currentVertex] = true; //this can set itself multiple time
					}
				}
				else if (visited[adjacentVertex.Id] ==true && inStack[adjacentVertex.Id] == true) //gray
				{
					lowestDiscoveryTimeReachableNode[currentVertex] = Math.Min(lowestDiscoveryTimeReachableNode[currentVertex],
					                                                           dfsDiscoveryTime[adjacentVertex.Id]);
				}
			}

			inStack[currentVertex] = false; //all processing done - color - black
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

		public bool[,] TransitiveClosureReachableUsingDFSForAllPair()
		{
			//O(n^2) / O(V*(V+E)) solution for less dense graph... floyd warshall takes O(n^3)
			bool[,] reachable = new bool[this.V, this.V];

			//Every vertex is reachable from itself
			for (int i = 0; i < this.V; i++)
			{
				TransitiveClosureReachableUsingDFSForAllPairInternalRecUtil(reachable,i,i);
			}

			return reachable;
		}

		private void TransitiveClosureReachableUsingDFSForAllPairInternalRecUtil(bool[,] reachable, int source, int destination)
		{
			reachable[source, destination] = true;

			foreach (var adjacentVertex in this.adj[destination])
			{
				if (reachable[source, adjacentVertex.Id] == false)
				{
					//recursively mark source to other grand/greate grand childeren as reachable
					TransitiveClosureReachableUsingDFSForAllPairInternalRecUtil(reachable,source,adjacentVertex.Id);
				}
			}
		}

		public List<int> TopologicalSortingUsingDFSWithStack(ref bool noCycleAndTopoLogicalPossible)
		{
			List<int> result = new List<int>();
			Stack<int> stack = new Stack<int>();
			bool[] visited = new bool[this.V];

			//Starting order doesn't matter, there can be multiple ordering for topological
			for (int i = 0; i < this.V; i++)
			{
				if (visited[i] == false)
				{
					bool noCycle = TopologicalSortingUsingDFSWithStackRec(i, visited, stack);
					if ( noCycle == false)
					{
						noCycleAndTopoLogicalPossible = false;
						return null;
					}
				}
			}

			//Output the stack into list
			while (stack.Count > 0)
			{
				result.Add(stack.Peek());
				stack.Pop();
			}

			noCycleAndTopoLogicalPossible = true;
			return result;
		}

		private bool TopologicalSortingUsingDFSWithStackRec(int currentVertex, bool[] visited, Stack<int> stack)
		{
			visited[currentVertex] = true;

			//Post order for putting current vertex to stack
			foreach (var adjacentVertex in this.adj[currentVertex])
			{
				if (visited[adjacentVertex.Id] == false)
				{
					bool noCycle = TopologicalSortingUsingDFSWithStackRec(adjacentVertex.Id, visited, stack);
					if (noCycle == false)
						return false;
				}
				else // check for cycle
				{
					if (!stack.Contains(adjacentVertex.Id)) // not in stack , means in progrss , and encounter again , means cycle, gray node
					{
						Console.WriteLine("CYCLE!!!");
						return false;
					}
				}
			}

			//Now output vertex to stack after all modules which are dependant on current are pushed on to stack
			stack.Push(currentVertex);

			return true;
		}

		public List<int> TopologicalSortUsingIndegreeAndQueue()
		{
			//Assume graph is acyclic 

			List<int> topologicalOrder = new List<int>();
			Queue<int> queueForVertexHavingZeroIndegree = new Queue<int>();

			int[] inDegree = new int[this.V];

			//Find indgree for each vertex
			foreach (var item in this.Edges)
			{
				inDegree[item.To] += 1;
			}

			//Find all zero indegree vertex, and push it to queue
			for (int i = 0; i < this.V; i++)
			{
				if (inDegree[i] == 0)
				{
					queueForVertexHavingZeroIndegree.Enqueue(i);
				}
			}

			//process vertex from queue - O(V^2) if dense graph
			while (queueForVertexHavingZeroIndegree.Count>0)
			{
				int currentVertex = queueForVertexHavingZeroIndegree.Dequeue();
				topologicalOrder.Add(currentVertex);

				//logical removal of current vertex from graph, decrease in degree for all adjacent vertex of current
				foreach (var adjacentVertex in this.adj[currentVertex])
				{
					inDegree[adjacentVertex.Id]--;
					if (inDegree[adjacentVertex.Id] == 0)
					{
						queueForVertexHavingZeroIndegree.Enqueue(adjacentVertex.Id);
					}
				}
			}
			return topologicalOrder;
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
		public List<Edge> KruskalMST()
		{
			List<Edge> minimumSpanningTreeEdges = new List<Edge>();
			UnionFindDs unionFindDs = new UnionFindDs(this.V);

			//Sort all edges by their weight
			this.Edges.Sort();

			foreach (var edge in this.Edges)
			{
				//If tree is built, all vertex are connected, then no need to check more
				if (minimumSpanningTreeEdges.Count >= this.V - 1)
					break;

				int edgeFromEndPointGroup = unionFindDs.Find(edge.From);
				int edgeToEndPointGroup = unionFindDs.Find(edge.To);

				if (edgeFromEndPointGroup != edgeToEndPointGroup)
				{
					minimumSpanningTreeEdges.Add(edge);
					unionFindDs.Union(edge.From, edge.To);
				}
			}

			return minimumSpanningTreeEdges;
		}

		public List<Edge> PrimsMST()
		{
			List<Edge> minimumSpanningTreeEdges = new List<Edge>(); // for output

			VertexNode[] vertexDistanceKeyTracker = new VertexNode[this.V];
			Dictionary<int, VertexNode> hashTable = new Dictionary<int, VertexNode>();

			//For others, make it infinite
			for (int i = 0; i < this.V; i++)
			{
				vertexDistanceKeyTracker[i] = new VertexNode(i, Int32.MaxValue, 0);
				hashTable.Add(i, vertexDistanceKeyTracker[i]);
			}

			vertexDistanceKeyTracker[0].Key = 0;
			vertexDistanceKeyTracker[0].Parent = -1; //start node distance key = zero, parent -1

			//create new min heap to get minimum of all adjacent
			Heap<VertexNode> minHeap = new Heap<VertexNode>(vertexDistanceKeyTracker, HeapType.MinHeap);

			//Take v-1 edges, or v vertex
			while (!minHeap.IsEmpty())
			{
				VertexNode minimumDistanceNode = minHeap.GetZeroIndexElement();
				minHeap.RemoveZeroIndexElement();

				//For output, add retrieved node with its parent
				if (minimumDistanceNode.Parent != -1)
				{
					minimumSpanningTreeEdges.Add(new Edge(minimumDistanceNode.Parent,
														  minimumDistanceNode.Id,
														  false,
														  minimumDistanceNode.Key));
				}

				int currentVertex = minimumDistanceNode.Id;
				foreach (var adjacentVertex in adj[currentVertex])
				{
					VertexNode adjacentVertexNode = hashTable[adjacentVertex.Id];
					
					if (minHeap.IsInHeap(adjacentVertexNode) &&
					    adjacentVertex.EdgeWeight < adjacentVertexNode.Key)
					{
						//To update parent, we will need node itself, not just id
						adjacentVertexNode.Parent = currentVertex;
						adjacentVertexNode.Key = adjacentVertex.EdgeWeight; // only equal

						//CRITICAL - Need to re heapify
						minHeap.UpdateHeapForChangedPriority(adjacentVertexNode);
					}
				}
			}

			return minimumSpanningTreeEdges;
		}

		/// <summary>
		/// Dijkstras the shortest path from source for non negative edge weight. It can have positive cycle.
		/// </summary>
		/// <returns>The shortest path from source.</returns>
		/// <param name="source">Source.</param>
		public Dictionary<int, int> DijkstraShortestPathFromSource(int source)
		{
			Dictionary<int, int> vertexToShortestDistance = new Dictionary<int, int>();

			VertexNode[] vertexDistanceKeyTracker = new VertexNode[this.V];
			Dictionary<int, VertexNode> hashTable = new Dictionary<int, VertexNode>();

			//For others, make it infinite
			for (int i = 0; i < this.V; i++)
			{
				vertexDistanceKeyTracker[i] = new VertexNode(i, 999, 0);
				hashTable.Add(i, vertexDistanceKeyTracker[i]);
			}

			vertexDistanceKeyTracker[source].Key = 0;

			//create new min heap to get minimum of all adjacent
			Heap<VertexNode> minHeap = new Heap<VertexNode>(vertexDistanceKeyTracker, HeapType.MinHeap);

			while (!minHeap.IsEmpty())
			{
				VertexNode minimumDistanceNode = minHeap.GetZeroIndexElement();
				minHeap.RemoveZeroIndexElement();

				//For output
				vertexToShortestDistance.Add(minimumDistanceNode.Id,minimumDistanceNode.Key);

				int currentVertex = minimumDistanceNode.Id;
				VertexNode currentVertexNode = hashTable[currentVertex];
					
				foreach (var adjacentVertex in adj[currentVertex])
				{
					VertexNode adjacentVertexNode = hashTable[adjacentVertex.Id];

					if (minHeap.IsInHeap(adjacentVertexNode) &&
					    currentVertexNode.Key != 999 &&
						currentVertexNode.Key + adjacentVertex.EdgeWeight < adjacentVertexNode.Key) //change in condition
					{
						adjacentVertexNode.Key = currentVertexNode.Key + adjacentVertex.EdgeWeight; // plus current

						//CRITICAL - Need to re heapify
						minHeap.UpdateHeapForChangedPriority(adjacentVertexNode);
					}
				}
			}
			return vertexToShortestDistance;
		}

		/// <summary>
		/// Bellmans the ford shortest path with negative cycles too.
		/// </summary>
		/// <returns>The ford shortest path with negative cycles.</returns>
		/// <param name="source">Source.</param>
		/// <param name="negativeCycleFlag">If set to <c>true</c> negative cycle flag.</param>
		public Dictionary<int, int> BellmanFordShortestPathWithNegativeCycles(int source, ref bool negativeCycleFlag)
		{
			Dictionary<int, int> vertexToShortestDistance = new Dictionary<int, int>();
			int[] distance = new int[this.V];

			for (int i = 0; i < this.V; i++)
			{
				distance[i] = Int32.MaxValue;
			}
			distance[source] = 0; //initialize source distance as zero

			//Loop for v-1 times, because simple path can have at most v-1 edges
			for (int i = 0; i < V-1; i++)
			{
				for (int edgeNumber = 0; edgeNumber < this.Edges.Count; edgeNumber++)
				{
					bool flag = CheckIfDistanceNeedsToBeUpdated(distance,edgeNumber);
					if (flag == true)
					{
						distance[this.Edges[edgeNumber].To] = distance[this.Edges[edgeNumber].From] + 
																	this.Edges[edgeNumber].Weight;
					}
				}
			}

			//When we have processed edges v-1 times, there should not be any more scope for less distance
			//If we still find any such less distance, then it would be surely negative cycle.
			for (int edgeNumber = 0; edgeNumber < this.Edges.Count; edgeNumber++)
			{
				bool flag = CheckIfDistanceNeedsToBeUpdated(distance, edgeNumber);
				if (flag == true)
				{
					//FOUND NEGATIVE WEIGHT CYCLE
					negativeCycleFlag = true;
				}
			}

			//Output distance as dictionary
			if (negativeCycleFlag == false)
			{
				for (int i = 0; i < this.V; i++)
				{
					vertexToShortestDistance.Add(i,distance[i]);
				}
			}

			return vertexToShortestDistance;
		}

		private bool CheckIfDistanceNeedsToBeUpdated(int[] distance, int edgeNumber)
		{
			int source = this.Edges[edgeNumber].From;
			int destination = this.Edges[edgeNumber].To;
			int edgeWeight = this.Edges[edgeNumber].Weight;

			if (distance[source] != Int32.MaxValue &&
			   distance[source] + edgeWeight < distance[destination])
			{
				return true;
			}
			return false;
		}

		public Dictionary<int, int> DirectedAcyclicGraphShortestPathFromSourceUsingTopoLogicalSortOrder(int source)
		{
			//Get topological order
			List<int> topologicalOrder = this.TopologicalSortUsingIndegreeAndQueue();

			//only for output
			Dictionary<int, int> vertexToShortestDistance = new Dictionary<int, int>();

			//track key distance
			int[] distance = new int[this.V];
			for (int i = 0; i < this.V; i++)
			{
				distance[i] = Int32.MaxValue;
			}
			distance[source] = 0;

			//Process each node in order and update adjacent node's distance if less
			foreach (var currentVertex in topologicalOrder)
			{
				foreach (var adjacentVertex in this.adj[currentVertex])
				{
					if (distance[currentVertex] != Int32.MaxValue &&
					   distance[currentVertex] + adjacentVertex.EdgeWeight < distance[adjacentVertex.Id])
					{
						distance[adjacentVertex.Id] = distance[currentVertex] + adjacentVertex.EdgeWeight;
					}
				}
			}

			//output in dictionary format
			for (int i = 0; i < this.V; i++)
			{
				vertexToShortestDistance.Add(i,distance[i]);
			}
			return vertexToShortestDistance;
		}

		/// <summary>
		/// Floyds the warshall all pair shortest paths, not only from source to others. All as source.
		/// </summary>
		/// <returns>The warshall all pair shortest paths.</returns>
		public int[,] FloydWarshallAllPairShortestPaths()
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
					solution[currentVertex, adjacentVertex.Id] = adjacentVertex.EdgeWeight;
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

						//To avoid interger overflow when summing to max values, count it seperatly
						if (solution[fromVertex, intermediateVertex] < Int32.MaxValue / 2 &&
						   solution[intermediateVertex, toVertex] < Int32.MaxValue / 2)
						{
							distanceUsingIntermediate = solution[fromVertex, intermediateVertex] + solution[intermediateVertex, toVertex];
						}

						//Update if needed
						if (distanceUsingIntermediate < currentDirectDistance)
						{
							solution[fromVertex, toVertex] = distanceUsingIntermediate;
						}
					}
				}
			}

			return solution;
		}

		public bool[,] TransitiveClosureUsingFloydWarshallAllPairReachabilityMatrix()
		{
			//O(n^3) solution... DFS takes O(n^2)
			bool[,] solution = new bool[this.V, this.V];

			//Initlize all as INF/MAX
			for (int i = 0; i < this.V; i++)
			{
				for (int j = 0; j < this.V; j++)
				{
					if (i != j)
						solution[i, j] = false;
					else
						solution[i, j] = true;
				}
			}

			//Assign current graph layout to solution in matrix form
			for (int currentVertex = 0; currentVertex < this.V; currentVertex++)
			{
				foreach (var adjacentVertex in adj[currentVertex])
				{
					solution[currentVertex, adjacentVertex.Id] = true;
				}
			}

			//Iterate through all vertex as intermediate path
			for (int intermediateVertex = 0; intermediateVertex < this.V; intermediateVertex++)
			{
				for (int fromVertex = 0; fromVertex < this.V; fromVertex++)
				{
					for (int toVertex = 0; toVertex < this.V; toVertex++)
					{
						solution[fromVertex, toVertex] = solution[fromVertex, toVertex] ||
							(solution[fromVertex, intermediateVertex] && solution[intermediateVertex, toVertex]);
					}
				}
			}

			return solution;
		}
	}
}

