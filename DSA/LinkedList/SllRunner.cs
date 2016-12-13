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
            sLinkedList.PushToHead(4);
            sLinkedList.PushToHead(5);
            sLinkedList.Print();
            //sLinkedList.ReverseList();
            sLinkedList.ReverseRecursive();
            sLinkedList.Print();

            Console.WriteLine("Count of 4: " + sLinkedList.countOccurances(4));
            SllNode<int> node1 = sLinkedList.GetNthNodeFromStart(2);
            SllNode<int> node2 = sLinkedList.GetNthNodeFromEnd(2);
            Console.WriteLine("Second node: " + node1.Data);
            Console.WriteLine("Second last node: " + node2.Data);
            Console.WriteLine("Middle node: " + sLinkedList.MiddleNode().Data);
            sLinkedList.DeleteNode(node1);
            sLinkedList.Print();
            Console.WriteLine("Middle node: " + sLinkedList.MiddleNode().Data);

            Console.ReadLine();
        }
    }
}
