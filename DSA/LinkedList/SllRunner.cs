using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SllRunner : IRunner
    {
        public void Run()
        {
            SLinkedList<int> sLinkedList = new SLinkedList<int>();
            sLinkedList.PushToHead(1);
            sLinkedList.PushToHead(2);
            sLinkedList.PushToHead(3);
            sLinkedList.PushToHead(4);
            sLinkedList.PushToHead(5);
            sLinkedList.Print();

            Console.ReadLine();
        }
    }
}
