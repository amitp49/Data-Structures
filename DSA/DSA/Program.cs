using Array;
using Interfaces;
using LinkedList;
using Queue;
using Stack;
using String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            IRunner sllRunner = new SllRunner();
            sllRunner.Run();

            IRunner btRunner = new BTRunner();
            //btRunner.Run();

            IRunner stackRunner = new StackRunner();
            stackRunner.Run();

            IRunner queueRunner = new QueueRunner();
            queueRunner.Run();

            IRunner arrayRunner = new ArrayRunner();
            arrayRunner.Run();

            IRunner stringRunner = new StringRunner();
            stringRunner.Run();

        }
    }
}
