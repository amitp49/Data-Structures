using Arrays;
using Interfaces;
using LinkedList;
using Queues;
using Stacks;
using String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using Graphs;
using Heaps;
using UnionFind;
using DynamicProgramming;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            IRunner linkedListRunner = new LinkedListRunner();
            //linkedListRunner.Run();

            IRunner btRunner = new BTRunner();
            btRunner.Run();

            IRunner stackRunner = new StackRunner();
            //stackRunner.Run();

            IRunner queueRunner = new QueueRunner();
            //queueRunner.Run();

            IRunner arrayRunner = new ArrayRunner();
            //arrayRunner.Run();

            IRunner stringRunner = new StringRunner();
            //stringRunner.Run();

			IRunner heapRunner = new HeapRunner();
			//heapRunner.Run();

			IRunner unionFindRunner = new UnionFindRunner();
			//unionFindRunner.Run();

			IRunner graphRunner = new GraphRunner();
			//graphRunner.Run();

			IRunner dpRunner = new DPRunner();
			//dpRunner.Run();
		}
    }
}
