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
            myQueue.EnQueue(6);

            while (!myQueue.IsEmpty())
            {
                Console.WriteLine("Item:" + myQueue.DeQueue());
            }
            Console.WriteLine("-------");

            MyQueue<int> sllQueue = new SllQueue<int>();
            sllQueue.EnQueue(1);
            sllQueue.EnQueue(2);
            sllQueue.EnQueue(3);
            sllQueue.EnQueue(4);
            sllQueue.EnQueue(5);
            sllQueue.EnQueue(6);

            while (!sllQueue.IsEmpty())
            {
                Console.WriteLine("Item:" + sllQueue.DeQueue());
            }
            Console.ReadKey();
        }
    }
}
