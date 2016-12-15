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
            sLinkedList.PushToHead(3);
            sLinkedList.PushToHead(2);
            sLinkedList.PushToHead(1);
            sLinkedList.Print();
            sLinkedList.SortByNodeMovement();
            sLinkedList.Print();

            Console.WriteLine("Palindrome with stack: " + sLinkedList.IsPalindromeWithStack());
            Console.WriteLine("Palindrome without space: " + sLinkedList.IsPalindromeWithoutExtraSpace());
            Console.WriteLine("Palindrome with recursion: " + sLinkedList.IsPalindromeRecursive());

            sLinkedList.ReverseList();
            //sLinkedList.ReverseRecursive();
           
            sLinkedList.Print();

            Console.WriteLine("Count of 4: " + sLinkedList.countOccurances(4));
            SllNode<int> node1 = sLinkedList.GetNthNodeFromStart(2);
            SllNode<int> node2 = sLinkedList.GetNthNodeFromEnd(1);
            
            Console.WriteLine("Second node: " + node1.Data);
            Console.WriteLine("last node: " + node2.Data);

            //node2.Next = node1;
            Console.WriteLine("Loop:" + sLinkedList.IsLoopPresent());
            
            Console.WriteLine("Middle node: " + sLinkedList.GetMiddleNode().Data);
            sLinkedList.DeleteNode(node1);
            sLinkedList.Print();
            Console.WriteLine("Middle node: " + sLinkedList.GetMiddleNode().Data);

            Console.ReadLine();
        }
    }
}
