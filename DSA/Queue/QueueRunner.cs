using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class QueueRunner : IRunner
    {
        public void Run()
        {
            MyQueue<int> myQueue = new ArrayQueue<int>(5);
            myQueue.EnQueue(1);
            myQueue.EnQueue(2);
            myQueue.EnQueue(3);
            myQueue.EnQueue(4);
            myQueue.EnQueue(5);

            while (!myQueue.IsEmpty())
            {
                Console.WriteLine("Item:" + myQueue.DeQueue());
            }
            Console.WriteLine("-------");
            Console.ReadKey();
        }
    }
}
