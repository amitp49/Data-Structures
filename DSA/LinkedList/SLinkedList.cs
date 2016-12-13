using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SLinkedList<T>
    {
        SllNode<T> head; //the head of singly linked list

        public void PushToHead(T data)
        {
            //Allocate new node
            SllNode<T> newNode = new SllNode<T>(data);

            //Append whole list behind new node
            newNode.Next = head;

            //Make new node as head of the list
            head = newNode;
        }

        public void Print()
        {
            SllNode<T> current = head;
            while(current.Next!=null)
            {
                Console.Write(current.Data);
                Console.Write("->");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
