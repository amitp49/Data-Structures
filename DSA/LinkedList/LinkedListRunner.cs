using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListRunner : IRunner
    {
        public void Run()
        {
            
            SinglyLinkedList<int> sLinkedList = new SinglyLinkedList<int>();
            sLinkedList.PushToHead(7);

            sLinkedList.PushToHead(6);
            sLinkedList.PushToHead(5);
            sLinkedList.PushToHead(4);
            sLinkedList.PushToHead(3);
            sLinkedList.PushToHead(2);
            sLinkedList.PushToHead(1);

            sLinkedList.Print();
            sLinkedList.ReverseListWithGroupSizeRecursive(3);
            sLinkedList.Print();

            //Split original list into two nodes, dont allocate new list nodes
            //SinglyLinkedList<int> firstList = new SinglyLinkedList<int>();
            //SinglyLinkedList<int> secondList = new SinglyLinkedList<int>();
            //sLinkedList.AlternateSplitOfNodes(out firstList,out secondList);
            //firstList.Print();
            //secondList.Print();

            //sLinkedList.DeleteAlternateNodes();
            //sLinkedList.DeleteNodesAtDistanceRecursive(3);
            //sLinkedList.DeleteAlternateNodesRecursive();
            sLinkedList.DeleteNodesAtDistanceRecursive(3);
            sLinkedList.Print();


            SinglyLinkedList<int> sLinkedListOther = new SinglyLinkedList<int>();
            sLinkedListOther.PushToHead(5);
            sLinkedListOther.PushToHead(3);

            sLinkedListOther.Print();

            SinglyLinkedList<int> mergedIntersectionList = null;
            //mergedIntersectionList = sLinkedList.SortedIntersectionRecursive(sLinkedListOther);
            mergedIntersectionList = sLinkedList.SortedIntersectionIterative(sLinkedListOther);
            mergedIntersectionList.Print();


            Console.WriteLine("AreIdentical:" + sLinkedList.areIdentical(sLinkedListOther));
            Console.WriteLine("AreIdentical Recursive:" + sLinkedList.areIdenticalRecursive(sLinkedListOther));

            //sLinkedList.SortByNodeMovement();
            //sLinkedList.SortByDataMovement();
            sLinkedList.MergeSort();
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


            Console.WriteLine("------Doubly linked list--------");

            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            doublyLinkedList.PushToHead(1);
            doublyLinkedList.PushToHead(2);
            doublyLinkedList.PushToHead(3);
            doublyLinkedList.PushToHead(4);
            doublyLinkedList.PushToHead(5);
            doublyLinkedList.Print();
            Console.ReadLine();
        }
    }
}
