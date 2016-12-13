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
            SinglyLinkedList<int> sLinkedList = new SinglyLinkedList<int>();
            sLinkedList.PushToHead(1);
            sLinkedList.PushToHead(2);
            sLinkedList.PushToHead(3);
            sLinkedList.PushToHead(4);
            sLinkedList.PushToHead(5);
            sLinkedList.Print();
            SllNode<int> node1 = sLinkedList.GetNthNodeFromStart(2);
            SllNode<int> node2 = sLinkedList.GetNthNodeFromEnd(2);
            Console.WriteLine(node1.Data);
            Console.WriteLine(node2.Data);

            Console.ReadLine();
        }
    }
}
