using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList<T> where T : IComparable
    {
        private DllNode<T> head;
        //the head of doubly linked list
        public DllNode<T> Head { 
            get {return head;}
            private set {head = value;}
        }

        public DoublyLinkedList()
        {
            this.Head = null;
        }

        public DoublyLinkedList(DllNode<T> someHeadOfOtherList)
        {
            this.Head = someHeadOfOtherList;
        }

        public void PushToHead(T data)
        {
            //Allocate new node
            DllNode<T> newNode = new DllNode<T>(data);

            //Append whole list behind new node
            newNode.Next = Head;
            newNode.Prev = null;

            if(Head!=null)
                Head.Prev = newNode;
            //Make new node as head of the list
            Head = newNode;
        }

        public void PushToHead(DllNode<T> newNode)
        {
            //Append whole list behind new node
            newNode.Next = Head;

            if (Head != null)
                Head.Prev = newNode;

            //Make new node as head of the list
            Head = newNode;
        }

        public void Print()
        {
            DllNode<T> current = Head;
            while (current != null)
            {
                Console.Write(current.Data);
                Console.Write("->");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public DllNode<T> DeleteHeadNode()
        {
            return DeleteNode(this.Head);
        }

        public DllNode<T> DeleteNode(DllNode<T> node)
        {

            DllNode<T> prevNode = node.Prev;
            DllNode<T> nextNode = node.Next;

            if (prevNode==null) //node to be deleted is head
            {
                this.Head = nextNode;
            }
            else
            {
                prevNode.Next = nextNode;
            }

            if(nextNode!=null) // node to be deleted is not last node
            {
                nextNode.Prev = prevNode;
            }

            return node;
        }
    }
}
